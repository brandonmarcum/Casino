using System.Collections.Generic;
using Casino.Library.Enums;

namespace Casino.Library.Models
{
    public class ChipHelper
    {
        public ChipHelper()
        {
            Pocket = ChipUser.UserPocket;
        }
        public List<Chips> Pocket{ get; set; }
        public User ChipUser{ get; set; }

        public int totalChipsOfType(TypeEnums type)
        {
            int count = 0;
            switch (type)
            {
                case (TypeEnums.white):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.white))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.red):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.red))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.blue):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.blue))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.green):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.green))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.black):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.black))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.purple):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.purple))
                        {
                            count++;
                        }
                    }
                break;
                 case (TypeEnums.orange):
                    foreach(var item in Pocket)
                    {
                        if(item.Type.Equals(TypeEnums.orange))
                        {
                            count++;
                        }
                    }
                break;
            
                default:
                break;

                return count;
            }
            
            return 0;
        }

        public void AddToPocket(Chips chips)
        {
            Pocket.Add(chips);
        }
        public void RemoveFromPocket(Chips chips, int amount)
        {
            
        }
        
        
    }
}