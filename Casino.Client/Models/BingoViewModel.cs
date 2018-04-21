using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casino.Library.Games.Bingo;


namespace Casino.Client.Models
{
    public class BingoViewModel
    {
        public string RequestId { get; set; }
        public Bingo bingo { get; set; }
        public string status { get; set; }

        public BingoViewModel()
        {
            bingo = new Bingo(40);
        }
    }
}
