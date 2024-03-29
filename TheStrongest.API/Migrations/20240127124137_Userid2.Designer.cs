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
    [Migration("20240127124137_Userid2")]
    partial class Userid2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseInfoSecondaryMuscles", b =>
                {
                    b.Property<string>("ExercisesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SecondaryMusclesId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesId", "SecondaryMusclesId");

                    b.HasIndex("SecondaryMusclesId");

                    b.ToTable("ExerciseInfoSecondaryMuscles");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.ExerciseInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GifUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseInfos");
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Instructions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseInfoId");

                    b.ToTable("Instructions");
                });

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

            modelBuilder.Entity("TheStrongest.API.Models.Domain.SecondaryMuscles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecondaryMuscles");
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("ExerciseInfoSecondaryMuscles", b =>
                {
                    b.HasOne("TheStrongest.API.Models.Domain.ExerciseInfo", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheStrongest.API.Models.Domain.SecondaryMuscles", null)
                        .WithMany()
                        .HasForeignKey("SecondaryMusclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheStrongest.API.Models.Domain.Instructions", b =>
                {
                    b.HasOne("TheStrongest.API.Models.Domain.ExerciseInfo", null)
                        .WithMany("Instructions")
                        .HasForeignKey("ExerciseInfoId");
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

            modelBuilder.Entity("TheStrongest.API.Models.Domain.ExerciseInfo", b =>
                {
                    b.Navigation("Instructions");
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
