using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;
using ModelLayer.Model;
using ModelLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public AccountLoginResponse LoginUserRL(LoginDTO loginDTO);
        public AccountLoginResponse RegisterUserRL(UserRegistrationModel newUser);
    }
}
