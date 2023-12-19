namespace UltraPioner.Models.DataBase.Entities
{
	public class TrainerMagazine
	{
		public int TrainerMagazineID { get; set; }
		//принадлежность
		public int PersonalDateID { get; set; }
		public PersonalDate PersonalDate { get; set; }

		//ProfilePlayer
		public int ProfilePlayerID { get; set; }
		public ProfilePlayer ProfilePlayer { get; set; }
	}
}
