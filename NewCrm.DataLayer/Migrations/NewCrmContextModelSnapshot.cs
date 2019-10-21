﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewCrm.DataLayer.Context;

namespace NewCrm.DataLayer.Migrations
{
    [DbContext(typeof(NewCrmContext))]
    partial class NewCrmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("EnName")
                        .HasMaxLength(100);

                    b.Property<string>("FaName")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastEditTime");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.Services", b =>
                {
                    b.Property<int>("ServicesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("EnName")
                        .HasMaxLength(100);

                    b.Property<string>("FaName")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastEditTime");

                    b.Property<int?>("ServiceTypeId");

                    b.Property<int>("ServiceType_ID");

                    b.HasKey("ServicesId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Closure");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("PersonNationalId");

                    b.Property<int>("Service_ID");

                    b.Property<int>("Status")
                        .HasMaxLength(6);

                    b.Property<string>("Title");

                    b.HasKey("TicketId");

                    b.HasIndex("PersonNationalId");

                    b.HasIndex("Service_ID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.TicketingChat", b =>
                {
                    b.Property<int>("TicketingChatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CommentTime");

                    b.Property<bool>("Confidential");

                    b.Property<string>("PersonNationalId");

                    b.Property<int>("Ticket_ID");

                    b.HasKey("TicketingChatId");

                    b.HasIndex("PersonNationalId");

                    b.HasIndex("Ticket_ID");

                    b.ToTable("TicketingChats");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.User.Person", b =>
                {
                    b.Property<string>("PersonNational_ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

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

                    b.HasKey("PersonNational_ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.User.Staff", b =>
                {
                    b.Property<int>("Staff_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("EduDegree")
                        .HasMaxLength(50);

                    b.Property<string>("EduField")
                        .HasMaxLength(50);

                    b.Property<string>("PersonNationalId");

                    b.Property<string>("PersonNational_ID");

                    b.Property<int>("PositionId");

                    b.Property<string>("StaffNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TeleNumber")
                        .HasMaxLength(12);

                    b.HasKey("Staff_ID");

                    b.HasIndex("PersonNationalId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.Services", b =>
                {
                    b.HasOne("NewCrm.DataLayer.Entities.Ticketing.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId");
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.Ticket", b =>
                {
                    b.HasOne("NewCrm.DataLayer.Entities.User.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonNationalId");

                    b.HasOne("NewCrm.DataLayer.Entities.Ticketing.Services", "Services")
                        .WithMany()
                        .HasForeignKey("Service_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.Ticketing.TicketingChat", b =>
                {
                    b.HasOne("NewCrm.DataLayer.Entities.User.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonNationalId");

                    b.HasOne("NewCrm.DataLayer.Entities.Ticketing.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("Ticket_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewCrm.DataLayer.Entities.User.Staff", b =>
                {
                    b.HasOne("NewCrm.DataLayer.Entities.User.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonNationalId");
                });
#pragma warning restore 612, 618
        }
    }
}
