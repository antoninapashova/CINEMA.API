using CINEMA.API.Entity;
using Microsoft.EntityFrameworkCore;
using System;


namespace CINEMA.API.Context
{
    public class CinemaDBContext : DbContext
    {
        
        public DbSet<User> User { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<CinemaRoom> CinemaRoom { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<User>(b =>
            {
                b.HasIndex(x => x.username).IsUnique();
                b.Property(x => x.email).IsRequired();
                b.Property(x => x.firstName).IsRequired();
                b.Property(x => x.lastName).IsRequired();
                b.Property(x => x.phone).IsRequired();
                b.Property(x => x.lastModified_18118032).IsRequired();

                b.HasMany(x => x.reservations).WithOne(x => x.user).HasForeignKey(x => x.userID);
                b.HasOne(x => x.role).WithMany(x => x.users).HasForeignKey(x => x.roleID);

            });

            mb.Entity<Film>(f =>
            {
                f.HasIndex(x => x.name).IsUnique();
                f.Property(x => x.ticketPrice).HasColumnType("decimal(10,2)");
                f.Property(x => x.start).HasColumnType("DateTime");
                
                f.Property(x => x.description).HasMaxLength(200);
                f.Property(x => x.duration).IsRequired();

                // f.HasOne(x => x.cinemaRoom).WithMany(x => x.films).HasForeignKey(x => x.cinemaRommId);
            });

            mb.Entity<CinemaRoom>(r =>
            {
                r.HasIndex(x => x.number).IsUnique();
                r.Property(x => x.seats).HasMaxLength(100);

                // r.HasMany(x => x.films).WithOne(x => x.cinemaRoom).HasForeignKey(x => x.cinemaRommId);

                r.HasData(new CinemaRoom()
                {
                    CinemaRoomID = 1,
                    number = "1",
                    seats = 100,

                    lastModified_18118032 = DateTime.Now

                },
                new CinemaRoom()
                {
                    CinemaRoomID = 2,
                    number = "2",
                    seats = 120,

                    lastModified_18118032 = DateTime.Now
                },

                new CinemaRoom()
                {
                    CinemaRoomID = 3,
                    number = "3",
                    seats = 80,

                    lastModified_18118032 = DateTime.Now
                });
            });

            mb.Entity<Reservation>(r =>
            {
                r.HasKey(x => x.ReservationID);
                r.Property(x => x.numberOfTickets).IsRequired();
                r.HasOne(x => x.user).WithMany(x => x.reservations).HasForeignKey(x => x.userID);
                r.HasOne(x => x.film).WithMany(x => x.reservations).HasForeignKey(x => x.filmId);
            });

            mb.Entity<Genre>(g =>
            {
                g.Property(x => x.Name).IsRequired().HasMaxLength(50);
                g.HasMany(x => x.films).WithOne(x => x.genre).HasForeignKey(x => x.genreID);

                g.HasData(new Genre()
                {
                    GenreID = 1,
                    Name = "Fantasy",
                    lastModified_18118032 = DateTime.Now
                },
                new Genre()
                {
                    GenreID = 2,
                    Name = "Comedy",
                    lastModified_18118032 = DateTime.Now
                },
                new Genre()
                {
                    GenreID = 3,
                    Name = "Mystery",
                    lastModified_18118032 = DateTime.Now
                },

                new Genre()
                {
                    GenreID = 4,
                    Name = "Thriller",
                    lastModified_18118032 = DateTime.Now
                },

                  new Genre()
                  {
                      GenreID = 5,
                      Name = "Romance",
                      lastModified_18118032 = DateTime.Now
                  }
                );
            });

            mb.Entity<UserRole>(ur =>
            {
                ur.HasIndex(x => x.role).IsUnique();
                ur.HasMany(x => x.users).WithOne(x => x.role).HasForeignKey(x => x.roleID);

                ur.HasData(new UserRole()
                {
                    UserRoleID = 1,
                    role = "Admin",
                    lastModified_18118032 = DateTime.Now
                },
                new UserRole()
                {
                    UserRoleID = 2,
                    role = "User",
                    lastModified_18118032 = DateTime.Now
                }
                );
            });
        }
        
    }
}
