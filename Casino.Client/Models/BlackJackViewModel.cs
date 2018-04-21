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
        public static string RequestId { get; set; }
        public static Blackjack Blackjack{ get; set; }
        public static Chips Chips;
        public static User User;

        
        [JsonIgnore]
        public static IDictionary<string, int> Bet{get; set;}
        public BlackJackViewModel()
        {
            Chips.Type = "white";
            //Bet = 1;
        }
    }
}