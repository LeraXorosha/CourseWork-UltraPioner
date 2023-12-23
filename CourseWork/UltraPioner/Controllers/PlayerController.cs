using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Numerics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using UltraPioner.Models;
using UltraPioner.Models.DataBase.Entities;
using UltraPioner.Models.ViewModels;


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
			var linq = from standart in _db.Standarts
					   join profile in _db.ProfilePlayers on standart.ProfilePlayerId equals profile.Id
					   join player in _db.PersonalDatas on profile.PersonalDateId equals player.Id
					   orderby standart.StandartResult descending

					   select new
					   {
						   standart.StandartName,
						   standart.StandartResult,
						   PlayerName = player.Name,
						   PlayerLogin = player.Login
					   };


			var bestRecord = linq.ToList()
				.GroupBy(data => data.StandartName)
				.Select(g => new RecordModel()
				{

					Name = g.First().PlayerName,
					StandartName = g.First().StandartName,
					StandartResult = (int)g.First().StandartResult,

				})
				.ToList();

			var userStandardsResults = linq.ToList()
				.Where(result => result.PlayerLogin == User.Identity.Name)
				.Select(r => new RecordModel()
				{
					StandartName = r.StandartName,
					StandartResult = (int)r.StandartResult
				})
				.ToList();

			ViewBag.BestRecord = bestRecord;
			ViewBag.UserStandardsResults = userStandardsResults;

			return View();

		}

    }
}
