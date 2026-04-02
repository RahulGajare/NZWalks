using NZWalker.API.Models.Domain;

namespace NZWalker.API.Respositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
    }
}
