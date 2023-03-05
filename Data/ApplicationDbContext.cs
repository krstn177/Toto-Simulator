using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Toto_Simulator.Data.Entities;

namespace Toto_Simulator.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private User GuestUser { get; set; }
        private Draw Draw { get; set; }
        private Jackpot Jackpot { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Jackpot> Jackpots { get; set; }
        public DbSet<Number> Numbers { get; set;  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Ticket>().HasOne(t => t.Draw).WithMany(d => d.Tickets).HasForeignKey(t => t.DrawId).OnDelete(DeleteBehavior.Restrict);

            //SeedNumbers();
            //builder.Entity<Number>().HasData(this.Numbers);

            SeedUsers();
            builder.Entity<User>().HasData(this.GuestUser);

            //SeedDraw();
            //builder.Entity<Draw>().HasData(this.Draw);

            //SeedJackpot();
            //builder.Entity<Jackpot>().HasData(this.Jackpot);

            //builder.Entity<Ticket>().HasData(new Ticket()
            //{
            //    Id = 1,
            //    Date= DateTime.Now,
            //    OwnerId = this.GuestUser.Id,
            //    DrawId = this.Draw.Id,
            //},
            //new Ticket()
            //{       
            //    Id = 2,
            //    Date= DateTime.Now,
            //    OwnerId = this.GuestUser.Id,
            //    DrawId = this.Draw.Id,
            //},
            //new Ticket()
            //{          
            //    Id = 3,
            //    Date= DateTime.Now,
            //    OwnerId = this.GuestUser.Id,
            //    DrawId = this.Draw.Id,
            //});

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            this.GuestUser = new User()
            {
                Id = "userId1",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User",
                Earnings = 0
            };
            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guest");
        }

        private void SeedDraw()
        {
            this.Draw = new Draw()
            {
                Id = 1,
                Date = DateTime.Now.AddMonths(-1),                
                Fund = 100000000
            };
        }
        private void SeedJackpot()
        {
            this.Jackpot = new Jackpot()
            {
                Id = 1,
                AccumulatedSum = 10000
            };
        }
        //private void SeedNumbers()
        //{
        //    for (int i = 1; i <= 49; i++)
        //    {
        //        this.Numbers.Add(new Number()
        //        {
        //            Id = i,
        //            Value = i,
        //            Ocurrences = 0
        //        });
        //    }
        //}
    }
}