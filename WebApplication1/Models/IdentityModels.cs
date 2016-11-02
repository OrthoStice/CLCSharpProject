using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public class Game
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Game Name")]
        public string GameName { get; set; }
        private DateTime? gameStartDate;
        public DateTime GameStartDate
        {
            get { return gameStartDate ?? DateTime.Now; }
            set { gameStartDate = value; }
        }

        public virtual string UserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }

            set { }
        }

        [Required]
        [Range(2,10, ErrorMessage ="Enter a Number Between 2 and 10")]
        [Display(Name = "How Many Players?")]
        public int numOfPlayers { get; set; }
    }
    //ForeignKey syntax
    //public int StandardRefId { get; set; }

    //[ForeignKey("StandardRefId")]
    //public Standard Standard { get; set; }


    public class Player
    {
        public int Id { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerGameName { get; set; }
    }

    public class Score
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game game { get; set; }

        public int TurnNum { get; set; }
        private DateTime? turnTime;
        public DateTime TurnTime
        {
            get { return turnTime ?? DateTime.Now; }
            set { turnTime = value; }
        }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player player { get; set; }

        public int TurnScore { get; set; }
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

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }

}

