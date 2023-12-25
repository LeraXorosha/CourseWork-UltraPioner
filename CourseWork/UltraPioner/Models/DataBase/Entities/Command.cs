using System.Numerics;

namespace UltraPioner.Models.DataBase.Entities
{
	public class Command
	{
		public int Id { get; set; }
		public string CommandName { get; set; }

        public string Coach { get; set; }
        public ProfilePlayer Profile { get; set; }

    }

}
