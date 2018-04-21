using System;
using System.Collections.Generic;
using Casino.Library;
using Casino.Library.Games;
using Casino.Library.Models;
using Newtonsoft.Json;

namespace Casino.Client.Models
{
    public class BlackJackViewModel
    {
        public string RequestId { get; set; }
        public Blackjack Blackjack{ get; set; }
        
        [JsonIgnore]
        public IDictionary<string, int> Bet{get; set;}
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