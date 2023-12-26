using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Numerics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using UltraPioner.Models;
using UltraPioner.Models.DataBase.Entities;
using UltraPioner.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



namespace UltraPioner.Controllers
{
	[Authorize(Roles = "player")]
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
			var linq = from standart in _db.Standarts
					   join profile in _db.ProfilePlayers on standart.ProfilePlayerId equals profile.Id
					   join player in _db.PersonalDatas on profile.PersonalDateId equals player.Id
					   orderby standart.StandartResult descending


					   select new
					   {
						   standart.StandartName,
						   standart.StandartResult,
						   standart.TypeStandart,
						   PlayerName = player.Name,
						   PlayerLogin = player.Login,

					   };


			var bestRecord = linq.ToList()
				.GroupBy(data => new { data.StandartName, data.TypeStandart })
				.Select(g => new RecordModel()
				{
					Name = g.Key.TypeStandart == "Max" ? g.First().PlayerName : g.OrderBy(x => x.PlayerName).First().PlayerName,
					StandartName = g.Key.TypeStandart == "Max" ? g.First().StandartName : g.OrderBy(x => x.StandartName).First().StandartName,
					StandartResult = g.Key.TypeStandart == "Max" ? (int)g.First().StandartResult : (int)g.OrderBy(x => x.StandartResult).First().StandartResult

				})
				.ToList();

			var userStandardsResults = linq.ToList()

				.Where(result => result.PlayerLogin == User.Identity.Name)
				.GroupBy(data => new { data.StandartName, data.TypeStandart })
				.Select(r => new RecordModel()
				{
					StandartName = r.Key.TypeStandart == "Max" ? r.First().StandartName : r.OrderBy(x => x.StandartName).First().StandartName,
					StandartResult = r.Key.TypeStandart == "Max" ? (int)r.First().StandartResult : (int)r.OrderBy(x => x.StandartResult).First().StandartResult
				})
				.ToList();

			ViewBag.BestRecord = bestRecord;
			ViewBag.UserStandardsResults = userStandardsResults;

			return View();

		}

		public IActionResult Standart(string StandartName)
		{
			var standarts = from standart in _db.Standarts
							join profile in _db.ProfilePlayers on standart.ProfilePlayerId equals profile.Id
							join player in _db.PersonalDatas on profile.PersonalDateId equals player.Id

							select new RecordModel()
							{
								StandartName = standart.StandartName,
								StandartResult = (int)standart.StandartResult,
								Name = player.Name

							};

						

			if (!String.IsNullOrEmpty(StandartName) && StandartName != "Все")
			{
				standarts = standarts.Where(s => s.StandartName == StandartName);
			}

			ViewData["StandartList"] = new SelectList(_db.Standarts.Select(x => x.StandartName).Distinct());

			return View(standarts.ToList());
		}
    }
}