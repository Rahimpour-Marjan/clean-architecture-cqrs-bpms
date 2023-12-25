using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class EducationFieldRepository : IEducationFieldRepository
    {
        private readonly MakmonDbContext _db;
        public EducationFieldRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(EducationField educationField)
        {
            var result = await _db.EducationFields.AddAsync(educationField);
            return result.Entity.Id;
        }

        public async Task<EducationField> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.EducationFields.FindAsync(id);
        }

        public async Task<Tuple<IList<EducationField>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.EducationFields.Include(x => x.EducationSubFields).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<EducationField>, int>(await query.ToListAsync(), totalRecords);
        }

        public async Task Update(EducationField model)
        {
            _db.Entry((EducationField)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var educationField = await FindById(id);
            _db.Entry((EducationField)educationField).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var juct = await _db.EducationFields.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.EducationFields.RemoveRange(juct);
        }
    }
}
