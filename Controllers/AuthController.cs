using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Application.Data;
using Application.Data.Entities;
using Application.Services;
using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DBContext _context;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, DBContext context, ITokenService tokenService, IAuthService authService)
        {
            _config = config;
            _context = context;
            _tokenService = tokenService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel Request)
        {
            // Validate the user using data annotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email address is already in use
            if (_context.Users.Any(u => u.Email == Request.Email))
            {
                return Conflict(new { message = "A user with this email address already exists"});
            }

            // Create a new user and add user to database
            await _authService.Register(Request);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel Request)
        {
            try
            {
                // Validate the user using data annotations
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Retrieve the user from the database based on the email address
                User user = _authService.Login(Request.Email, Request.Password);
                
                // Create a new JWT access/refresh token with a unique ID, email address, and expiration date
                object AccessToken = _tokenService.GenerateAccessToken(user);
                object RefreshToken = await _tokenService.GenerateRefeshToken(user);

                // Return the token to the client
                return Ok(new
                    {
                        AccessToken,
                        RefreshToken
                    }
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle the exception by returning an unauthorized response
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle other exceptions by returning a bad request response with the error message
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenModel Request)
        {
            // Refresh the new access token
            object AccessToken = _tokenService.RefreshAccessToken(Request.RefreshToken);

            // Return the new token to the client
            return Ok(AccessToken);
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutModel Request)
        {
            // Revoke the new refesh token
            _tokenService.RevokeRefreshToken(Request.RefreshToken);

            // Return the new token to the client
            return Ok(new { message = "User logout successfully" });
        }
    }   
}

