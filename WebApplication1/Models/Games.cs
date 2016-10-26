using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FarkleGame.Models
{

    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public DateTime GameStartDate { get; set; }
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

    public class GameContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }

}
