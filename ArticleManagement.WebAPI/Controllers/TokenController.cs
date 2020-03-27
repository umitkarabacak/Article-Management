using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ArticleManagement.Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ArticleManagement.WebAPI.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private const string Username = "umit";
        private const string Password = "123456";
        private IConfiguration Configuration { get; }

        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // POST Token
        [AllowAnonymous]
        [HttpPost]
        [Route("/token")]
        public IActionResult Post([FromBody] RequestLogin requestLogin)
        {
            if (!Username.Equals(requestLogin.Username) || !Password.Equals(requestLogin.Password))
            {
                return Unauthorized($"Your request name is {requestLogin.Username}, username or password is wrong!");
            }

            return Ok(BuildJwtToken());
        }

        private string BuildJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = Configuration["JwtToken:Issuer"];
            var audience = Configuration["JwtToken:Audience"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(Configuration["JwtToken:TokenExpiry"]));
            var token = new JwtSecurityToken(issuer,
                audience,
                expires: jwtValidity,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}