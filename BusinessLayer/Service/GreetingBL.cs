using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _igreetingRL;
        public GreetingBL(IGreetingRL igreetingRL)
        {
            _igreetingRL = igreetingRL;
        }
        //method to get greeting from repo layer
        public string GetGreetingBL()
        {
            return _igreetingRL.GetGreetingRL();
        }
    }
}
