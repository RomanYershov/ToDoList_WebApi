﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.DAL.EF;

namespace ToDoList.DAL.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20191201091704_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoList.DAL.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name");

                    b.Property<int?>("ToDoListId");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ToDoList.DAL.Entities.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDone");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("ToDoList.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDoList.DAL.Entities.Tag", b =>
                {
                    b.HasOne("ToDoList.DAL.Entities.ToDoList")
                        .WithMany("Tags")
                        .HasForeignKey("ToDoListId");
                });

            modelBuilder.Entity("ToDoList.DAL.Entities.ToDoList", b =>
                {
                    b.HasOne("ToDoList.DAL.Entities.User")
                        .WithMany("ToDoLists")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
