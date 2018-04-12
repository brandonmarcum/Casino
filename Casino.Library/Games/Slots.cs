using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games
{
    public class Slots
    {
        public int left { get; set; }
        public int middle { get; set; }
        public int right { get; set; }
        public string status { get; set; }

        public Slots()
        {
            left = 0;
            middle = 0;
            right = 0;
            status = "playing";
        }

        public void SetLeft()
        {
            left = ChangeSlot();
        }

        public void SetMiddle()
        {
            middle = ChangeSlot();
        }

        public void SetRight()
        {
            right = ChangeSlot();
        }


        public int ChangeSlot()
        {
            Random random = new Random();
            //7 Slot (Rare)
            if (random.Next(0, 8) == 1)
                return 7;
            //Gold Slot (Uncommon)
            if (random.Next(0, 4) == 1)
                return 1;
            //Silver Slot (Somewhat Common)
            if (random.Next(0, 3) == 1)
                return 2;
            //Bronze Slot (Extremely Common)
            else
                return 3;
        }

        public string CheckForMatch()
        {
            if (left == middle && middle == right)
                return "win";

            return "lose";
        }
    }
}
