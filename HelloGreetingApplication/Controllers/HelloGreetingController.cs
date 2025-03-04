using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

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
            catch (Exception ex) {
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
        public IActionResult Post([FromBody] GreetingRequestModel greetingRequest)
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
    }
}

        


        
