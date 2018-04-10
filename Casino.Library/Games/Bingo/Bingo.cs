using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.Bingo
{
    class Bingo
    {
        public int chipLimit;
        public BingoCard bingoCard;

        public Bingo(int chips)
        {
            chipLimit = chips;
            bingoCard = new BingoCard();
        }

        public int RollNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 76);
        }


    }
}
