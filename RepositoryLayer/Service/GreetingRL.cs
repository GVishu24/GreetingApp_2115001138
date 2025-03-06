﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        private readonly GreetingAppContext _dbContext;
        private readonly ILogger<GreetingRL> _logger;

        public GreetingRL(GreetingAppContext dbContext, ILogger<GreetingRL> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private string GreetingMsg = "Hello World!";

        //Method to get the greeting message
        private string GetMessage()
        {
            return GreetingMsg;
        }
        public string GetGreetingRL()
        {
            return GetMessage();
        }

        // Method to save greetings in greeting entity
        //public GreetingEntity SaveGreetingRL(GreetingEntity greetingEntity)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Starting the process of Saving the greeting to database");
        //       //key ID is saved and is reflected to the object so we can access it 
        //        _logger.LogInformation("Greeting saved to database successfully");
        //        int id = greetingEntity.Id;
        //        GreetingEntity greetingResponse = new GreetingEntity();
        //        greetingResponse.Id = id;
        //        greetingResponse.GreetingMsg = greetingEntity.GreetingMsg;
        //        _dbContext.GreetingEntity.Add(greetingResponse);
        //        _dbContext.SaveChanges();
        //        return greetingResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error occured while saving the greeting to database : {ex.Message}");
        //        GreetingEntity greetingResponse = new GreetingEntity();

        //        greetingResponse.GreetingMsg = ex.Message;
        //        greetingResponse.Id = -1;
        //        return greetingResponse;
        //    }
        //}

        public string SaveGreetingRL(SaveGreetingModel greeting)
        {
            _logger.LogInformation("Greetings from repository layer using SaveGreeting to save greetings in our database");
            try
            {
                _logger.LogInformation("Trying to save greeting message to the Database");
                GreetingEntity newGreeting = new GreetingEntity()
                {
                    GreetingMessage = greeting.GreetingMessage
                };
                _dbContext.GreetingEntities.Add(newGreeting);
                _dbContext.SaveChanges();
                return greeting.GreetingMessage;

            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured while saving greeting message to the Database {e.Message}");
                return $"There's some error occured while trying to save greeting message to the Database {e.Message}";
            }
        }
    }
}
