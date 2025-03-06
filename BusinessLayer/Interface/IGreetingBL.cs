using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreetingBL();
        string GetGreetingBL(GreetUserModel greetingRequest);
        public string SaveGreetingBL(SaveGreetingModel greeting);
        public string GetGreetingByIdBL(GreetByIdModel iD);
        public List<GreetingEntity> GetAllGreetingsBL();

    }
}
