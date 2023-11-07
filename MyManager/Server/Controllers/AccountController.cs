using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Account;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class AccountController :Controller
    {
        private readonly IUserAccount account;

        public AccountController(IUserAccount account)
        {
            this.account = account;
        }


        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var result = await account.Login(login);
            if (result.Status == false)
            {
                return BadRequest(result);
                
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        [Route("account/register")]

        public async Task<ActionResult> Register(Register user)
        {

            var result = await account.Register(user);

            if (result.status == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);

            }
        }

        [HttpPost]
        [Route("account/forgetpassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordEmail details)
        {
            ForgetPasswordView forgetPasswordView = new ForgetPasswordView();
            var user = await account.ForgetPasswordUserCheck(details);

            if (user != null)
            {
                await account.GenerateForgetPasswordTokenAsync(user);
                forgetPasswordView.Status = true;
                forgetPasswordView.Type = "alert-success";
                forgetPasswordView.Message = "Please check your Email to continue.";
                return Ok(forgetPasswordView);
            }
            forgetPasswordView.Status = false;
            forgetPasswordView.Type = "alert-danger";
            forgetPasswordView.Message = "Invalid Email";
            return BadRequest(forgetPasswordView);
        }

        //[HttpGet("forget-password")]
        //public IActionResult PasswordReset(string uid, string token)
        //{

        //    return Ok("Enter your new pasword");
        //}

        [HttpGet("confirm-email")]

        public async Task<IActionResult> ConfirmEmail(string uid, string token)
        {
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await account.ConfirmEmailAsync(uid, token);
            }
            return Ok("Email confirmed you can login !!");
        }

        [HttpPut]
        [Route("account/enternewpassword")]
        public async Task<IActionResult> PasswordReset(ForgetPasswordCred details)
        {
            details.Token = details.Token.Replace(' ', '+');
            var result = await account.ResetPassword(details);

            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("account/changepassword")]

        public async Task<ActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {

            var result = await account.changePassword(changePasswordModel);

            if (result.Status == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);

            }
        }

        [HttpGet]
        [Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await account.Logout();
            return Ok();
        

        }
    }
}
