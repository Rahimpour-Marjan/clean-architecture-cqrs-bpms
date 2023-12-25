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
    public class AccountRepository : IAccountRepository
    {
        private readonly MakmonDbContext _db;
        public AccountRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task AccountJuncPostCreate(List<int> postIds, int accountId)
        {
            foreach (var item in postIds)
            {
                var AccountJuncPost = new AccountJuncPost(accountId, item);
                await _db.AccountJuncPost.AddAsync(AccountJuncPost);
            }
        }

        public async Task<int> Create(Account account)
        {
            var result = await _db.Accounts.AddAsync(account);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<AccountView>, int>> FindAll(QueryFilter? queryFilter)
        {
            //Edited later
            using IDbConnection connection = new SqlConnection(_db.Database.GetDbConnection().ConnectionString);

            var sqlQuery = @"select 
                Account.Id,
                CONCAT(Account.FirstName, ' ', Account.LastName) as FullName,
                Account.UserType,
                Account.Gender,
                Account.BirthDate,
                Account.NationalCode,
                Account.Phone,
                Account.ExtraPhone1,
                Account.ExtraPhone2,
                Account.ExtraPhone3,
                Account.Email,
                Account.ExtraEmail,
                Account.Fax,
                Account.Website,
                Account.Instagram,
                Account.Telegram,
                Account.WhatsApp,
                Account.Linkedin,
                Account.Facebook,
                Country.Id as CountryId,
                Country.Title as CountryTitle,
                State.Id as StateId,
                State.Title as StateTitle,
                City.Id as CityId,
                City.Title as CityTitle,
                Zone.Id as ZoneId,
                Zone.Title as ZoneTitle,
                Account.Address,
                Account.LocationLong,
                Account.LocationLat,
                Account.Job,
                Account.Company,
                Account.CompanyNo,
                Account.FatherName,
                Account.AccountalNumber,
                Account.IsActive,
                Account.WorkingHoursRate,
                Account.ReagentName,
                Account.ReagentCode,
                Account.ImageUrl,
                Account.DigitalSignatureUrl,
                Account.ResumeUrl,
                Account.SpacialAccount,
                Account.IsPublic,
                Package.Id as PackageId,
                Package.Title as PackageTitle,
                EducationField.Id as EducationFieldId,
                EducationField.Title as EducationFieldTitle,
                EducationSubField.Id as EducationSubFieldId,
                EducationSubField.Title as EducationSubFieldTitle,
                EducationLevel.Id as EducationLevelId,
                EducationLevel.Title as EducationLevelTitle,
                Account.EmployeementDate,
                Account.ModifiedDate,
                Account.CreateDate
                from Accounts Account
                LEFT JOIN Countries Country on Country.Id=Account.CountryId
                LEFT JOIN States State on State.Id=Account.StateId
                LEFT JOIN Cities City on City.Id=Account.CityId
                LEFT JOIN Packages Package on Package.Id=Account.PackageId
                LEFT JOIN EducationSubFields EducationSubField on EducationSubField.Id=Account.EducationSubFieldId
                INNER JOIN EducationFields EducationField on EducationField.Id=EducationSubField.EducationFieldId
                LEFT JOIN EducationLevels EducationLevel on EducationLevel.Id=Account.EducationLevelId
                LEFT JOIN AccountAddresses AccountAddress on Account.Id=AccountAddress.AccountId";

            sqlQuery = sqlQuery.ApplyFiltering(queryFilter, _db);

            var accountAddresses = new List<AccountAddress>();

            var resultSet = await connection.QueryAsync<AccountView, AccountAddress, AccountView>
               (sqlQuery, (Account, AccountAddress) =>
               {
                   if (AccountAddress != null)
                   {
                       if (accountAddresses.Any(x => x.AccountId == AccountAddress.AccountId && x.Id != AccountAddress.Id))
                           accountAddresses.Add(AccountAddress);
                       else
                       {
                           accountAddresses = new List<AccountAddress>();
                           accountAddresses.Add(AccountAddress);
                       }
                       Account.AccountAddresses = accountAddresses.Distinct().ToList();
                   }

                   return Account;
               },
               splitOn: "Id,AccountId");


            var query = resultSet.GroupBy(x => x.Id, (key, g) => g.Last()).AsQueryable();

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Query");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<AccountView>, int>(query.ToList(), totalRecords);
        }
        public async Task<FilterResponse> FilterAllPost(int start, int length)
        {
            var q = from t in _db.AccountJuncPost
                    join t1 in _db.Accounts on t.AccountId equals t1.Id
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
                    join p in _db.Accounts on c.Id equals p.CountryId
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
                    join p in _db.Accounts on s.Id equals p.StateId
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
                    join p in _db.Accounts on c.Id equals p.CityId
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
                    join p in _db.Accounts on z.Id equals p.ZoneId
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
                    join p in _db.Accounts on pa.Id equals p.PackageId
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
                    join p in _db.Accounts on es.Id equals p.EducationSubFieldId
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
                    join p in _db.Accounts on es.Id equals p.EducationSubFieldId
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
                    join p in _db.Accounts on el.Id equals p.EducationLevelId
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
        public async Task<Account> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Accounts
                        .Include(d => d.AccountJuncPosts)
                        .ThenInclude(x => x.Post)
                        .FirstOrDefaultAsync(t => t.Id == id && t.UserType != Domain.Enums.UserType.SystemUser);
        }
        public async Task<IList<Account>> FindAllByPost(int[] postIds)
        {
            if (postIds.Any())
            {
                return await _db.Accounts.Where(x => x.AccountJuncPosts.Any(t => postIds.Contains(t.PostId)))
                           .Include(d => d.AccountJuncPosts)
                           .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                           .ToListAsync();
            }
            else
            {
                return await _db.Accounts
                             .Include(d => d.AccountJuncPosts)
                             .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                             .ToListAsync();
            }
        }
        public async Task Update(Account account)
        {
            _db.Entry<Account>(account).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var account = await FindById(id);
            _db.Entry((Account)account).State = EntityState.Deleted;
        }
        public async Task<IList<AccountJuncPost>> AccountJuncPostGet(int accountId)
        {
            var result = await (from x in _db.AccountJuncPost
                                where x.AccountId == accountId
                                select x).ToListAsync();
            return result;
            //return _db.AccountJuncPost.Where(x => x.AccountId == AccountId).ToList();
        }
        public async Task AccountJuncPostDelete(int accountId)
        {
            var res = await _db.AccountJuncPost.Where(x => x.AccountId == accountId).ToListAsync();
            _db.AccountJuncPost.RemoveRange(res);
        }
        public async Task AccountJuncPostCreate(IReadOnlyCollection<AccountJuncPost> model)
        {
            foreach (var item in model)
            {
                await _db.AccountJuncPost.AddAsync(item);
            }
        }
        public async Task AccountDeleteAll(int[] ids)
        {
            var juncRest = await _db.Accounts.Where(x => ids.Contains(x.Id) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
            _db.Accounts.RemoveRange(juncRest);
        }
        public async Task AccountJuncPostDeleteAll(int[] ids)
        {
            var juncRest = await _db.AccountJuncPost.Where(x => ids.Contains(x.AccountId)).ToListAsync();
            _db.AccountJuncPost.RemoveRange(juncRest);
        }

        public async Task<bool> IsExistNationCode(string nationalCode)
        {
            return await _db.Accounts.AnyAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<bool> IsExistAccountalNumber(string accountalNumber)
        {
            return await _db.Accounts.AnyAsync(x => x.AccountalNumber == accountalNumber);
        }
    }
}
