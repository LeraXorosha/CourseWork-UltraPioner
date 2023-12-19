namespace UltraPioner.Models.DataBase.Entities
{
	public class Standart
	{
		public int StandartID { get; set; }
		public string StandartName { get; set; }
		public int StandartResult { get; set; }

		//
		public int TrainerMagazineID { get; set; }
		public TrainerMagazine TrainerMagazine { get; set; }
	}
}
