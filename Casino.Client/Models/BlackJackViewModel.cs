using System;
using Casino.Library.Games;
using Casino.Library.Models;

namespace Casino.Client.Models
{
    public class BlackJackViewModel
    {
        public string RequestId { get; set; }
        public static Blackjack Blackjack{ get; set; }
        public Chips Chips { get; set; }
        public int Bet{get; set;}
        public string Type{ get; set; }
        public BlackJackViewModel()
        {
            Chips = new Chips();
            Chips.Type = "white";
            Type = "not set";
            Bet = 1;
        }
    }
}