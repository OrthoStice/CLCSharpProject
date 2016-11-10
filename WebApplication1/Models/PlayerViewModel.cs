using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Migrations;

namespace WebApplication1.Models
{
    public class PlayerViewModel 
    {
        public Player[] listOfPlayers { get; set; }

        public PlayerName Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

    }

}