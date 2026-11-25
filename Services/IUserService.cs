using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUser(LoginUser loginUser);
        public Task UpdateUser(int id, User updateUserDetails);
    }
}
