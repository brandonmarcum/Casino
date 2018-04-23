﻿using System;
using System.Collections.Generic;
using Casino.Library;
using Casino.Library.Games;
using Casino.Library.Models;
using Newtonsoft.Json;


namespace Casino.Client.Models
{
    public class RPSViewModel
    {
        public RockPaperScissors rps { get; set; }
        public User User { get; set; }
        public Slots Slots{ get; set; }
        public string status { get; set; }
        public string RequestId { get; set; }

        [JsonIgnore]
        public IDictionary<string, int> Bet { get; set; }
        public RPSViewModel()
        {
            rps = new RockPaperScissors();
            User = new User();
            Bet = new Dictionary<string, int>();
        }
    }
}
