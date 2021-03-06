﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UltWolfScheduleAPI.Exceptions;
using UltWolfScheduleAPI.Models; 
using UltWolfScheduleAPI.Services.Abstracts.Interfaces;

namespace UltWolfScheduleAPI.Controllers
{
 
        [Authorize]
        [ApiController]
        [Route("api/[controller]")]
        public class UsersController : ControllerBase
        {

        private IUserService _userService;
        private IMapper _autoMapper;
        private AppSettings _appSettings;
            public UsersController(
                IUserService userService, 
                IOptions<AppSettings> appSettings,
                IMapper autoMapper)
            {
                _userService = userService;
            _autoMapper = autoMapper;
                _appSettings = appSettings.Value;
            }

            [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody]User userDto)
            {
                var user = _userService.Authenticate(userDto.Username, userDto.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                 
                return Ok(new
                {
                    Id = user.Id,
                    Username = user.Username, 
                    Token = tokenString
                });
            }

            [AllowAnonymous]
            [HttpPost("register")]
            public IActionResult Register([FromBody]User  userDto )
            { 
                var user = _autoMapper.Map<User>(userDto); 
                try
                { 
                    _userService.Create(user, userDto.Password);
                    return Ok();
                }
                catch (AppException ex)
                { 
                    return BadRequest(new { message = ex.Message });
                }
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                var users = _userService.GetAll();
                var userDtos = this._autoMapper.Map<IList<User>>(users);
                return Ok(userDtos);
            }

        [Authorize]
            [HttpGet("current")]
            public IActionResult GetCurrentUser()
        {
            return Ok(User.Identity.Name);
        }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var user = _userService.GetById(id);
                var userDto = _autoMapper.Map<User>(user);
                return Ok(userDto);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody]User userDto)
            {
                // map dto to entity and set id
                var user = _autoMapper.Map<User>(userDto);
                user.Id = id;

                try
                {
                    // save 
                    _userService.Update(user, userDto.Password);
                    return Ok();
                }
                catch (AppException ex)
                {
                    // return error message if there was an exception
                    return BadRequest(new { message = ex.Message });
                }
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _userService.Delete(id);
                return Ok();
            }
        }
}