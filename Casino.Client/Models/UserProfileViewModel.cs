using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Client.Models
{
    public class UserProfileViewModel
    {
        public string Username;
        public int Wins;
        public int Losses;
        public double WinLose;
        public int White;
        public int Red;
        public int Blue;
        public int Green;
        public int Black;
        public int Purple;
        public int Orange;
        public int TotalChips;
        public string MostPlayed;
        public UserProfileViewModel(string username, int wins, int losses, Dictionary<string, int> chips, string mostPlayed)
        {
            Username = username;
            Wins = wins;
             Losses = losses;
             WinLose = Wins / Losses;
             White = chips["White"];
             Red = chips["Red"];
             Blue = chips["Blue"];
             Green = chips["Green"];
             Black = chips["Black"];
             Purple = chips["Purple"];
             Orange = chips["Orange"];
             TotalChips = White + Red + Blue + Green + Black + Purple + Orange;
             MostPlayed = mostPlayed;
        }
    }
}
