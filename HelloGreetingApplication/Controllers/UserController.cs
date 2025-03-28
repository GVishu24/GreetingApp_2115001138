﻿using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using ModelLayer.Model;

namespace HelloGreetingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogger<UserController> _logger;
        private readonly IUserBL _userBL;
        public UserController(ILogger<UserController> logger, IUserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;

        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Greeting method called");
            ResponseModel<string> response = new ResponseModel<string>
            {

                Data = ""
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(UserRegistrationModel newUser)
        {
            _logger.LogInformation("Post method called to register the user in database");
            var response = _userBL.RegisterUserBL(newUser);
            AccountResponse<AccountLoginResponse> registerResponse = new AccountResponse<AccountLoginResponse>
            {
                Data = new AccountLoginResponse
                {
                    Message = response.Message,
                    Success = response.Success,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Email = response.Email
                }
            };
            return Ok(registerResponse);
        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(LoginDTO loginDTO)
        {
            _logger.LogInformation("Post method called to login the user in database");
            var response = _userBL.LoginUserBL(loginDTO);
            response.Success = true;
            ResponseModel<AccountLoginResponse> loginResponse = new ResponseModel<AccountLoginResponse>
            {
                Data = new AccountLoginResponse
                {
                    Message = response.Message,
                    Success = response.Success,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Email = response.Email,
                    Token = response.Token
                }
            };
            return Ok(loginResponse);
        }
        /// <summary>
        /// Sends password reset email
        /// </summary>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordDTO model)
        {
            _logger.LogInformation($"Received password reset request for email: {model.Email ?? "NULL"}");

            _logger.LogInformation($"Received password reset request for email: {model.Email}");

            var result = await _userBL.ForgetPasswordAsync(model.Email);
            if (result)
                return Ok(new { Message = "Password reset email sent successfully." });

            return BadRequest(new { Message = "Email not found in the system." });
        }

        /// <summary>
        /// Resets password using token
        /// </summary>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            _logger.LogInformation($"Processing password reset request for token: {model.Token}");

            var result = await _userBL.ResetPasswordAsync(model.Token, model.NewPassword);
            if (result)
                return Ok(new { Message = "Password reset successful." });

            return BadRequest(new { Message = "Invalid or expired token." });
        }
    }
}
