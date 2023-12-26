using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltraPioner.Models;

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
			return View();
		}
	}
}
