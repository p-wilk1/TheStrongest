using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Repositories.Interface
{
    public interface IExerciseInfoRepository
    {
        Task<IEnumerable<ExerciseInfo>> GetAll();

        Task<ExerciseInfo?> GetById(string id);

        Task<ExerciseInfo> CreateAsync(ExerciseInfo exerciseInfo);
    }
}