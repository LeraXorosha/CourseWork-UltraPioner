namespace UltraPioner.Models.DataBase.Entities
{
	public class Event
	{
		public int Id { get; set; }
		public string EventName { get; set; }
		public string MeetingPlace { get; set; }
		public string MeetingTime { get; set; }

		//ответственный
		public int PersonalDateId { get; set; }
		public PersonalDate personalDate { get; set; }

	}
}
