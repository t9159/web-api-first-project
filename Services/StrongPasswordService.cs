using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class StrongPasswordService
    {
        
        public Result GetStrongPassword(string password)
        {
            return(Zxcvbn.Core.EvaluatePassword(password));
        }

       
    }
}
