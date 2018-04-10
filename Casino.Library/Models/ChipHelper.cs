using System.Collections.Generic;

namespace Casino.Library.Models
{

    //CHIPHELPER IS MEANT TO BE USED WITH POCKET, USERS, GAMES (WHATEVER DEALS WITH CHIPS) TO CALCULATE AND MANAGE CHIPS
    //CHIPHELPER ONLY NEEDS A USER TO FUNCTION. IF NO USER, CHIPHELPER NEEDS A POCKET.
    public class ChipHelper
    {
        private User _chipUser;
        public ChipHelper()
        {
            Pocket = new Pocket();
            PocketChips = Pocket.AllChips;
        }
        public Pocket Pocket{ get; set; }
        public List<Chips> PocketChips{ get; set; }
        public User ChipUser{ 
            get
            {
                return _chipUser;
            }
            set
            { 
                //whenever a user is set to a chiphelper, the pocket is also set to the user's pocket
                _chipUser = value;
                Pocket = _chipUser.UserPocket;
            } 
        }

        public int totalChipsOfType(string type)
        {
            int count = 0;
            switch (type)
            {
                case (ChipTypes.White):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.White))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Red):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Red))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Blue):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Blue))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Green):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Green))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Black):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Black))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Purple):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Purple))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Orange):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(ChipTypes.Orange))
                        {
                            count++;
                        }
                    }
                break;
            }
            
            return count;
        }

        public void AddToPocket(Chips chips, int amount)
        {
            chips.Amount = amount;
            Pocket.AllChips.Add(chips);
        }
        public void RemoveFromPocket(Chips chips, int amount)
        {
            Pocket.AllChips.Remove(chips);
            if((chips.Amount - amount) > 0)
            {
                chips.Amount = chips.Amount - amount;
            }
            else 
            {
                chips.Amount = 0;
            }
            Pocket.AllChips.Add(chips);
        }

        public double convertChips(Chips chips)
        {
            return chips.Amount*chips.Value;
        }
        
        
    }
}