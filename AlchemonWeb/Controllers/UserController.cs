using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



using AlchemonWeb.Services;
using AlchemonWeb.Models;

namespace AlchemonWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _uService;

        public UserController(ILogger<UserController> logger, IUserService uService)
        {
            _logger = logger;
            _uService = uService;
        }

        [HttpPost("Registration")]
        public string Registration(string nik, string password, bool role)
        {
            
            return _uService.Registration(nik,password,role);
        }

        [HttpGet("Autification")]
        public string Autification(string nik, string password)
        {
            return _uService.Autification(nik, password);
        }


        
        
        [HttpGet("Roster")]
        public string GitRoster()
        {
            
            return _uService.GetRoster();
        }
        
    }
    
}

