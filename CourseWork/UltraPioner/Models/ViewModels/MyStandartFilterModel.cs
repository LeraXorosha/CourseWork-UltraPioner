using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using UltraPioner.Models.DataBase.Entities;

namespace UltraPioner.Models.ViewModels
{
    public class MyStandartFilterModel()
    {
		public IEnumerable<Standart> MyStandarts { get; set; }
		public SelectList  StandartName { get; set; }
		public SelectList StandartResult { get; set; }

	}
}
