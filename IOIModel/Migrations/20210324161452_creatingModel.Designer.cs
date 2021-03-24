﻿// <auto-generated />
using System;
using IOIModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IOIModel.Migrations
{
    [DbContext(typeof(IOIContext))]
    [Migration("20210324161452_creatingModel")]
    partial class creatingModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IOIModel.IOI", b =>
                {
                    b.Property<int>("IOIid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDeadline")
                        .HasColumnType("datetime2");

                    b.HasKey("IOIid");

                    b.HasIndex("InsuranceId");

                    b.ToTable("IOI");
                });

            modelBuilder.Entity("IOIModel.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsValid")
                        .HasColumnType("int");

                    b.HasKey("InsuranceId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("IOIModel.IOI", b =>
                {
                    b.HasOne("IOIModel.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insurance");
                });
#pragma warning restore 612, 618
        }
    }
}
