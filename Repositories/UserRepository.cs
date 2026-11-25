using Entities;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
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

        public Task<User> GetUser(LoginUser loginUser)
        {
            Task<User> user = _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            return user;
        }
        public async Task UpdateUser(int id, User updateUserDetails)
        {
            updateUserDetails.Id = id;
            _context.Users.Update(updateUserDetails);
            await _context.SaveChangesAsync();
        }
    }
}
