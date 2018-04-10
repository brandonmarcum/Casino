using System.Collections.Generic;
using Casino.Library.Enums;

namespace Casino.Library.Models
{

    //CHIPHELPER IS MEANT TO BE USED WITH POCKET, USERS, GAMES (WHATEVER DEALS WITH CHIPS) TO CALCULATE AND MANAGE CHIPS
    public class ChipHelper
    {
        private User _chipUser;
        public ChipHelper()
        {
            Pocket = new Pocket();
        }
        public Pocket Pocket{ get; set; }
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
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.white))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Red):
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.red))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Blue):
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.blue))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Green):
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.green))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Black):
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.black))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Purple):
                    foreach(var item in Pocket.PocketChips)
                    {
                        if(item.Type.Equals(TypeEnums.purple))
                        {
                            count++;
                        }
                    }
                break;
                 case (ChipTypes.Orange):
                    foreach(var item in Pocket.PocketChips)
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

        public void AddToPocket(Chips chips)
        {
            Pocket.PocketChips.Add(chips);
        }
        public void RemoveFromPocket(Chips chips, int amount)
        {
            
        }
        
        
    }
}