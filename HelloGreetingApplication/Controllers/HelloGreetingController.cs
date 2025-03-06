using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly IGreetingBL _igreetingBL;
        private readonly ILogger<HelloGreetingController> _logger;
        public HelloGreetingController(IGreetingBL greetingBL, ILogger<HelloGreetingController> logger)
        {
            _igreetingBL = greetingBL;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Starting process of getting Greetings");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                string greetingMsg = _igreetingBL.GetGreetingBL();
                responseModel.Success = true;
                responseModel.Message = "Greetings";
                responseModel.Data = greetingMsg;
                _logger.LogInformation("Greeting successfull");
                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "oops error occured";
                responseModel.Data = ex.Message;
                _logger.LogInformation("Error occured while getting greeting");
                return BadRequest(responseModel);
            }

        }
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrationModel userRegistrationModel)
        {
            try
            {
                _logger.LogInformation("starting process of registering user");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = true;
                responseModel.Message = "user added successfully";
                responseModel.Data = $"First Name : {userRegistrationModel.FirstName} Last Name : {userRegistrationModel.LastName} Email : {userRegistrationModel.Email}";
                _logger.LogInformation("user added successfully");
                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "User registration failed";
                responseModel.Data = ex.Message;
                _logger.LogInformation($"error occured while registering user, Error: {ex.Message}");
                return BadRequest(responseModel);
            }


        }
        [HttpPut]
        public IActionResult Put([FromBody] UserRegistrationModel userRegistrationModel)
        {
            try
            {
                _logger.LogInformation($"Starting updating process for User with Email : {userRegistrationModel.Email}");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = true;
                responseModel.Message = "User updated Successfully";
                responseModel.Data = $"Updated User - First Name : {userRegistrationModel.FirstName} Last Name : {userRegistrationModel.LastName} Email : {userRegistrationModel.Email}";
                _logger.LogInformation($"User Updated succesfully new user with email : {userRegistrationModel.Email}");
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "Error occured while updating user";
                responseModel.Data = ex.Message;
                _logger.LogError($"Error occured while updating user with Email : {userRegistrationModel.Email}");
                return BadRequest(responseModel);

            }

        }
        [HttpPatch]
        public IActionResult Patch(UpdateRequestModel updateRequestModel)
        {
            try
            {
                _logger.LogInformation("Starting process of updating value for user");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = true;
                responseModel.Message = "LastName updated successfully";
                responseModel.Data = $"Updated User - Last Name : {updateRequestModel.LastName}";
                _logger.LogInformation("Updation Successfull");
                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "Error occured while updating lastname";
                responseModel.Data = ex.Message;
                _logger.LogError($"Error occured while updating value Error : {ex.Message}");
                return BadRequest(responseModel);
            }

        }
        [HttpDelete]
        public IActionResult Delete(UserRegistrationModel userDeletion)
        {
            try
            {
                _logger.LogInformation("Starting process of deleting user");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = true;
                responseModel.Message = "User Deleted successfully";
                responseModel.Data = $"User deleted successfully with email : {userDeletion.Email}";
                userDeletion.FirstName = string.Empty;
                userDeletion.LastName = string.Empty;
                userDeletion.Email = string.Empty;

                userDeletion.Password = string.Empty;
                _logger.LogInformation("user deletion successfull");

                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "Error occured while deleting user";
                responseModel.Data = ex.Message;
                _logger.LogInformation($"Error occured while deletion Error = {ex.Message}");
                return BadRequest(responseModel);
            }

        }
        [HttpPost]
        [Route("GetGreeting")]
        public IActionResult Post([FromBody] GreetUserModel greetingRequest)
        {
            try
            {
                _logger.LogInformation("starting process of getting greeting request");
                ResponseModel<string> responseModel = new ResponseModel<string>();
                string greetingMsg = _igreetingBL.GetGreetingBL(greetingRequest);
                responseModel.Success = true;
                responseModel.Message = "Greetings";
                responseModel.Data = greetingMsg;
                _logger.LogInformation("Greeting successfull");
                return Ok(responseModel);

            }
            catch (Exception ex)
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                responseModel.Success = false;
                responseModel.Message = "Greeting failed";
                responseModel.Data = ex.Message;
                _logger.LogInformation($"error occured while getting greeting {ex.Message}");
                return BadRequest(responseModel);
            }

        }
        //[HttpPost]
        //[Route("SaveGreeting")]
        //public IActionResult SaveGreeting(GreetUserModel saveGreetingRequest)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Starting process of saving greeting according to user");
        //        ResponseModel<string> responseDB = _igreetingBL.SavegreetingBL(saveGreetingRequest);
        //        _logger.LogInformation("Greeting Saved successfully");
        //        return Ok(responseDB);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error occured while saving greeting : {ex.Message}");
        //        ResponseModel<string> responseDB = _igreetingBL.SavegreetingBL(saveGreetingRequest);

        //        return BadRequest(responseDB);
        //    }
        //}
        [HttpPost]
        [Route("SaveGreetings")]
        public IActionResult Post(SaveGreetingModel greeting)
        {
            _logger.LogInformation("Post method called to save the greeting message");
            try
            {
                _logger.LogInformation("Trying to save the greeting message");
                ResponseModel<string> response = new ResponseModel<string>();
                string result = _igreetingBL.SaveGreetingBL(greeting);
                response.Message = "Greeting message saved successfully";
                response.Success = true;
                response.Data = $"The greeting message saved in the Database is: {result}";
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured in Save Greeting Method {e.Message}");
                ResponseModel<string> response = new ResponseModel<string>();
                response.Message = "There is some error while trying to save the greeting message";
                response.Success = false;
                response.Data = e.Message;
                return BadRequest(response);
            }
        }
        [HttpPost]
        [Route("GetGreetingById")]
        public IActionResult Post(GreetByIdModel iD)
        {
            try
            {
                _logger.LogInformation("Get Greeting By Id method called");
                ResponseModel<string> response = new ResponseModel<string>();
                string greeting = _igreetingBL.GetGreetingByIdBL(iD);
                response.Message = "Get method successfully applied";
                response.Success = true;
                response.Data = greeting;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured in GetGreeting {e.Message}");
                ResponseModel<string> response = new ResponseModel<string>();
                response.Message = "Get method failed";
                response.Success = false;
                response.Data = e.Message;
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("RetrieveAllGreetings")]
        public IActionResult GetGreetings()
        {
            try
            {
                _logger.LogInformation("Get Greetings method called");
                ResponseModel<List<GreetingEntity>> response = new ResponseModel<List<GreetingEntity>>();
                var greetings = _igreetingBL.GetAllGreetingsBL();
                response.Message = "Get method successfully applied";
                response.Success = true;
                response.Data = greetings;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception Occured in GetGreetings {e.Message}");
                ResponseModel<string> response = new ResponseModel<string>();
                response.Message = "Get method failed";
                response.Success = false;
                response.Data = e.Message;
                return BadRequest(response);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutGreetings(int id, [FromBody] SaveGreetingModel modifiedGreeting)
        {
            try
            {
                _logger.LogInformation($"Update Greetings method called for ID: {id}");
                bool result = _igreetingBL.UpdateGreetingMessageBL(id, modifiedGreeting);
                if (result)
                {
                    ResponseModel<string> response = new ResponseModel<string>();
                    response.Success = true;
                    response.Message = "Greeting is successfully updated";
                    response.Data = $"{modifiedGreeting.GreetingMessage}";
                    
                    return Ok(response);
                }
                else
                {
                    ResponseModel<string> response = new ResponseModel<string>();
                    response.Success = false;
                    response.Message = "No greeting message is present with that id";
                    response.Data = $"please create a new greeting message before modifying";
                    return NotFound(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occurred in Update Greetings: {e.Message}");
                ResponseModel<string> response = new ResponseModel<string>();
                response.Success = false;
                response.Message = $"an error occured while trying to modify the greeting {e.Message}";
                response.Data = $"Not able to update greeting currently";
                return BadRequest(response);
            }
        }

    }
}

        


        
