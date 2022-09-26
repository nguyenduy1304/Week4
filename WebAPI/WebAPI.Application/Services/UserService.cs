using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Interfaces;
using WebAPI.Contract.Requests;
using WebAPI.Contract.Response;
using WebAPI.Persistence.DataContext;
using WebAPI.Persistence.Domains;

namespace WebAPI.Application.Services
{
    public class UserService : IUserSevice
    {
        private ApplicationDbContext _context;

        public readonly IMapper _mapper;

        public UserService(ApplicationDbContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetUserResponse> GetUsers()
        {
            var user = _context.User.Include(c => c.UserDetail).AsNoTracking().ToList();
            return _mapper.Map<List<GetUserResponse>>(user);
        }

        public GetUserResponse GetUserByID(string id)
        {
            var user = _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
            return _mapper.Map<GetUserResponse>(user);
        }

        public string CreateUser(CreateUserRequest createUserRequest)
        {
            var _mappedUser = _mapper.Map<User>(createUserRequest);

            _mappedUser.Id = Guid.NewGuid().ToString();
            _mappedUser.UserDetail.IdUser = _mappedUser.Id;

            _context.User.Add(_mappedUser);
            _context.SaveChanges();
            return _mappedUser.Id;
        }

        public void UpdateUser(EditUserRequest editUserRequest, string id)
        {
            var user = _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
            user = _mapper.Map<EditUserRequest, User>(editUserRequest, user);
            _context.SaveChanges();
        }

        public EditUserRequest GetEditUserRequest(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userid)
        {
            User user = _context.User.Find(userid);
            _context.User.Remove(user);
            _context.SaveChanges();
        }
    }
}
