using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Score
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game game { get; set; }

        public int TurnNum { get; set; }
        private DateTime? turnTime;
        public DateTime TurnTime
        {
            get { return turnTime ?? DateTime.Now; }
            set { turnTime = value; }
        }

        public int PlayerId { get; set; }
        public Player player { get; set; }

        public int TurnScore { get; set; }
    }
}