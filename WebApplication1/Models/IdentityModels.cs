using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public class Game
        {
            public int Id { get; set; }
            public string GameName { get; set; }
            public System.DateTime GameStartDate { get; set; }
            public virtual ApplicationUser UserId { get; set; }
        }

        public class Player
        {
            public int Id { get; set; }
            public string PlayerFirstName { get; set; }
            public string PlayerGameName { get; set; }
        }

        public class Score
        {
            public int Id { get; set; }
            public int GameID { get; set; }
            public int TurnNum { get; set; }
            public DateTime TurnTime { get; set; }
            public int PlayerID { get; set; }
            public int TurnScore { get; set; }
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }

}

