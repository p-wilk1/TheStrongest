using Microsoft.EntityFrameworkCore;
using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<PerformedExercise> PerformedExercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<ExerciseInfo> ExerciseInfos { get; set; }
        public DbSet<SecondaryMuscles> SecondaryMuscles { get; set; }
        public DbSet<Instructions> Instructions { get; set; }
    }
}