using System;
using System.Collections.Generic;
using Casino.Library;
using Casino.Library.Games;
using Casino.Library.Models;

namespace Casino.Client.Models
{
    public class BlackJackViewModel
    {
        public string RequestId { get; set; }
        public List<User> Users{ get; set; }
        public Blackjack Blackjack{ get; set; }
        public Chips Chips { get; set; }
        public int Bet{get; set;}
        public string Type{ get; set; }
        public BlackJackViewModel()
        {
            Blackjack = new Blackjack();
            Chips = new Chips();

            Users = UserHelper.GetUsers().GetAwaiter().GetResult();
             

            Chips.Type = "white";
            Type = "not set";
            Bet = 1;
        }
    }
}