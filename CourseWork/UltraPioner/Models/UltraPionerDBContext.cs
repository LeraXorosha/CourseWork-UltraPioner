using Microsoft.EntityFrameworkCore;
using UltraPioner.Extensions;
using UltraPioner.Models.DataBase.Entities;

namespace UltraPioner.Models
{
    public class UltraPionerDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalDate> Users { get; set; }
        public DbSet<ProfilePlayer> ProfilePlayers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Standart> Standarts { get; set;}

        public UltraPionerDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder/*.AddInitialData();*/
                .AddKeys()
                .SetEntitiesColumnNames()
                .LinkEntitiesToTables()
                .SetRelations()
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

            List<PersonalDate> users = new(){
                new PersonalDate { Id = 1, Name = "Красоткин Антон", DateBorn = new DateTime(1997-05-20) , Discription = "Варатарь",
                    Email = "KrasotkinA@local.dom", Phone = "8(908)345-34-34", RoleId = 2, ClubId = 1, Login = "KrasotkinA", Password = "1".ToHash()},

                new PersonalDate { Id = 2, Name = "Валерий Петрович", DateBorn = new DateTime(1967-02-13) , Discription = "Администратор клуба",
                    Email = "admin@local.dom", Phone = "8(908)353-32-94", RoleId = 1, ClubId = 1, Login = "Admin", Password = "admin".ToHash()},

                new PersonalDate { Id = 3, Name = "Мёрфи Тревор", DateBorn = new DateTime(1995-07-17) , Discription = "Защитник",
                    Email = "MerfiT@local.dom", Phone = "8(908)353-32-94", RoleId = 2, ClubId = 1, Login = "MerfiT", Password = "1".ToHash()},

                new PersonalDate { Id = 4, Name = "Маркович Макс", DateBorn = new DateTime(1981-03-01) , Discription = "Видеотренер-аналитик",
                    Email = "MarcovichM@local.dom", Phone = "8(923)443-62-94", RoleId = 3, ClubId = 1, Login = "MarcovichM", Password = "1".ToHash()},
                new PersonalDate { Id = 5, Name = "Субботин Иван", DateBorn = new DateTime(1985-07-27) , Discription = "Нападающий",
                    Email = "SubbaI@local.dom", Phone = "8(908)353-32-94", RoleId = 2, ClubId = 1, Login = "SubbaI", Password = "1".ToHash()}
            };

            List<ProfilePlayer> players = new(){
                new ProfilePlayer { Id = 1, PersonalDateId = 1, Weight = 81, Height = 182, Grip = "Левый", OnCommand = false, Achievements = "Обладатель Кубка Харламова (2016). Бронзовый призёр молодёжного чемпионат мира (2017)." },
                new ProfilePlayer {Id = 2, PersonalDateId = 3, Weight = 82, Height = 179, Grip = "Левый", OnCommand = false,  Achievements = "Бронзовый призер чемпионата России и КХЛ (2021)."}
            };

            List<Club> clubs = new(){
                new Club { Id = 1, ClubName = "Сибирь", ColorProfile = "blue"},
                new Club { Id = 2, ClubName = "Авангард", ColorProfile = "red"},
                new Club { Id = 3, ClubName = "Амур", ColorProfile = "orange" }
            };

            List<Standart> standarts = new()
            {
                new Standart {Id = 1, StandartName = "Отжимания", StandartResult = 56, ProfilePlayerId = 1},
                new Standart {Id = 2, StandartName = "Отжимания", StandartResult = 64, ProfilePlayerId = 3},
                new Standart {Id = 3, StandartName = "Отжимания", StandartResult = 32, ProfilePlayerId = 5}
            };

            
            
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<PersonalDate>().HasData(users);
            modelBuilder.Entity<ProfilePlayer>().HasData(players);
            modelBuilder.Entity<Club>().HasData(clubs);
            modelBuilder.Entity<Standart>().HasData(standarts);

            return modelBuilder;
        }

        public static ModelBuilder LinkEntitiesToTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<PersonalDate>().ToTable("Accounts");
            modelBuilder.Entity<ProfilePlayer>().ToTable("Players");
            modelBuilder.Entity<Club>().ToTable("Clubs");

            return modelBuilder;
        }
        public static ModelBuilder AddKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<PersonalDate>().HasKey(x => x.Id);
            modelBuilder.Entity<ProfilePlayer>().HasKey(x => x.Id);
            modelBuilder.Entity<Club>().HasKey(x => x.Id);

            return modelBuilder;
        }
        public static ModelBuilder SetEntitiesColumnNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDate>().Property(u => u.Id).HasColumnName("acc_id");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Login).HasColumnName("acc_login");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Email).HasColumnName("acc_email");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Password).HasColumnName("acc_pswd");
            modelBuilder.Entity<PersonalDate>().Property(u => u.RoleId).HasColumnName("acc_role");

            modelBuilder.Entity<Role>().Property(r => r.Id).HasColumnName("role_id");
            modelBuilder.Entity<Role>().Property(r => r.RoleName).HasColumnName("role_name");

            return modelBuilder;
        }

        public static ModelBuilder SetRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDate>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.PersonalDate)
                .HasForeignKey<ProfilePlayer>(p => p.PersonalDateId);

            modelBuilder.Entity<PersonalDate>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(p => p.RoleId);

            return modelBuilder;
        }
    }
}
