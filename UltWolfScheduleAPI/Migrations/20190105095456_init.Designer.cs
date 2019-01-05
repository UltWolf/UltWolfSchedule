﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltWolfScheduleAPI.Models.Context;

namespace UltWolfScheduleAPI.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20190105095456_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UltWolfScheduleAPI.Models.ManyToMany.UserOrdinaryTask", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("OrdinaryTaskId");

                    b.HasKey("UserId", "OrdinaryTaskId");

                    b.HasIndex("OrdinaryTaskId");

                    b.ToTable("UserOrdinaryTask");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.MultipleTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MulTasks");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.OrdinaryTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OrdTasks");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int?>("User");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.UserMultipleTask", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("MultipleTaskId");

                    b.HasKey("UserId", "MultipleTaskId");

                    b.HasIndex("MultipleTaskId");

                    b.ToTable("UserMultipleTask");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.ManyToMany.UserOrdinaryTask", b =>
                {
                    b.HasOne("UltWolfScheduleAPI.Models.OrdinaryTask", "task")
                        .WithMany()
                        .HasForeignKey("OrdinaryTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UltWolfScheduleAPI.Models.User", "User")
                        .WithMany("Task")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.OrdinaryTask", b =>
                {
                    b.HasOne("UltWolfScheduleAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.User", b =>
                {
                    b.HasOne("UltWolfScheduleAPI.Models.MultipleTask")
                        .WithMany("user")
                        .HasForeignKey("User");
                });

            modelBuilder.Entity("UltWolfScheduleAPI.Models.UserMultipleTask", b =>
                {
                    b.HasOne("UltWolfScheduleAPI.Models.MultipleTask", "task")
                        .WithMany()
                        .HasForeignKey("MultipleTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UltWolfScheduleAPI.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
