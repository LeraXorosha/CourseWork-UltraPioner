using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UltraPioner.Models;

namespace UltraPioner.Controllers
{
	[Authorize(Roles = "admin,player")]
	public class PlayerController : Controller
	{
		private readonly ILogger<PlayerController> _logger;
		private readonly UltraPionerDBContext _db;
		public PlayerController(ILogger<PlayerController> logger, UltraPionerDBContext context)
		{
			_logger = logger;
			_db = context;
		}

		public async Task<IActionResult> Index()
		{
			var model = await _db.Users
				.Include(u => u.Role)
				.Include(u => u.Profile)
					.ThenInclude(p => p.Standarts)
				//.GroupBy(u => u.Profile.Standarts)
				//.OrderBy(p => )
				.Where(u => u.Role.RoleName == "player")

				.ToListAsync();

			var model2 = await _db.Standarts
				.Include(s => s.Profile)
					.ThenInclude(p => p.PersonalData)
						.ThenInclude(p => p.Role)
				//.GroupBy(u => u.Profile.Standarts)
				//.OrderBy(p => )
				.Where(s => s.Profile.PersonalData.Role.RoleName == "player")
				.OrderBy(s => s.StandartName)
				.GroupBy(s => s.StandartName)
				.ToListAsync();

			return View(model2);
		}

    }
}
