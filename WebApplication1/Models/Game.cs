using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
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
        [Range(2, 10, ErrorMessage = "Enter a Number Between 2 and 10")]
        [Display(Name = "How Many Players?")]
        public int numOfPlayers { get; set; }
    }
}