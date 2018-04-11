using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.Bingo
{
    class Bingo
    {
        public int chipLimit;
        public BingoCard bingoCard;
        public string status;

        public Bingo(int chips)
        {
            chipLimit = chips;
            bingoCard = new BingoCard();
            status = "playing";
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
            status = bingoCard.CheckRows();
        }


    }
}
