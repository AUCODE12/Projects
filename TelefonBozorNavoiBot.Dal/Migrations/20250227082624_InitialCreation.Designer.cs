﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefonBozorNavoiBot.Dal;

#nullable disable

namespace TelefonBozorNavoiBot.Dal.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20250227082624_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TelefonBozorNavoiBot.Dal.Entities.Announcement", b =>
                {
                    b.Property<long>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AnnouncementId"));

                    b.Property<int>("BatteryCapacity")
                        .HasColumnType("int");

                    b.Property<int>("BatteryHealth")
                        .HasColumnType("int");

                    b.Property<long>("BotUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneModel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<int>("Storage")
                        .HasColumnType("int");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("BotUserId");

                    b.ToTable("Announcement", (string)null);
                });

            modelBuilder.Entity("TelefonBozorNavoiBot.Dal.Entities.BotUser", b =>
                {
                    b.Property<long>("BotUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BotUserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("TelegramUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BotUserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TelefonBozorNavoiBot.Dal.Entities.Announcement", b =>
                {
                    b.HasOne("TelefonBozorNavoiBot.Dal.Entities.BotUser", "BotUser")
                        .WithMany("Announcements")
                        .HasForeignKey("BotUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BotUser");
                });

            modelBuilder.Entity("TelefonBozorNavoiBot.Dal.Entities.BotUser", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
