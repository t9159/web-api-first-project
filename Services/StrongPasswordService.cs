using Entities;
//fix: Repositories isn't used in this file, so the using is removed
using Zxcvbn;

namespace Services
{
    public class StrongPasswordService:IStrongPasswordService
    {
        
        public Result GetStrongPassword(string password)
        {
            return(Zxcvbn.Core.EvaluatePassword(password));
        }

       
    }
}
