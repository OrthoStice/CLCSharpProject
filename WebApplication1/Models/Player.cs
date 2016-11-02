using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerGameName { get; set; }
    }
}