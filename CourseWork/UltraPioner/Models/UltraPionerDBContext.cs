using Microsoft.EntityFrameworkCore;
using UltraPioner.Models.DataBase.Entities;

namespace UltraPioner.Models
{
    public class UltraPionerDBContext:DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalDate> Users { get; set; }
        public DbSet<ProfilePlayer> ProfilePlayers { get; set; }
        public DbSet<Club> Clubs { get; set; }

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
                new Role { RoleID = 1, RoleName = "admin" },
                new Role { RoleID = 2, RoleName = "player" },
                new Role { RoleID = 3, RoleName = "coach" },
                new Role { RoleID = 5, RoleName = "scout" }
            };

            List<PersonalDate> users = new(){
                new PersonalDate { PersonalDateID = 1, Name = "Красоткин Антон", DateBorn = new DateTime(1997-05-20) , Discription = "Варатарь",
                    Email = "KrasotkinA@local.dom", Phone = "8(908)345-34-34", RoleID = 2, ClubID = 1, Login = "KrasotkinA", Password = "1"},

                new PersonalDate { PersonalDateID = 2, Name = "Красоткин Антон", DateBorn = new DateTime(1967-02-13) , Discription = "Администратор клуба",
                    Email = "admin@local.dom", Phone = "8(908)353-32-94", RoleID = 1, ClubID = 1, Login = "Admin", Password = "admin"},

                new PersonalDate { PersonalDateID = 3, Name = "Мёрфи Тревор", DateBorn = new DateTime(1995-07-17) , Discription = "Защитник",
                    Email = "MerfiT@local.dom", Phone = "8(908)353-32-94", RoleID = 1, ClubID = 1, Login = "MerfiT", Password = "1"},

                new PersonalDate { PersonalDateID = 4, Name = "Маркович Макс", DateBorn = new DateTime(1981-03-01) , Discription = "Видеотренер-аналитик",
                    Email = "MarcovichM@local.dom", Phone = "8(923)443-62-94", RoleID = 3, ClubID = 1, Login = "MarcovichM", Password = "1"}
            };

            List<ProfilePlayer> players = new(){
                new ProfilePlayer { ProfilePlayerID = 1, PersonalDateID = 1, Weight = 81, Height = 182, Grip = "Левый", OnCommand = false, Achievements = "Обладатель Кубка Харламова (2016). Бронзовый призёр молодёжного чемпионат мира (2017)." },
                new ProfilePlayer {ProfilePlayerID = 2, PersonalDateID = 3, Weight = 82, Height = 179, Grip = "Левый", OnCommand = false,  Achievements = "Бронзовый призер чемпионата России и КХЛ (2021)."}
            };

            List<Club> clubs = new(){
                new Club { ClubID = 1, ClubName = "Сибирь", ColorProfile = "blue"},
                new Club { ClubID = 2, ClubName = "Авангард", ColorProfile = "red"},
                new Club { ClubID = 3, ClubName = "Амур", ColorProfile = "orange" }
            };


            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<PersonalDate>().HasData(users);
            modelBuilder.Entity<ProfilePlayer>().HasData(players);
            modelBuilder.Entity<Club>().HasData(clubs);

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
            modelBuilder.Entity<Role>().HasKey(x => x.RoleID);
            modelBuilder.Entity<PersonalDate>().HasKey(x => x.PersonalDateID);
            modelBuilder.Entity<ProfilePlayer>().HasKey(x => x.ProfilePlayerID);
            modelBuilder.Entity<Club>().HasKey(x => x.ClubID);

            return modelBuilder;
        }
        public static ModelBuilder SetEntitiesColumnNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDate>().Property(u => u.PersonalDateID).HasColumnName("acc_id");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Login).HasColumnName("acc_login");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Email).HasColumnName("acc_email");
            modelBuilder.Entity<PersonalDate>().Property(u => u.Password).HasColumnName("acc_pswd");
            modelBuilder.Entity<PersonalDate>().Property(u => u.RoleID).HasColumnName("acc_role");

            modelBuilder.Entity<Role>().Property(r => r.RoleID).HasColumnName("role_id");
            modelBuilder.Entity<Role>().Property(r => r.RoleName).HasColumnName("role_name");

            return modelBuilder;
        }

        public static ModelBuilder SetRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDate>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.PersonalDate)
                .HasForeignKey<ProfilePlayer>(p => p.PersonalDateID);

            modelBuilder.Entity<PersonalDate>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(p => p.RoleID);

            return modelBuilder;
        }
    }
}
