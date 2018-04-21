using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Library.Games;

namespace Casino.Client.Models
{
    public class RPSViewModel
    {
        public string RequestId { get; set; }
        public RockPaperScissors rps { get; set; }
        public string status { get; set; }

        public RPSViewModel()
        {
            rps = new RockPaperScissors();
        }
    }
}
