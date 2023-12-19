using System.Data;

namespace UltraPioner.Models.DataBase.Entities
{
    public class PersonalDate
    {
        public int PersonalDateID { get; set; }
        public string Name { get; set; }
        public DateTime DateBorn { get; set; }
        public string Discription { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }


        //Role
        public int RoleID { get; set; }
        public Role Role { get; set; }

        //Club
        public int ClubID { get; set; }
        public Club Club { get; set; }

        //Profile
        public ProfilePlayer Profile { get; set; }
    }
}
