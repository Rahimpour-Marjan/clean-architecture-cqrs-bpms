using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class EducationSubFieldRepository : IEducationSubFieldRepository
    {
        private readonly MakmonDbContext _db;
        public EducationSubFieldRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(EducationSubField educationSubField)
        {
            var result = await _db.EducationSubFields.AddAsync(educationSubField);
            return result.Entity.Id;
        }

        public async Task<EducationSubField> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.EducationSubFields.Include(x => x.EducationField).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tuple<IList<EducationSubField>, int>> FindAll(QueryFilter? queryFilter, int? educationFieldId)
        {
            var query = _db.EducationSubFields.Where(x => educationFieldId == null || x.EducationFieldId == educationFieldId).Include(x => x.EducationField).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<EducationSubField>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<FilterResponse> FilterAllEducationField(int start, int length)
        {
            var q = from t in _db.EducationFields
                    join t1 in _db.EducationSubFields on t.Id equals t1.EducationFieldId
                    select new FilterResponseData
                    {
                        Id = t.Id,
                        Title = t.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }


        public async Task Update(EducationSubField model)
        {
            _db.Entry((EducationSubField)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var educationSubField = await FindById(id);
            _db.Entry((EducationSubField)educationSubField).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var juct = await _db.EducationSubFields.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.EducationSubFields.RemoveRange(juct);
        }
    }
}
