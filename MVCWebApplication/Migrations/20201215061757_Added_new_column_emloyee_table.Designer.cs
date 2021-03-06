﻿// <auto-generated />
using MVCWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCWebApplication.Migrations
{
    [DbContext(typeof(EmployeeDBContext))]
    [Migration("20201215061757_Added_new_column_emloyee_table")]
    partial class Added_new_column_emloyee_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCWebApplication.Models.TblEmployee", b =>
                {
                    b.Property<int>("PKEmloyeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("PKEmloyeeId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
