namespace UltraPioner.Models.DataBase.Entities
{
    public class Club
    {

        //ДОБАВИТЬ ФОТО КЛУБА
        public int Id { get; set; }
        public string? ClubName { get; set; }
        public string? ColorProfile { get; set; }

        public List<PersonalData> Users { get; set; }
    }
}
