﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OvertimeRequest_API.Context;

namespace OvertimeRequest_API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220512142804_upcolumn_paid_overtime")]
    partial class upcolumn_paid_overtime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OvertimeRequest_API.Models.Account", b =>
                {
                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredOTP")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("OTP")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIP");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OvertimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OvertimeId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Employee", b =>
                {
                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaidOvertime")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIP");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.EmployeeOvertime", b =>
                {
                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OvertimeId")
                        .HasColumnType("int");

                    b.HasKey("NIP", "OvertimeId");

                    b.HasIndex("OvertimeId");

                    b.ToTable("EmployeeOvertime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Overtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinanceApprove")
                        .HasColumnType("int");

                    b.Property<int>("ManagerApprove")
                        .HasColumnType("int");

                    b.Property<DateTime>("OvertimeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Paid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Overtime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.RoleAccount", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId", "NIP");

                    b.HasIndex("NIP");

                    b.ToTable("RoleAccount");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Account", b =>
                {
                    b.HasOne("OvertimeRequest_API.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("OvertimeRequest_API.Models.Account", "NIP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Activity", b =>
                {
                    b.HasOne("OvertimeRequest_API.Models.Overtime", "Overtime")
                        .WithMany("Activities")
                        .HasForeignKey("OvertimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Overtime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.EmployeeOvertime", b =>
                {
                    b.HasOne("OvertimeRequest_API.Models.Employee", "Employee")
                        .WithMany("EmployeeOvertime")
                        .HasForeignKey("NIP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OvertimeRequest_API.Models.Overtime", "Overtime")
                        .WithMany("EmployeeOvertime")
                        .HasForeignKey("OvertimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Overtime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.RoleAccount", b =>
                {
                    b.HasOne("OvertimeRequest_API.Models.Account", "Account")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("NIP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OvertimeRequest_API.Models.Role", "Role")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Account", b =>
                {
                    b.Navigation("RoleAccounts");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("EmployeeOvertime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Overtime", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("EmployeeOvertime");
                });

            modelBuilder.Entity("OvertimeRequest_API.Models.Role", b =>
                {
                    b.Navigation("RoleAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
