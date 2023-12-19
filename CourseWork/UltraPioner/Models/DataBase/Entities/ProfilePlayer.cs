namespace UltraPioner.Models.DataBase.Entities
{
    public class ProfilePlayer
    {
        //ДОБАВИТЬ ФОТО С ПОЛЬЗОВАТЕЛЕМ
        public int ProfilePlayerID { get; set; }
        public bool? OnCommand { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string? Grip { get; set; }
        public string? Achievements { get; set; }

        //PersonalDate
        public int PersonalDateID { get; set; }
        public PersonalDate PersonalDate { get; set; }

        //Statistic
        //public int StatisticID { get; set; }
        //public Statistic Statistics { get; set; }

        ////Standart
        //public int StandartID { get; set; }
        //public Standart Standarts { get; set; }

        //Command
        //public int CommandID { get; set; }
        //public Command Command { get; set; }
    }
}
