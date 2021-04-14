﻿// <auto-generated />
using System;
using JurisTempus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JurisTempus.Data.Migrations
{
    [DbContext(typeof(BillingContext))]
    [Migration("20200109213430_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JurisTempus.Data.Entities.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("FileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            FileNumber = "ATL12394872",
                            Status = 1
                        });
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "Frank Sloan",
                            Name = "Sloan Taxis",
                            Phone = "555-555-1212"
                        });
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BillingRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GovernmentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BillingRate = 45m,
                            FirstName = "Shawn",
                            GovernmentId = "1234567890",
                            LastName = "Wildermuth",
                            Role = "Paralegal"
                        });
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicComments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.TimeBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TimeSegments")
                        .HasColumnType("int");

                    b.Property<DateTime>("WorkDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("TimeBills");
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Case", b =>
                {
                    b.HasOne("JurisTempus.Data.Entities.Client", "Client")
                        .WithMany("Cases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Client", b =>
                {
                    b.OwnsOne("JurisTempus.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Address2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Address3")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CityTown")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StateProvince")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");

                            b1.HasData(
                                new
                                {
                                    ClientId = 1,
                                    Address1 = "123 Main Street",
                                    CityTown = "Atlanta",
                                    PostalCode = "12345",
                                    StateProvince = "GA"
                                });
                        });
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.Invoice", b =>
                {
                    b.HasOne("JurisTempus.Data.Entities.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("JurisTempus.Data.Entities.TimeBill", b =>
                {
                    b.HasOne("JurisTempus.Data.Entities.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId");

                    b.HasOne("JurisTempus.Data.Entities.Employee", "Employee")
                        .WithMany("TimeBilling")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("JurisTempus.Data.Entities.Invoice", null)
                        .WithMany("TimeBills")
                        .HasForeignKey("InvoiceId");
                });
#pragma warning restore 612, 618
        }
    }
}
