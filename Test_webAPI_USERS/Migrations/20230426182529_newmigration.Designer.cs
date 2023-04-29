﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_webAPI_USERS.Context;

#nullable disable

namespace Test_webAPI_USERS.Migrations
{
    [DbContext(typeof(AppDBcontext))]
    [Migration("20230426182529_newmigration")]
    partial class newmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test_webAPI_USERS.Model.Users", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RevokedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RevokedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.ToTable("UserDB");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("3a3d2df7-a0e2-44fa-955a-0b878b4ba3ec"),
                            Admin = true,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(548),
                            Gender = 1,
                            Login = "user1",
                            ModifiedBy = "admin",
                            ModifiedOn = new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(557),
                            Name = "user1",
                            Password = "user1",
                            RevokedBy = "admin",
                            RevokedOn = new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(558)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
