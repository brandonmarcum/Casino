﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.Bingo
{
    public class BingoCard
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
                for(int i = 0; i < 5; i++)
                {
                    int r = 5;
                    for(int j = 0; i < 5; i++)
                    {
                        if (card[i][j] == 0)
                        {
                            r--;
                            if (r == 0)
                                return true;
                        }
                    }
                }

            return false;
        }

        public bool CheckDiagonals()
        {
            int u = 5;
            for(int i = 0; i < 5;  i++)
            {
                if (card[i][i] == 0)
                    u--;
            }
            if (u == 0)
                return true;

            u = 5;
            for (int i = 0; i < 5; i++)
            {
                int j = 4-i;

                if (card[i][j] == 0)
                    u--;
            }
            if (u == 0)
                return true;

            return false;
        }

    }
}
