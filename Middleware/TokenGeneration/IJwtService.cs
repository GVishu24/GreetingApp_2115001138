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

    }
}
