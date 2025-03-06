using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;


namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL

    {
        private readonly ILogger<GreetingBL> _logger;
        private readonly IGreetingRL _greetingRL;
        public GreetingBL(IGreetingRL igreetingRL, ILogger<GreetingBL> logger)
        {
            _greetingRL = igreetingRL;
            _logger = logger;
        }
        //method to get greeting from repo layer
        public string GetGreetingBL()
        {
            return _greetingRL.GetGreetingRL();
        }
        public string GetGreetingBL(GreetUserModel greetingRequest)
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
                return "Hello World";
            }

        }
        public string SaveGreetingBL(SaveGreetingModel greeting)
        {
            try
            {
                _logger.LogInformation("Trying to save the greeting message");
                return _greetingRL.SaveGreetingRL(greeting);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured while saving greeting message to the Database {e.Message}");
                return e.ToString();
            }
        }
        public string GetGreetingByIdBL(GreetByIdModel iD)
        {
            try
            {
                _logger.LogInformation("Trying to get the greeting message by Id");
                return _greetingRL.GetGreetingByIdRL(iD);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured while getting greeting message by Id {e.Message}");
                return e.ToString();
            }
        }
        public List<GreetingEntity> GetAllGreetingsBL()
        {
            try
            {
                _logger.LogInformation("Trying to get all the greeting messages");
                return _greetingRL.RetrieveAllGreetingsRL();

            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured while getting all greeting messages {e.Message}");
                throw new Exception(e.Message);
            }
        }
        public bool UpdateGreetingMessageBL(int id, SaveGreetingModel modifiedGreeting)
        {
            try
            {
                _logger.LogInformation("Trying to update greeting message by id");
                return _greetingRL.UpdateGreetingMessageRL(id, modifiedGreeting);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
    

