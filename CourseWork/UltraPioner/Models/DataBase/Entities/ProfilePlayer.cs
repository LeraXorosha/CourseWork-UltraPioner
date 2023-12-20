namespace UltraPioner.Models.DataBase.Entities
{
    public class ProfilePlayer
    {
        //ДОБАВИТЬ ФОТО С ПОЛЬЗОВАТЕЛЕМ
        public int Id { get; set; }
        public bool? OnCommand { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string? Grip { get; set; }
        public string? Achievements { get; set; }

        //PersonalDate
        public int PersonalDateId { get; set; }
        public PersonalDate PersonalDate { get; set; }

        //Statistic
        //public int StatisticID { get; set; }
        //public Statistic Statistics { get; set; }

        //Standart
        public int StandartId { get; set; }
        public List<Standart> Standarts { get; set; }

        //Command
        //public int CommandID { get; set; }
        //public Command Command { get; set; }
    }
}
