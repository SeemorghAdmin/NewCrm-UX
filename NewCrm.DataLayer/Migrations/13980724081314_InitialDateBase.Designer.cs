﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewCrm.DataLayer.Context;

namespace NewCrm.DataLayer.Migrations
{
    [DbContext(typeof(NewCrmContext))]
    [Migration("13980724081314_InitialDateBase")]
    partial class InitialDateBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewCrm.DataLayer.Entities.User.Person", b =>
                {
                    b.Property<string>("PersonNationalId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("FatherName")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastEditTime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NationalCardSerial")
                        .HasMaxLength(12);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("Role1");

                    b.Property<int>("Role2");

                    b.Property<int>("Role3");

                    b.Property<int>("Role4");

                    b.Property<string>("ShenasNum")
                        .HasMaxLength(12);

                    b.Property<string>("ShenasSerial")
                        .HasMaxLength(12);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PersonNationalId");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}
