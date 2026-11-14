using Entities;
using Repositories;

namespace Services
{
    public class UsersService:IUserService
    {
        IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public User GetUser(LoginUser loginUser)
        {
            return _userRepository.GetUser(loginUser);
        }
        public async Task UpdateUser(int id, User updateUserDetails)
        {
            await _userRepository.UpdateUser(id, updateUserDetails);
        }
    }
}
