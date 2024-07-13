﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PureSOLWorkCase.Data;

#nullable disable

namespace PureSOLWorkCase.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240713135940_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PureSOLWorkCase.Domain.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            ActivityId = 1,
                            ActivityDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ActivityType = "Login",
                            Description = "Login Successfully.",
                            UserId = 1
                        },
                        new
                        {
                            ActivityId = 2,
                            ActivityDate = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ActivityType = "PageView",
                            Description = "Profile",
                            UserId = 2
                        },
                        new
                        {
                            ActivityId = 3,
                            ActivityDate = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ActivityType = "PageView",
                            Description = "Games",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("PureSOLWorkCase.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "john.doe@example.com",
                            JoinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John Doe"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "jane.smith@example.com",
                            JoinDate = new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("PureSOLWorkCase.Domain.Activity", b =>
                {
                    b.HasOne("PureSOLWorkCase.Domain.User", null)
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PureSOLWorkCase.Domain.User", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
