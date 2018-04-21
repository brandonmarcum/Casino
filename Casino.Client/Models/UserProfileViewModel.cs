using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Client.Models
{
    public class UserProfileViewModel
    {
        public string username;
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
        public UserProfileViewModel()
        {
            username = "Brandon Marcum";
            Wins = 8;
             Losses = 3;
             WinLose = Wins / Losses;
             White = 50;
             Red = 50;
             Blue = 50;
             Green = 50;
             Black = 50;
             Purple = 50;
             Orange = 50;
             TotalChips = White + Red + Blue + Green + Black + Purple + Orange;
             MostPlayed = "Russian Roulette";
        }
    }
}
