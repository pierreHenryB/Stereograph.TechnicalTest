﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stereograph.TechnicalTest.Api.DataAccess;

#nullable disable

namespace Stereograph.TechnicalTest.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240218134948_InitialSchemaPersonEntity")]
    partial class InitialSchemaPersonEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Stereograph.TechnicalTest.Api.Entities.Person", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar")
                        .HasColumnName("lastName");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}