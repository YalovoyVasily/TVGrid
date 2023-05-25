﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TVGrid;

#nullable disable

namespace TVGrid.Migrations
{
    [DbContext(typeof(MyDB))]
    partial class MyDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TVGrid.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramTypeDictionaryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramTypeDictionaryID");

                    b.ToTable("Program");
                });

            modelBuilder.Entity("TVGrid.ProgramTypeDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgramTypeDictionary");
                });

            modelBuilder.Entity("TVGrid.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TVGrid.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProgramID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProgramID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("TVGrid.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TVGrid.Program", b =>
                {
                    b.HasOne("TVGrid.ProgramTypeDictionary", "ProgramTypeDictionary")
                        .WithMany("Programs")
                        .HasForeignKey("ProgramTypeDictionaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramTypeDictionary");
                });

            modelBuilder.Entity("TVGrid.Schedule", b =>
                {
                    b.HasOne("TVGrid.Program", "Program")
                        .WithMany("Schedule")
                        .HasForeignKey("ProgramID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("TVGrid.User", b =>
                {
                    b.HasOne("TVGrid.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TVGrid.Program", b =>
                {
                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("TVGrid.ProgramTypeDictionary", b =>
                {
                    b.Navigation("Programs");
                });

            modelBuilder.Entity("TVGrid.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
