using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Services
{
    public interface IStrongPasswordService
    {
        public Result GetStrongPassword(string password);
    }
}
