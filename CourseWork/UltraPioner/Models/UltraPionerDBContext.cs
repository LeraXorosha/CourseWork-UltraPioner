using Microsoft.EntityFrameworkCore;
using UltraPioner.Extensions;
using UltraPioner.Models.DataBase.Entities;

namespace UltraPioner.Models
{
    public class UltraPionerDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<ProfilePlayer> ProfilePlayers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Standart> Standarts { get; set; }

        public UltraPionerDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddInitialData();
        }
    }

    public static class ModelBuilderExtensions
    {
        //метод расширения для сокращения размеров кода
        public static ModelBuilder AddInitialData(this ModelBuilder modelBuilder)
        {

            List<Role> roles = new(){
                new Role { Id = 1, RoleName = "admin" },
                new Role { Id = 2, RoleName = "player" },
                new Role { Id = 3, RoleName = "coach" },
                new Role { Id = 5, RoleName = "scout" }
            };

            List<PersonalData> users = new(){
                new PersonalData { Id = 1, Name = "Красоткин Антон", DateBorn = new DateTime(1997-05-20) , Discription = "Варатарь",
                    Email = "KrasotkinA@local.dom", Phone = "8(908)345-34-34", RoleId = 2, ClubId = 1, Login = "KrasotkinA", Password = "1".ToHash()},

                new PersonalData { Id = 2, Name = "Валерий Петрович", DateBorn = new DateTime(1967-02-13) , Discription = "Администратор клуба",
                    Email = "admin@local.dom", Phone = "8(908)353-32-94", RoleId = 1, ClubId = 1, Login = "Admin", Password = "admin".ToHash()},

                new PersonalData { Id = 3, Name = "Мёрфи Тревор", DateBorn = new DateTime(1995-07-17) , Discription = "Защитник",
                    Email = "MerfiT@local.dom", Phone = "8(908)353-32-94", RoleId = 2, ClubId = 1, Login = "MerfiT", Password = "1".ToHash()},

                new PersonalData { Id = 4, Name = "Маркович Макс", DateBorn = new DateTime(1981-03-01) , Discription = "Видеотренер-аналитик",
                    Email = "MarcovichM@local.dom", Phone = "8(923)443-62-94", RoleId = 3, ClubId = 1, Login = "MarcovichM", Password = "1".ToHash()},

                new PersonalData { Id = 5, Name = "Субботин Иван", DateBorn = new DateTime(1985-07-27) , Discription = "Нападающий",
                    Email = "SubbaI@local.dom", Phone = "8(908)353-32-94", RoleId = 2, ClubId = 1, Login = "SubbaI", Password = "1".ToHash()}
            };

            List<ProfilePlayer> players = new(){
                new ProfilePlayer { Id = 1, PersonalDateId = 1, Weight = 81, Height = 182, Grip = "Левый", OnCommand = false, Achievements = "Обладатель Кубка Харламова (2016). Бронзовый призёр молодёжного чемпионат мира (2017)." },
                new ProfilePlayer {Id = 2, PersonalDateId = 3, Weight = 82, Height = 179, Grip = "Левый", OnCommand = false,  Achievements = "Бронзовый призер чемпионата России и КХЛ (2021)."},
                new ProfilePlayer {Id = 3, PersonalDateId = 5, Weight = 94, Height = 184, Grip = "Правый", OnCommand = false,  Achievements = "Бронзовый призер чемпионата России и КХЛ (2021)."}
            };

            List<Club> clubs = new(){
                new Club { Id = 1, ClubName = "Сибирь", ColorProfile = "blue"},
                new Club { Id = 2, ClubName = "Авангард", ColorProfile = "red"},
                new Club { Id = 3, ClubName = "Амур", ColorProfile = "orange" }
            };

            List<Standart> standarts = new()
            {
                new Standart {Id = 1, StandartName = "Отжимания", StandartResult = 56, DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},
                new Standart {Id = 2, StandartName = "Пресс", StandartResult = 64, DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},
                new Standart {Id = 3, StandartName = "Подтягивание", StandartResult = 32, DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},
                new Standart {Id = 4, StandartName = "Кросс 100 м/c", StandartResult = 10.9 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Min"},
                new Standart {Id = 28, StandartName = "Кросс 300 м/c", StandartResult = 37.4 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Min"},
                new Standart { Id = 29, StandartName = "Кросс 500 м/c", StandartResult = 61.4, DateResult = new DateTime(2023 - 12 - 21), ProfilePlayerId = 1, TypeStandart = "Min" },
                new Standart {Id = 30, StandartName = "% ОФП", StandartResult = 100 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},
                new Standart {Id = 31, StandartName = "% силовых приемов", StandartResult = 76 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},
                new Standart {Id = 32, StandartName = "% выигранных сбросов", StandartResult = 84 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 1, TypeStandart = "Max"},

                new Standart {Id = 5, StandartName = "Отжимания", StandartResult = 89, DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 6, StandartName = "Пресс", StandartResult = 54,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 7, StandartName = "Подтягивание", StandartResult = 12,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Max" },
                new Standart {Id = 8, StandartName = "Кросс 100 м/c", StandartResult = 12.7 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Min"},

                new Standart {Id = 13, StandartName = "Отжимания", StandartResult = 189,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 14, StandartName = "Пресс", StandartResult = 195,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 15, StandartName = "Подтягивание", StandartResult = 152,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 16, StandartName = "Кросс 100 м/c", StandartResult = 114.4 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Min"},
                new Standart {Id = 23, StandartName = "Кросс 300 м/c", StandartResult = 33.2 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Min"},
                new Standart { Id = 24, StandartName = "Кросс 500 м/c", StandartResult = 56.4, DateResult = new DateTime(2023 - 12 - 21), ProfilePlayerId = 2, TypeStandart = "Min" },
                new Standart {Id = 25, StandartName = "% ОФП", StandartResult = 56 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 26, StandartName = "% силовых приемов", StandartResult = 88 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Max"},
                new Standart {Id = 27, StandartName = "% выигранных сбросов", StandartResult = 43 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 2, TypeStandart = "Max"},


                new Standart {Id = 9, StandartName = "Отжимания", StandartResult = 89,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 10, StandartName = "Пресс", StandartResult = 95,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 11, StandartName = "Подтягивание", StandartResult = 52,DateResult = new DateTime(2023-11-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 12, StandartName = "Кросс 100 м/c", StandartResult = 14.4 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Min"},
                new Standart {Id = 17, StandartName = "Кросс 100 м/c", StandartResult = 11.4 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Min"},
                new Standart {Id = 18, StandartName = "Кросс 300 м/c", StandartResult = 34.4 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Min"},
                new Standart { Id = 19, StandartName = "Кросс 500 м/c", StandartResult = 57.4, DateResult = new DateTime(2023 - 12 - 21), ProfilePlayerId = 3, TypeStandart = "Min" },
                new Standart {Id = 20, StandartName = "% ОФП", StandartResult = 79 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 21, StandartName = "% силовых приемов", StandartResult = 56 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Max"},
                new Standart {Id = 22, StandartName = "% выигранных сбросов", StandartResult = 98 ,DateResult = new DateTime(2023-12-21), ProfilePlayerId = 3, TypeStandart = "Max"},
            };



            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<PersonalData>().HasData(users);
            modelBuilder.Entity<ProfilePlayer>().HasData(players);
            modelBuilder.Entity<Club>().HasData(clubs);
            modelBuilder.Entity<Standart>().HasData(standarts);

            return modelBuilder;
        }
    }
}