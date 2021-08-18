using DemoJWT.Models;
using JWT.Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoJWT.Tools;
using Microsoft.AspNetCore.Authorization;
using JWT.Dal.Models;

namespace DemoJWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepo _repo;
        private ITokenManager _tm;

        public UserController(IUserRepo repo, ITokenManager tm)
        {
            _repo = repo;
            _tm = tm;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserRegister register)
        {
            if(register is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            Guid id = _repo.Insert(new JWT.Dal.Models.User()
            {
                Email = register.Email,
                Username = register.Username,
                Password = register.Password,
                BirthDate = register.BirthDate
            });


            //Auto connexion
            //UserLogin ul = new UserLogin();

            //User u = _repo.Get(id);

            //ul.Email = u.Email;
            //ul.Password = register.Password;

            //return RedirectToAction("Login", ul);

            return Ok(id);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLogin ul)
        {
            if (ul is null || !ModelState.IsValid) return BadRequest();

            UserComplete uc = _repo.Login(ul.Email, ul.Password).toLocal();

            if(uc is null)
            {
                return Forbid();
            }

            return Ok(_tm.Authenticate(uc));
        }

        [Authorize("user")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [Authorize("admin")]
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_repo.Get(Id));
        }
    }
}
