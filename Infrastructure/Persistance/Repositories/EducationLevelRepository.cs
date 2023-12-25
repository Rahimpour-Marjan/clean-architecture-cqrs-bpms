using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class EducationLevelRepository : IEducationLevelRepository
    {
        private readonly MakmonDbContext _db;
        public EducationLevelRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(EducationLevel educationLevel)
        {
            var result = await _db.EducationLevels.AddAsync(educationLevel);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<EducationLevel>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.EducationLevels.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<EducationLevel>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<EducationLevel> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.EducationLevels.FindAsync(id);
        }

        public async Task Update(EducationLevel model)
        {
            _db.Entry((EducationLevel)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var location = await FindById(id);
            _db.Entry((EducationLevel)location).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var juct = await _db.EducationLevels.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.EducationLevels.RemoveRange(juct);
        }
    }
}
