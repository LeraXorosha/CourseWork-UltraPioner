namespace UltraPioner.Models.DataBase.Entities
{
	public class Note
	{
		public int Id { get; set; }
		public string NoteName { get; set; }
		public string NoteTitle { get; set; }
		public string NoteDescription { get; set; }

		//
		public int TrainerMagazineId { get; set; }
		public TrainerJurnal TrainerJurnal { get; set; }
	}
}
