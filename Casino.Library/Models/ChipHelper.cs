using System.Collections.Generic;
using Casino.Library.Enums;

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
                        if(item.Type.Equals(TypeEnums.white))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Red):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.red))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Blue):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.blue))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Green):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.green))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Black):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.black))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Purple):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.purple))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Orange):
                    foreach(var item in Pocket.AllChips)
                    {
                        if(item.Type.Equals(TypeEnums.orange))
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