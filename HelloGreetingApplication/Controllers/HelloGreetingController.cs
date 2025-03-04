using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Hello to GreetingApp API Endpoint";
            responseModel.Data = "Hello World!";
            return Ok(responseModel);

        }
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrationModel userRegistrationModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "user added successfully";
            responseModel.Data = $"First Name : {userRegistrationModel.FirstName} Last Name : {userRegistrationModel.LastName} Email : {userRegistrationModel.Email}";
            return Ok(responseModel);

        }
        [HttpPut]
        public IActionResult Put([FromBody] UserRegistrationModel userRegistrationModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "User updated Successfully";
            responseModel.Data = $"Updated User - First Name : {userRegistrationModel.FirstName} Last Name : {userRegistrationModel.LastName} Email : {userRegistrationModel.Email}";
            return Ok(responseModel);

        }
        [HttpPatch]
        public IActionResult Patch(UpdateRequestModel updateRequestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "LastName updated successfully";
            responseModel.Data = $"Updated User - Last Name : {updateRequestModel.LastName}";
            return Ok(responseModel);
        }
        [HttpDelete]
        public IActionResult Delete(UserRegistrationModel userDeletion)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "User Deleted successfully";
            responseModel.Data = $"User deleted successfully with email : {userDeletion.Email}";
            return Ok(responseModel);
        }
    }
}

        


        
