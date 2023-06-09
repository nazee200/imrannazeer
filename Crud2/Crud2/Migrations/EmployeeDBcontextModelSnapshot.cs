﻿// <auto-generated />
using Crud2.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crud2.Migrations
{
    [DbContext(typeof(EmployeeDBcontext))]
    partial class EmployeeDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crud2.Model.employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maritalstatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Crud2.Model.empsalary", b =>
                {
                    b.Property<int>("empid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empid"));

                    b.Property<int>("employid")
                        .HasColumnType("int");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("empid");

                    b.HasIndex("employid");

                    b.ToTable("EmployeesSalary");
                });

            modelBuilder.Entity("Crud2.Model.empsalary", b =>
                {
                    b.HasOne("Crud2.Model.employee", "employ")
                        .WithMany("empsalaries")
                        .HasForeignKey("employid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employ");
                });

            modelBuilder.Entity("Crud2.Model.employee", b =>
                {
                    b.Navigation("empsalaries");
                });
#pragma warning restore 612, 618
        }
    }
}
