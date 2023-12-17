using Dapper;
using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MakmonDbContext _db;
        public PersonRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task PersonJuncPostCreate(List<int> postIds, int personId)
        {
            foreach (var item in postIds)
            {
                var personJuncPost = new PersonJuncPost(personId, item);
                await _db.PersonJuncPost.AddAsync(personJuncPost);
            }
        }

        public async Task<int> Create(Person person)
        {
            var result = await _db.Persons.AddAsync(person);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<PersonView>, int>> FindAll(QueryFilter? queryFilter)
        {
            //Edited later
            using IDbConnection connection = new SqlConnection(_db.Database.GetDbConnection().ConnectionString);

            var sqlQuery = @"select 
                Person.Id,
                CONCAT(Person.FirstName, ' ', Person.LastName) as FullName,
                Person.UserType,
                Person.Gender,
                Person.BirthDate,
                Person.NationalCode,
                Person.Phone,
                Person.ExtraPhone1,
                Person.ExtraPhone2,
                Person.ExtraPhone3,
                Person.Email,
                Person.ExtraEmail,
                Person.Fax,
                Person.Website,
                Person.Instagram,
                Person.Telegram,
                Person.WhatsApp,
                Person.Linkedin,
                Person.Facebook,
                Country.Id as CountryId,
                Country.Title as CountryTitle,
                State.Id as StateId,
                State.Title as StateTitle,
                City.Id as CityId,
                City.Title as CityTitle,
                Zone.Id as ZoneId,
                Zone.Title as ZoneTitle,
                Person.Address,
                Person.LocationLong,
                Person.LocationLat,
                Person.Job,
                Person.Company,
                Person.CompanyNo,
                Person.FatherName,
                Person.PersonalNumber,
                Person.IsActive,
                Person.WorkingHoursRate,
                Person.ReagentName,
                Person.ReagentCode,
                Person.ImageUrl,
                Person.DigitalSignatureUrl,
                Person.ResumeUrl,
                Person.SpacialAccount,
                Person.IsPublic,
                Package.Id as PackageId,
                Package.Title as PackageTitle,
                EducationField.Id as EducationFieldId,
                EducationField.Title as EducationFieldTitle,
                EducationSubField.Id as EducationSubFieldId,
                EducationSubField.Title as EducationSubFieldTitle,
                EducationLevel.Id as EducationLevelId,
                EducationLevel.Title as EducationLevelTitle,
                Person.EmployeementDate,
                Person.ModifiedDate,
                Person.CreateDate
                from Persons Person
                LEFT JOIN Countries Country on Country.Id=Person.CountryId
                LEFT JOIN States State on State.Id=Person.StateId
                LEFT JOIN Cities City on City.Id=Person.CityId
                LEFT JOIN Packages Package on Package.Id=Person.PackageId
                LEFT JOIN EducationSubFields EducationSubField on EducationSubField.Id=Person.EducationSubFieldId
                INNER JOIN EducationFields EducationField on EducationField.Id=EducationSubField.EducationFieldId
                LEFT JOIN EducationLevels EducationLevel on EducationLevel.Id=Person.EducationLevelId";

            sqlQuery = sqlQuery.ApplyFiltering(queryFilter, _db);

            //var addresses = new List<PersonAddress>();

            var resultSet = await connection.QueryAsync<PersonView>(sqlQuery);

            var query = resultSet.AsQueryable();

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Query");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<PersonView>, int>(query.ToList(), totalRecords);
        }
        public async Task<FilterResponse> FilterAllPost(int start, int length)
        {
            var q = from t in _db.PersonJuncPost
                    join t1 in _db.Persons on t.PersonId equals t1.Id
                    join t3 in _db.Posts on t.PostId equals t3.Id
                    select new FilterResponseData
                    {
                        Id = t3.Id,
                        Title = t3.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllCountry(int start, int length)
        {
            var q = from c in _db.Countries
                    join p in _db.Persons on c.Id equals p.CountryId
                    select new FilterResponseData
                    {
                        Id = c.Id,
                        Title = c.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllState(int start, int length)
        {
            var q = from s in _db.States
                    join p in _db.Persons on s.Id equals p.StateId
                    select new FilterResponseData
                    {
                        Id = s.Id,
                        Title = s.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllCity(int start, int length)
        {
            var q = from c in _db.Cities
                    join p in _db.Persons on c.Id equals p.CityId
                    select new FilterResponseData
                    {
                        Id = c.Id,
                        Title = c.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllZone(int start, int length)
        {
            var q = from z in _db.Zones
                    join p in _db.Persons on z.Id equals p.ZoneId
                    select new FilterResponseData
                    {
                        Id = z.Id,
                        Title = z.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllPackage(int start, int length)
        {
            var q = from pa in _db.Packages
                    join p in _db.Persons on pa.Id equals p.PackageId
                    select new FilterResponseData
                    {
                        Id = pa.Id,
                        Title = pa.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllEducationField(int start, int length)
        {
            var q = from ef in _db.EducationFields
                    join es in _db.EducationSubFields on ef.Id equals es.EducationFieldId
                    join p in _db.Persons on es.Id equals p.EducationSubFieldId
                    select new FilterResponseData
                    {
                        Id = ef.Id,
                        Title = ef.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllEducationSubField(int start, int length)
        {
            var q = from es in _db.EducationSubFields
                    join p in _db.Persons on es.Id equals p.EducationSubFieldId
                    select new FilterResponseData
                    {
                        Id = es.Id,
                        Title = es.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllEducationLevel(int start, int length)
        {
            var q = from el in _db.EducationLevels
                    join p in _db.Persons on el.Id equals p.EducationLevelId
                    select new FilterResponseData
                    {
                        Id = el.Id,
                        Title = el.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task<Person> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Persons
                        .Include(d => d.PersonJuncPosts)
                        .ThenInclude(x => x.Post)
                        .FirstOrDefaultAsync(t => t.Id == id && t.UserType != Domain.Enums.UserType.SystemUser);
        }
        public async Task<IList<Person>> FindAllByPost(int[] postIds)
        {
            if (postIds.Any())
            {
                return await _db.Persons.Where(x => x.PersonJuncPosts.Any(t => postIds.Contains(t.PostId)))
                           .Include(d => d.PersonJuncPosts)
                           .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                           .ToListAsync();
            }
            else
            {
                return await _db.Persons
                             .Include(d => d.PersonJuncPosts)
                             .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                             .ToListAsync();
            }
        }
        public async Task Update(Person person)
        {
            _db.Entry<Person>(person).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var person = await FindById(id);
            _db.Entry((Person)person).State = EntityState.Deleted;
        }
        public async Task<IList<PersonJuncPost>> PersonJuncPostGet(int personId)
        {
            var result = await (from x in _db.PersonJuncPost
                                where x.PersonId == personId
                                select x).ToListAsync();
            return result;
            //return _db.PersonJuncPost.Where(x => x.PersonId == personId).ToList();
        }
        public async Task PersonJuncPostDelete(int personId)
        {
            var res = await _db.PersonJuncPost.Where(x => x.PersonId == personId).ToListAsync();
            _db.PersonJuncPost.RemoveRange(res);
        }
        public async Task PersonJuncPostCreate(IReadOnlyCollection<PersonJuncPost> model)
        {
            foreach (var item in model)
            {
                await _db.PersonJuncPost.AddAsync(item);
            }
        }
        public async Task PersonDeleteAll(int[] ids)
        {
            var juncRest = await _db.Persons.Where(x => ids.Contains(x.Id) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
            _db.Persons.RemoveRange(juncRest);
        }
        public async Task PersonJuncPostDeleteAll(int[] ids)
        {
            var juncRest = await _db.PersonJuncPost.Where(x => ids.Contains(x.PersonId)).ToListAsync();
            _db.PersonJuncPost.RemoveRange(juncRest);
        }

        public async Task<bool> IsExistNationCode(string nationalCode)
        {
            return await _db.Persons.AnyAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<bool> IsExistPersonalNumber(string personalNumber)
        {
            return await _db.Persons.AnyAsync(x => x.PersonalNumber == personalNumber);
        }
    }
}
