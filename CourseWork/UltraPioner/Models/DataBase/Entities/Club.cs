namespace UltraPioner.Models.DataBase.Entities
{
    public class Club
    {

        //ДОБАВИТЬ ФОТО КЛУБА
        public int ClubID { get; set; }
        public string? ClubName { get; set; }
        public string? ColorProfile { get; set; }

        public List<PersonalDate> Users { get; set; }
    }
}
