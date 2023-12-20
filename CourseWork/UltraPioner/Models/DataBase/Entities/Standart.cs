namespace UltraPioner.Models.DataBase.Entities
{
	public class Standart
	{
		public int Id { get; set; }
		public string StandartName { get; set; }
		public int StandartResult { get; set; }

		//
		//public int TrainerMagazineID { get; set; }
		//public TrainerMagazine TrainerJurnal { get; set; }

		//ProfilePlayer
		public int  ProfilePlayerId { get; set; }
		public ProfilePlayer Profile { get; set; }
	}
}
