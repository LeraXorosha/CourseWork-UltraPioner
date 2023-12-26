using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UltraPioner.Models.DataBase.Entities;
using UltraPioner.Models.ViewModels;
using UltraPioner.Models;
using Microsoft.EntityFrameworkCore;
using UltraPioner.Extensions;

namespace UltraPioner.Controllers
{
    public class AccountController : Controller
    {
		private readonly ILogger<AccountController> _logger;
		private readonly UltraPionerDBContext _db;

		public AccountController(ILogger<AccountController> logger, UltraPionerDBContext context)
		{
			_logger = logger;
			_db = context;
		}
		// GET: Account/Login
		public IActionResult Login()
		{
			return View();
		}

		// POST: Account/Login
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel loginUser, bool failed = false)
		{

			var userToLogin = await _db.PersonalDatas
				.Where(u =>
				u.Login == loginUser.Login)
				.Include(u => u.Role)
				.SingleOrDefaultAsync();
			if (userToLogin is null)
			{
				_logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.Login);
				ModelState.AddModelError("isLoginFailed", "Неверный логин");
				return View(loginUser);
			}
			if (userToLogin?.Password != loginUser.Password.ToHash())
			{
				_logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.Login);
				ModelState.AddModelError("isLoginFailed", "Неверный пароль");
				return View(loginUser);
			}

			Authenticate(userToLogin);
			switch (userToLogin.Role.RoleName)
			{
				case "player":
					return RedirectToAction("Index", "Player");
					break;
                case "admin":
                    return RedirectToAction("Index", "Admin");
                    break;
            }
			return RedirectToAction("Index", "Home");
		}

		private void Authenticate(PersonalData user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName)
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id)).Wait();
		}

		[Authorize]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
			return RedirectToAction(nameof(Login), "Account");
		}
	}
}
