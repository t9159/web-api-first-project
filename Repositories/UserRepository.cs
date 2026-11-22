using Entities;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    //The file is named UserRepository.cs but the class is TxtUserRepository: name the file after the class
    public class TxtUserRepository:IUserRepository
    {
        StoreDBContext _context;
        public TxtUserRepository(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user) 
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public User GetUser(LoginUser loginUser)
        {
            User user=_context.Users.ToList().Find(user => user.Email == loginUser.Email && user.Password== loginUser.Password);
            return user;
        }
        public async Task UpdateUser(int id, User updateUserDetails)
        {
            _context.Users.Remove(_context.Users.ToList().Find(u => u.Id == id));
            _context.Users.Add(updateUserDetails);
            await _context.SaveChangesAsync();
        }
    }
}
