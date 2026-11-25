using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUser(LoginUser loginUser);
        public Task UpdateUser(int id, User updateUserDetails);

    }
}
