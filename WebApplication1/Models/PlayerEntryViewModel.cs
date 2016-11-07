using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class PlayerEntryViewModel : IEnumerable<Player>

    {
        public string singlePlayer { get; set; }

        public List<string> GamePlayers { get; internal set; }

        public IEnumerator<Player> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}