using Microsoft.EntityFrameworkCore;
using NZWalker.API.Models.Domain;
using NZWalks.API.Data;

namespace NZWalker.API.Respositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;


        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            var walks =  await dbContext.Walks.Include(w => w.Region).Include(w => w.Difficulty).ToListAsync();
            return walks;
        }

    }
}
