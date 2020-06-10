﻿// <auto-generated />
using Inte_InpatientCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inte_InpatientCare.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200610131750_removesex")]
    partial class removesex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inte_InpatientCare.Models.InPatient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chaperone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InPatCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("InPatients");

                    b.HasData(
                        new
                        {
                            ID = 11,
                            Chaperone = "毛",
                            InPatCard = "16122315",
                            Name = "闫高伟"
                        },
                        new
                        {
                            ID = 12,
                            Chaperone = "烟",
                            InPatCard = "16122315",
                            Name = "毛子轩"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
