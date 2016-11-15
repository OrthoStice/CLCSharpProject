using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Migrations;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class PlayerViewModel
    {
    //    public PlayerViewModel()
    //    {
    //        players = new List<Player>();
    //    }
        public List<Player> players
        {
            get; set;
        }
    }

}