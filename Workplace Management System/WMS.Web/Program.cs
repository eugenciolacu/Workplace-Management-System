using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Text;
using WMS.Data.Entities.Auth;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Implementations;
using WMS.Repository.Repositories.Interfaces;
using WMS.Service.Implementations;
using WMS.Service.Interfaces;
using WMS.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// ConfigureServices

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IIdentityService, IdentityService>();

// For Identity
builder.Services.AddIdentity<User, Role>(o =>
    {
        o.Password.RequireDigit = false; 
        o.Password.RequireLowercase = true; 
        o.Password.RequireUppercase = true; 
        o.Password.RequireNonAlphanumeric = true;
        o.Password.RequiredLength = 4; 
        o.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = configuration["JwtSettings:ValidAudience"],
        ValidIssuer = configuration["JwtSettings:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]))
    };
});

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContexts(configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(SitesService)); // assembly where automapper is used
builder.Services.ConfigureServices();

// suppress default model state validation to be able to get 422 code instead of 400
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();

// used by AspNetCoreRateLimit library; rate limiting and throttling
builder.Services.AddMemoryCache();

builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Workplace Management System v1");
        s.SwaggerEndpoint("/swagger/v2/swagger.json", "Workplace Management System v2");
    });
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

// Resolve a scoped service for a limited duration when the app starts
using (var serviceScope = app.Services.CreateScope())
{
    app.ConfigureExceptionHandler(serviceScope.ServiceProvider.GetRequiredService<ILoggerManager>());
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPplicy");

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseIpRateLimiting();

app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();