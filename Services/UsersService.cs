using Entities;
using Repositories;

namespace Services
{
    public class UsersService
    {
        UserRepository userRepository= new UserRepository();
        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public User GetUser(LoginUser loginUser)
        {
            return userRepository.GetUser(loginUser);
        }
        public void UpdateUser(int id, User updateUserDetails)
        {
            userRepository.UpdateUser(id, updateUserDetails);
        }
    }
}
