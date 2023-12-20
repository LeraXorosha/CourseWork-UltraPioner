namespace UltraPioner.Models.DataBase.Entities
{
	public class TrainerJurnal
	{
		public int Id { get; set; }
		//принадлежность
		public int PersonalDataId { get; set; }
		public PersonalData PersonalData { get; set; }

		//ProfilePlayer
		public int ProfilePlayerId { get; set; }
		public ProfilePlayer ProfilePlayer { get; set; }
	}
}
