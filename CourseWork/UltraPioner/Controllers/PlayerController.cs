using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UltraPioner.Models;

namespace UltraPioner.Controllers
{
	public class PlayerController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UltraPionerDBContext _db;
		public PlayerController(ILogger<HomeController> logger, UltraPionerDBContext context)
		{
			_logger = logger;
			_db = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _db.Users.Include(u => u.Role).ToListAsync());
		}
	}
}
