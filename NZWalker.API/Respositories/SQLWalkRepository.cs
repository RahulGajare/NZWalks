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

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include(w => w.Region).Include(w => w.Difficulty).FirstOrDefaultAsync(w => w.Id == id);
            
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
