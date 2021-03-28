using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class AccountController : Controller
    {
        #region Dependency Injection
        private IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                HttpContext.Session.SetString("userName", userForLoginDto.Email);
                return RedirectToAction("Index", "Home");
            }
            TempData["message"] = result.Message;
            return View(userForLoginDto);
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return RedirectToAction("Login", "Account");
            }

            return BadRequest(result.Message);
        }
        #endregion
    }
}

