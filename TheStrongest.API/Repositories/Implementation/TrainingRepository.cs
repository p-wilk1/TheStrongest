using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheStrongest.API.Data;
using TheStrongest.API.Models.Domain;
using TheStrongest.API.Repositories.Interface;

namespace TheStrongest.API.Repositories.Implementation
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TrainingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Training> CreateAsync(Training training, string authorId)
        {
            training.AuthorId = authorId;
            await dbContext.Trainings.AddAsync(training);

            await dbContext.SaveChangesAsync();
            return training;
        }

        public async Task<Training?> Delete(Guid id)
        {
            var exisitingTraining = await dbContext.Trainings.Include(x => x.PerformedExercises).ThenInclude(x => x.Sets).FirstOrDefaultAsync(x => x.Id == id);
            if (exisitingTraining != null)
            {
                dbContext.Trainings.Remove(exisitingTraining);
                dbContext.SaveChanges();
                return exisitingTraining;
            }
            return null;
        }

        public async Task<IEnumerable<Training>> GetAllPublicAsync()
        {
            return await dbContext.Trainings.Include(x => x.PerformedExercises).ThenInclude(c => c.Sets).Where(x => x.IsVisible == true).ToListAsync();
        }

        public async Task<Training?> GetById(Guid id)
        {
            return await dbContext.Trainings.Include(x => x.PerformedExercises).ThenInclude(x => x.Sets).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Training>> GetOwnTrainingsAsync(string id)
        {
            return await dbContext.Trainings.Include(x => x.PerformedExercises).ThenInclude(c => c.Sets).Where(x => x.AuthorId == id).ToListAsync();
        }

        public async Task<Training?> UpdateAsync(Training training)
        {
            var existingTraining = await dbContext.Trainings
                .Include(x => x.PerformedExercises).ThenInclude(x => x.Sets)
                .FirstOrDefaultAsync(q => q.Id == training.Id);

            if (existingTraining == null)
            {
                return null;
            }
            //update training
            dbContext.Entry(existingTraining).CurrentValues.SetValues(training);
            //update exercises in training
            existingTraining.PerformedExercises = training.PerformedExercises;

            await dbContext.SaveChangesAsync();
            return training;
        }
    }
}