using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Repositories.Interface
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<Training>> GetAllPublicAsync();

        Task<IEnumerable<Training>> GetOwnTrainingsAsync(string id);

        Task<Training> CreateAsync(Training training, string authorId);

        Task<Training?> UpdateAsync(Training training);

        Task<Training?> GetById(Guid id);

        Task<Training?> Delete(Guid id);
    }
}