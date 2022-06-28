using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Repository.Migrations.CoreDb
{
    public partial class InitialCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.CheckConstraint("CK_Employee_Email", "Email != '' and Email like '%@%'");
                    table.CheckConstraint("CK_Employee_FirstName", "FirstName != ''");
                    table.CheckConstraint("CK_Employee_LastName", "LastName != ''");
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.CheckConstraint("CK_Site_Name", "Name != ''");
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.CheckConstraint("CK_Floor_Name", "Name != ''");
                    table.ForeignKey(
                        name: "FK_Floor_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workplace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FloorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplace", x => x.Id);
                    table.CheckConstraint("CK_Workplace_Name", "Name != ''");
                    table.ForeignKey(
                        name: "FK_Workplace_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkplaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.CheckConstraint("CK_Reservation_EndTimestamp", "StartTimestamp < EndTimestamp");
                    table.CheckConstraint("CK_Reservation_StartTimestamp", "StartTimestamp >= SYSDATETIME()");
                    table.ForeignKey(
                        name: "FK_Reservation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Workplace_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floor_Name_SiteId",
                table: "Floor",
                columns: new[] { "Name", "SiteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Floor_SiteId",
                table: "Floor",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EmployeeId",
                table: "Reservation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_WorkplaceId",
                table: "Reservation",
                column: "WorkplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Name",
                table: "Site",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workplace_FloorId",
                table: "Workplace",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Workplace_Name_FloorId",
                table: "Workplace",
                columns: new[] { "Name", "FloorId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Workplace");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
