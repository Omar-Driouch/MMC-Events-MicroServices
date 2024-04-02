using AuthService.Application.Contracts;
using AuthService.Application.DTOs;
using AuthService.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUser user,IEmailService emailService,IHttpContextAccessor httpContextAccessor)
        {
            this.user = user;
            this._emailService = emailService;
            this._httpContextAccessor = httpContextAccessor;
        }
       

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> UserLogin(LoginUserDTO loginUserDTO)
        {
            var result = await user.LoginUserAsync(loginUserDTO);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> UserRegister(RegisterUserDTO registerUserDTO)
        {
            var result = await user.RegisterUserAsync(registerUserDTO);
            if (result.Flag == true)
            {
                var _expectedVerificationCode = await _emailService.GenerateVerificationCodeAsync();
                var _expectedEmail=registerUserDTO.Email;
                _httpContextAccessor.HttpContext.Session.SetString("ExpectedVerificationCode", _expectedVerificationCode);
                _httpContextAccessor.HttpContext.Session.SetString("ExpectedEmail", _expectedEmail);

                var emailDto = new EmailDto
                {
                    To = registerUserDTO.Email,
                    Subject = "Confirmation Code",
                    Body =$"<h1>Code: <strong>{_expectedVerificationCode}</strong></h1>"
                };
                var sendEmail=  await _emailService.SendEmailAsync(emailDto);
                return Ok(sendEmail);
            }
            return Ok(result);
        }
        [HttpPost("AssignRole")]
        public async Task<ActionResult<RegistrationResponse>> UsersRoles(UserRoleDTO userRoleDTO)
        {
            var result = await user.AssignedRoleAsync(userRoleDTO);
            return Ok(result);
        }
        [HttpPost("EmailVerification")]
        public async Task<IActionResult> EmailVerification(string code)
        {

                var expectedVerificationCode = _httpContextAccessor.HttpContext.Session.GetString("ExpectedVerificationCode");
                if (code== expectedVerificationCode)
                {
                var _expectedEmail = _httpContextAccessor.HttpContext.Session.GetString("ExpectedEmail");
               
                    var verifiedEmailUser = await user.VerifiedUserAsync(_expectedEmail);
                    return Ok(verifiedEmailUser);
                }
                 return BadRequest("Wrong code, Please check your email");

            
        }

    }
}
