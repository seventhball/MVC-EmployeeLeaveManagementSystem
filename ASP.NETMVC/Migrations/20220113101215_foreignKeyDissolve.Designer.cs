﻿// <auto-generated />
using System;
using ASP.NETMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220113101215_foreignKeyDissolve")]
    partial class foreignKeyDissolve
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASP.NETMVC.Models.AppliedLeaves", b =>
                {
                    b.Property<int>("ApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplyId"), 1L, 1);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeLeaveId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfLeaves")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplyId");

                    b.HasIndex("EmployeeLeaveId");

                    b.ToTable("AppliedEmpLeaves");
                });

            modelBuilder.Entity("ASP.NETMVC.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ASP.NETMVC.Models.EmployeeLeaves", b =>
                {
                    b.Property<int>("EmployeeLeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeLeaveId"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfLeavesRemaining")
                        .HasColumnType("int");

                    b.Property<int>("NoOfLeavesTaken")
                        .HasColumnType("int");

                    b.Property<int>("TotalNoOfLeaves")
                        .HasColumnType("int");

                    b.Property<DateTime>("UdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeLeaveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeLeaves");
                });

            modelBuilder.Entity("ASP.NETMVC.Models.AppliedLeaves", b =>
                {
                    b.HasOne("ASP.NETMVC.Models.EmployeeLeaves", "EmployeeLeaves")
                        .WithMany()
                        .HasForeignKey("EmployeeLeaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeLeaves");
                });

            modelBuilder.Entity("ASP.NETMVC.Models.EmployeeLeaves", b =>
                {
                    b.HasOne("ASP.NETMVC.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
