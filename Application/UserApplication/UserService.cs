//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Application.Users.Models;
//using Domain;
//using Domain.Values;
//using Infrastructure.Persistance;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Users
//{
//    public class UserService : IUserService
//    {
//        private readonly KardinoDbContext _db;
//        private readonly IMapper _mapper;
//        private readonly ILogger _logger;

//        public UserService(KardinoDbContext db, IMapper mapper, ILogger<UserService> logger)
//        {
//            _db = db;
//            _mapper = mapper;
//            _logger = logger;
//        }

//        public async Task Create(UserAddInfo info)
//        {
//            var model = _mapper.Map<UserAddInfo, User>(info);
//            _db.Users.Add(model);
//            await _db.SaveChangesAsync();
//        }

//        public async Task<IList<UserInfo>> FindAll()
//        {
//            var model = await _db.Users.ToListAsync();

//            return model.Select(_mapper.Map<User, UserInfo>).ToList();
//        }

//        public async Task<UserInfo> FindById(int id)
//        {
//            var model = await _db.Users.FindAsync(id);
//            return _mapper.Map<User, UserInfo>(model);
//        }

//        public async Task<UserInfo> FindByLoginInfo(string userName,string password)
//        {
//            var model = await _db.Users.FindAsync(userName, password);
//            return _mapper.Map<User, UserInfo>(model);
//        }

//        public async Task<UserEditInfo> GetEdit(int UserId)
//        {
//            var User = await _db.Users.FindAsync(UserId);
//            _logger.LogInformation($"User by Id [{User.Id}] found.");
//            return _mapper.Map<User, UserEditInfo>(User);
//        }

//        public async Task Update(UserEditInfo UserEditInfo)
//        {
//            var User = new User(UserEditInfo.UserName, UserEditInfo.FullName, UserEditInfo.Password, UserEditInfo.Salt, UserEditInfo.Email, UserEditInfo.UserType)
//            {
//                UserName = UserEditInfo.UserName,
//                FullName = UserEditInfo.FullName,
//                Password = UserEditInfo.Password,
//                Salt = UserEditInfo.Salt,
//                Email = UserEditInfo.Email,
//                UserType = UserEditInfo.UserType,
//            };

//            _db.Entry((User)User).State = EntityState.Modified;

//            await _db.SaveChangesAsync();

//            _logger.LogInformation($"User by Id [{User.Id}] Updated.", (object)User);

//        }
//    }
//}
