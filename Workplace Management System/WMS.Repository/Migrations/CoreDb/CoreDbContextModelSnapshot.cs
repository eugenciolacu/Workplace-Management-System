﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMS.Repository.Contexts;

#nullable disable

namespace WMS.Repository.Migrations.CoreDb
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WMS.Data.Entities.Core.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);

                    b.HasCheckConstraint("CK_Employee_Email", "Email != '' and Email like '%@%'");

                    b.HasCheckConstraint("CK_Employee_FirstName", "FirstName != ''");

                    b.HasCheckConstraint("CK_Employee_LastName", "LastName != ''");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("Name", "SiteId")
                        .IsUnique();

                    b.ToTable("Floor", (string)null);

                    b.HasCheckConstraint("CK_Floor_Name", "Name != ''");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WorkplaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WorkplaceId");

                    b.ToTable("Reservation", (string)null);

                    b.HasCheckConstraint("CK_Reservation_EndTimestamp", "StartTimestamp < EndTimestamp");

                    b.HasCheckConstraint("CK_Reservation_StartTimestamp", "StartTimestamp >= SYSDATETIME()");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Site", (string)null);

                    b.HasCheckConstraint("CK_Site_Name", "Name != ''");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Workplace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("Name", "FloorId")
                        .IsUnique();

                    b.ToTable("Workplace", (string)null);

                    b.HasCheckConstraint("CK_Workplace_Name", "Name != ''");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Floor", b =>
                {
                    b.HasOne("WMS.Data.Entities.Core.Site", "Site")
                        .WithMany("Floors")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Reservation", b =>
                {
                    b.HasOne("WMS.Data.Entities.Core.Employee", "Employee")
                        .WithMany("Reservations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Data.Entities.Core.Workplace", "Workplace")
                        .WithMany("Reservations")
                        .HasForeignKey("WorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Workplace", b =>
                {
                    b.HasOne("WMS.Data.Entities.Core.Floor", "Floor")
                        .WithMany("Workplaces")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Employee", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Floor", b =>
                {
                    b.Navigation("Workplaces");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Site", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("WMS.Data.Entities.Core.Workplace", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
