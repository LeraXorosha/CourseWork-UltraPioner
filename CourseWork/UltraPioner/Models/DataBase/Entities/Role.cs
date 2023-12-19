namespace UltraPioner.Models.DataBase.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        // User
        public List<PersonalDate> Users { get; set; }
    }
}
