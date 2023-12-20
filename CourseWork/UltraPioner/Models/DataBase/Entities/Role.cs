namespace UltraPioner.Models.DataBase.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // User
        public List<PersonalData> Users { get; set; }
    }
}
