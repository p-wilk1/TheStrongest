using Microsoft.EntityFrameworkCore;
using TheStrongest.API.Data;
using TheStrongest.API.Models.Domain;
using TheStrongest.API.Repositories.Interface;

namespace TheStrongest.API.Repositories.Implementation
{
    public class ExerciseInfoRepository : IExerciseInfoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExerciseInfoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ExerciseInfo> CreateAsync(ExerciseInfo exerciseInfo)
        {
            await dbContext.ExerciseInfos.AddAsync(exerciseInfo);
            dbContext.SaveChanges();
            return exerciseInfo;
        }

        public async Task<IEnumerable<ExerciseInfo>> GetAll()
        {
            return await dbContext.ExerciseInfos.Include(x => x.Instructions).Include(x => x.SecondaryMuscles).ToListAsync();
        }

        public async Task<ExerciseInfo?> GetById(string id)
        {
            return await dbContext.ExerciseInfos.Include(x => x.Instructions).Include(x => x.SecondaryMuscles).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}