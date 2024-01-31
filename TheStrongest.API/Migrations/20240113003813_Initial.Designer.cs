﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheStrongest.API.Data;

#nullable disable

namespace TheStrongest.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240113003813_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheStrongest.API.Models.Domain.PerformedExercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("PerformedExercises");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PerformedExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PerformedExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<double>("TotalWeightLifted")
                        .HasColumnType("float");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.PerformedExercise", b =>
                {
                    b.HasOne("TheStrongest.API.Models.Domain.Training", null)
                        .WithMany("PerformedExercises")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Set", b =>
                {
                    b.HasOne("TheStrongest.API.Models.Domain.PerformedExercise", null)
                        .WithMany("Sets")
                        .HasForeignKey("PerformedExerciseId");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.PerformedExercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Training", b =>
                {
                    b.Navigation("PerformedExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
