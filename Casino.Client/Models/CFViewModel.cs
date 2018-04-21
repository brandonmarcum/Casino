using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Library.Games.ChickenFight;

namespace Casino.Client.Models
{
    public class CFViewModel
    {
        public string RequestId { get; set; }
        public static Fight fight { get; set; }
        public string status { get; set; }

        public CFViewModel()
        {
        }
    }
}
