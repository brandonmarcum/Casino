using System.Collections.Generic;

//MEANT TO BE USED FOR INTERACTION OF CHIPS WITH MONEY, MEANT FOR MAKING REAL WORLD TRANSACTIONS
//HOLDS ALL TYPES AND QUANTITIES OF CHIPS
namespace Casino.Library.Models
{
    public class Pocket
    {
        public List<Chips> AllChips{ get; set; }
        public Pocket(){
            AllChips = new List<Chips>();
        }
        public double cashOutPocket()
        {
            //convert all of the chips to money using chiphelper and add to user payment method
            ChipHelper ch = new ChipHelper();
            ch.Pocket = this;
            double cashValue = 0;
            foreach(var item in AllChips)
            {
                cashValue += ch.convertChips(item);
            }
            return cashValue;
        }
        public void cashInPocket(double insert)
        {
            //convert inserted money to chips for user and add to pocket
        }
        
    }
}