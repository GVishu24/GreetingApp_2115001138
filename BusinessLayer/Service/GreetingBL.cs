using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
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
        public string GetGreetingBL(GreetingRequestModel greetingRequest)
        {
            if (!string.IsNullOrEmpty(greetingRequest.FirstName) && !string.IsNullOrEmpty(greetingRequest.LastName))
            {
                return $"Hello {greetingRequest.FirstName} {greetingRequest.LastName}";
            }
            else if (!string.IsNullOrEmpty(greetingRequest.FirstName))
            {
                return $"Hello {greetingRequest.FirstName}";
            }
            else if (!string.IsNullOrEmpty(greetingRequest.LastName))
            {
                return $"Hello {greetingRequest.LastName}";
            }
            else
            {
                return "Hello";
            }
        }

    }
}
    

