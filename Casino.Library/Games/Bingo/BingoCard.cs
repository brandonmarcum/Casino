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

        public List<int> GetRow(int i)
        {
            return card[i];
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


        public bool CheckRows()
        {
            foreach(var c in card)
            {
                int i = 5;
                foreach(var r in c)
                {
                    if (r == 0)
                        i--;
                }
                if (i == 0)
                    return true;
            }

            return false;
        }

        public bool CheckCollumn()
        {
            foreach (var c in card)
            {
                int u = 0;
                List<int> r = new List<int>();
                //r.Add = { 5,5,5,5,5}



                //if (r[] == 0)
                    return true;
            }

            return false;
        }

    }
}
