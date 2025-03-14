using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordlessAuthApp.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace PasswordlessAuthApp.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class PasswordlessAuthenticationController : ControllerBase
    {
        private readonly IPasswordlessTokenProviderService _passwordlessTokenProvider;
        private readonly IIdentityUserRepository _identityUserRepository; // Corrected the interface name
        private readonly IEmailSender _emailSender;

        public PasswordlessAuthenticationController(IPasswordlessTokenProviderService passwordlessTokenProvider, IIdentityUserRepository identityUserRepository, IEmailSender emailSender)
        {
            _passwordlessTokenProvider = passwordlessTokenProvider;
            _identityUserRepository = identityUserRepository;
            _emailSender = emailSender;
        }

        [HttpPost("request-passwordless-authentication")]
        public async Task<ActionResult> RequestLoginAsync([FromBody] string email)
        {
            var user = await _identityUserRepository.FindByNormalizedEmailAsync(email.ToUpper());
            if (user == null) return BadRequest($"Email: {email} dont have account");

            var token = _passwordlessTokenProvider.GenerateTokenString(user.Id);
            var loginUrl = $"https://api/authentication/login?token={Uri.EscapeDataString(token)}";

            await _emailSender.SendEmailAsync(email, "Log in via link", $"Click the link to log in: <a href='{loginUrl}'>Login</a>");
            return Ok("Login link sent!");
        }

        [HttpGet("login")]
        public async Task<ActionResult> ValidatePasswordlessLoginAsync([FromQuery] string token)
        {
            var userId = _passwordlessTokenProvider.ValidateToken(token);
            if (userId == null) return BadRequest("Invalid or expired token");

            var user = _identityUserRepository.GetAsync(userId.Value);
            var cliams = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var identity = new ClaimsIdentity(cliams, "passwordless");
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principle);
            return Ok("Log in successfull!");
        }
    }
}
