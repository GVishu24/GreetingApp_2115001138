using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.TokenGeneration
{
    public interface IJwtService
    {
        string GenerateToken(string email, string firstName, string lastName);
        bool ValidateToken(string token, out string email);
        string GenerateResetPasswordToken(string email);



    }
}
