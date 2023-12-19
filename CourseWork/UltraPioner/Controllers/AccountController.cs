using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UltraPioner.Models.DataBase.Entities;
using UltraPioner.Models.ViewModel;
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

		//GET: Account/Register
		//public IActionResult Register()
		//{
		//	return View();
		//}

		//// POST: Account/Register
		//[HttpPost]
		//public IActionResult Register(RegisterModel regUser)
		//{
		//	if (!ModelState.IsValid || regUser.Password != regUser.ConfirmPassword)
		//	{
		//		ModelState.AddModelError("isRegFailed", "Passwords incorrect");
		//		return View(regUser);
		//	}
		//	if (_db.Users.Where(u => u.Login == regUser.Login || u.Login == regUser.Email || u.Email == regUser.Login || u.Email == regUser.Email).Any())
		//	{
		//		ModelState.AddModelError("isRegFailed", "Login or Email already taken");
		//		return View(regUser);
		//	}

		//	var user = new PersonalDate();
		//	user.Login = regUser.Login;
		//	user.Email = regUser.Email;
		//	user.Password = regUser.Password.ToHash();
		//	user.RoleID = 1;

		//	_db.Users.Add(user);
		//	_db.SaveChangesAsync().Wait();

		//	return RedirectToAction(nameof(Login));
		//}

		// GET: Account/Login
		public IActionResult Login()
		{
			return View();
		}

		// POST: Account/Login
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel loginUser, bool failed = false)
		{

			var userToLogin = await _db.Users
				.Where(u =>
				u.Login == loginUser.Login)
				.Include(u => u.Role)
				.SingleOrDefaultAsync();
			if (userToLogin is null)
			{
				_logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.Login);
				ModelState.AddModelError("isLoginFailed", "Bad login or email");
				return View(loginUser);
			}
			if (userToLogin?.Password != loginUser.Password.ToHash())
			{
				_logger.LogWarning("At {time} Failed login attempt was made with {login}", DateTime.Now.ToString("u"), loginUser.Login);
				ModelState.AddModelError("isLoginFailed", "Bad password");
				return View(loginUser);
			}

			Authenticate(userToLogin);
			switch (userToLogin.Role.RoleName)
			{
				case "Player":
					return RedirectToAction("Index", "Player");
					break;
			}
			return RedirectToAction("Index", "Home");
		}

		private void Authenticate(PersonalDate user)
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
