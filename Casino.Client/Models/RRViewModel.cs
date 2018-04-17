using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Library.Games;


namespace Casino.Client.Models
{
    public class RRViewModel
    {
        public string RequestId { get; set; }
        public RussianRoulette rr { get; set; }
        public string status { get; set; }

        public RRViewModel()
        {
            rr = new RussianRoulette();
        }
    }
}
