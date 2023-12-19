namespace UltraPioner.Models.DataBase.Entities
{
	public class Command
	{
		public int CommandID { get; set; }
		public string CommandName { get; set; }

		public ProfilePlayer Profile { get; set; }
	}
}
