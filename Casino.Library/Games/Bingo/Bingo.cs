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

        public void PlayerTurn()
        {
            int number = RollNumber();

            for(int i = 0; i < 5; i++)
            {
                List<int> row = bingoCard.GetRow(i);

                foreach(var r in row)
                {
                    if (r == number)
                        row[r] = 0;
                }
            }

            chipLimit--;
        }

        public void CheckForBingo()
        {

        }


    }
}
