﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games
{
    public class Blackjack
    {
        public int playerTotal;
        public int dealerTotal;
        public bool playerStand;
        public bool dealerStand;
        string status;

        public Blackjack()
        {
            playerTotal = 0;
            dealerTotal = 0;
            status = "playing";
            playerStand = false;
            dealerStand = false;
        }
        
        public void NextTurn()
        {
            if(!playerStand)
                status = PlayerHit();
            if(status == "playing" && !dealerStand)
                status = DealerHit();
        }

        public void PlayerStand()
        {
            playerStand = true;
        }

        public string PlayerHit()
        {
            Random rand = new Random();
            int random = rand.Next(1, 14);
            if (random > 10)
                random = 10;
            if (random == 1)
            {
                if(playerTotal == 10)
                    return "win";
                if (playerTotal < 10)
                    random = 1;
            }


            playerTotal += random;


            if (playerTotal > 21)
                return "lose";
            if (playerTotal == 21)
                return "win";
            return "playing";
        }

        public string DealerHit()
        {
            Random rand = new Random();
            int random = rand.Next(1, 14);
            if (random > 10)
                random = 10;
            if (random == 1)
            {
                if (dealerTotal == 10)
                    return "lose";
                if (dealerTotal < 10)
                    random = 1;
            }


            dealerTotal += random;


            if (dealerTotal > 21)
                return "win";
            if (dealerTotal == 21)
                return "lose";

            if (dealerTotal - 15 <= 6)
                dealerStand = true;

            return "playing";
        }


    }
}
