namespace UltraPioner.Models.DataBase.Entities
{
	public class Note
	{
		public int NoteID { get; set; }
		public string NoteName { get; set; }
		public string NoteTitle { get; set; }
		public string NoteDescription { get; set; }

		//
		public int TrainerMagazineID { get; set; }
		public TrainerMagazine TrainerMagazine { get; set; }
	}
}
