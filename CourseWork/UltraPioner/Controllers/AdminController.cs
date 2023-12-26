using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltraPioner.Models;
using UltraPioner.Models.ViewModels;

namespace UltraPioner.Controllers
{
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
		private readonly UltraPionerDBContext _db;
		public AdminController(ILogger<AdminController> logger, UltraPionerDBContext context)
		{
			_logger = logger;
			_db = context;
		}

		public async Task<IActionResult> Index()
		{
			var users = from user in _db.PersonalDatas
					   join role in _db.Roles on user.RoleId equals role.Id
					   orderby user.Name descending


					   select new
					   {
						   UserName = user.Name,
						   UserRole = role.RoleName,
						   UserDiscription = user.Discription,
						   UserLogin = user.Login,
						   UserPassword = user.Password,
						   UserPhone = user.Phone,
						   UserEmail = user.Email

					   };


			var anyUsers = users.ToList()
				.Select(g => new AdminTableModel
				{
					Name = g.UserName,
					RoleName = g.UserRole,
					Discription= g.UserDiscription,
					Login = g.UserLogin,
					Password = g.UserPassword,
					Phone = g.UserPhone,
					Email = g.UserEmail

				})
				.ToList();

			return View(anyUsers);
		}
	}
}
