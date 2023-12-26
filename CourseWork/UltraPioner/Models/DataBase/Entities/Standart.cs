namespace UltraPioner.Models.DataBase.Entities
{
	public class Standart
	{
		public int Id { get; set; }
		public string StandartName { get; set; }
		public double StandartResult { get; set; }
		public DateTime DateResult { get; set; }
		public string TypeStandart { get; set; }

		//ProfilePlayer
		public int  ProfilePlayerId { get; set; }
		public ProfilePlayer Profile { get; set; }

	}
}
