using System;
using System.Collections.Generic;

namespace Casino.Library.Models
{
    public class User
    {
        public User()
        {
            UserID = DateTime.Now.Ticks;
            UserPocket = new List<Chips>();
        }
        public string Username{ get; set; }
        public long UserID{ get; private set; }

        public List<Chips> UserPocket{ get; set; }
    }
}