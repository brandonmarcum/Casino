using System;
using Casino.Library.Games;
using Casino.Library.Models;

namespace Casino.Client.Models
{
    public class BlackJackViewModel
    {
        public string RequestId { get; set; }
        public Blackjack Blackjack{ get; set; }
        public Chips Chips { get; set; }
        public int Bet{get; set;}
        public string Type{ get; set; }
        public BlackJackViewModel()
        {
            Blackjack = new Blackjack();
            Chips = new Chips();
            Chips.Type = "white";
            Type = "not set";
            Bet = 1;
        }
    }
}