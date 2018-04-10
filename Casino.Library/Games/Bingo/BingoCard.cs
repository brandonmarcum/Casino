using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.Bingo
{
    class BingoCard
    {
        List<List<int>> card = new List<List<int>>();
        
        public BingoCard()
        {
            for(int i = 0; i < 5; i++)
            {
                card.Add(FillRow());
            }
        }

        public List<int> FillRow()
        {
            List<int> row = new List<int>();
            Random rand = new Random();

            row.Add(rand.Next(1, 16));
            row.Add(rand.Next(16, 31));
            row.Add(rand.Next(31, 46));
            row.Add(rand.Next(46, 61));
            row.Add(rand.Next(61, 76));

            return row;
        }

    }
}
