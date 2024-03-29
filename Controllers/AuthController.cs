﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using InnoGotchi_backend.Services.Abstract;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using InnoGotchi_backend.Models.Dto;
using InnoGotchi_backend.Models.Entity;
using InnoGotchi_backend.Services.LoggerService.Abstract;

namespace InnoGotchi_backend.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authorizationService;
        private readonly IUserService _userService;
        private readonly ILoggerManager _logger;

        
        private readonly IMapper _mapper;
        public AuthController(IAuthenticationService authorizationService,IMapper mapper, IUserService userService,ILoggerManager logger)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]   
        public async Task<IActionResult> Login(UserDto dto)
        {
            bool isUserValid = await _authorizationService.ValidateUser(dto.Password, dto.Email);

            //user validation
            if (!isUserValid)
            {
                _logger.LogInfo($"Wrong password. User email = {dto.Email}, wrong password = {dto.Password}");
                return Unauthorized("Wrong password");
            }

            //create JWT token
            string token = await _authorizationService.CreateToken();

            //create refresh token
            RefreshToken refreshToken = _authorizationService.CreateRefreshToken();

            //set refresh token to responce header and to user database
            //await SetRefreshToken(refreshToken,dto.Email);

            //send to client jwt token
            return Ok(token);
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult<string>> RefreshToken(string refreshToken)
        {
            string? email = User.FindFirst(ClaimTypes.Email)?.Value;

            //get current user
            User currentUser = await _userService.GetUser(email);

            //check if old refresh token is valid
            if (!currentUser.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("invalid refresh token");
            }
            else if (currentUser.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expires");
            }
            
            //create jwt token
            string token = await _authorizationService.CreateToken();

            //create new refresh token
            RefreshToken newRefreshToken = _authorizationService.CreateRefreshToken();

            //set refresh token to current user(update database)
            //await SetRefreshToken(newRefreshToken, User.FindFirst(ClaimTypes.Email)?.Value);

            //setd jwt token
            return Ok(token);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            User currentUser = await _userService.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            return Ok(JsonSerializer.Serialize(_mapper.Map<UserDto>(currentUser)));
        }

        private async Task SetRefreshToken(RefreshToken refreshToken,string email)
        {
            //set refresh token to database
            //await _userService.SetRefreshTokenToUser(refreshToken, email);

            //create cookie optons
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };

            //set refresh token to response headers
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        }
    }
}
