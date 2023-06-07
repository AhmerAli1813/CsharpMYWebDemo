﻿// <auto-generated />
using System;
using AhmerMYWebDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AhmerMYWebDemo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230607145910_addDepartments")]
    partial class addDepartments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AhmerMYWebDemo.Models.Departments", b =>
                {
                    b.Property<int>("Dep_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dep_Id"));

                    b.Property<string>("Dep_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("Dep_Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AhmerMYWebDemo.Models.ESalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("EAmount")
                        .HasColumnType("real");

                    b.Property<int>("EMonth")
                        .HasColumnType("int");

                    b.Property<DateTime>("Edate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("AhmerMYWebDemo.Models.Employees", b =>
                {
                    b.Property<int>("E_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("E_Id"));

                    b.Property<string>("E_Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("E_ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("E_Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("E_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("E_Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("E_Id");

                    b.ToTable("TblEmployee");
                });

            modelBuilder.Entity("AhmerMYWebDemo.Models.Departments", b =>
                {
                    b.HasOne("AhmerMYWebDemo.Models.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AhmerMYWebDemo.Models.ESalary", b =>
                {
                    b.HasOne("AhmerMYWebDemo.Models.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}