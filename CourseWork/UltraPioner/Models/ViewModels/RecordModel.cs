using System.ComponentModel.DataAnnotations;
using UltraPioner.Models.DataBase.Entities;
namespace UltraPioner.Models.ViewModels
{
	public class RecordModel
	{
		public int Id{ get; set; }
        public string Name { get; set; }
		public string StandartName { get; set; }
		public int StandartResult { get; set; }
		public string PlayerLogin { get; set; }
		public string TypeStandart { get; set; }
		[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateResult { get; set; }
	
	}
}
