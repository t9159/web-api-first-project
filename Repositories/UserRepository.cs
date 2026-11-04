using Entities;
using System.Text.Json;

namespace Repositories
{
    public class TxtUserRepository:IUserRepository
    {
        public User AddUser(User user)
        {
            string filePath = "../Repositories/DataUsers.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public User GetUser(LoginUser loginUser)
        {
            string filePath = "../Repositories/DataUsers.txt";
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password == loginUser.Password)
                        return user;
                }
            }
            return null;

        }
        public void UpdateUser(int id, User updateUserDetails)
        {
            string filePath = "../Repositories/DataUsers.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
