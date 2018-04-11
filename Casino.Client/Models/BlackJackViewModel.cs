using System;
using Casino.Library.Games;

namespace Casino.Client.Models
{
    public class BlackJackViewModel
    {
        public string RequestId { get; set; }
        public Blackjack Blackjack{ get; set; }

        public BlackJackViewModel()
        {
            Blackjack = new Blackjack();
        }
    }
}