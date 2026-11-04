using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);
        public User GetUser(LoginUser loginUser);
        public void UpdateUser(int id, User updateUserDetails);

    }
}
