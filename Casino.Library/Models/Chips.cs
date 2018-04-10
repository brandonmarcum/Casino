namespace Casino.Library.Models
{
    public class Chips
    {
        public Chips()
        {
            Amount = 0;
            Type = ChipTypes.White;

        }
        public int Amount { get; set; }
        public string Type { get; set; }
        public int Value
        { 
            get
            {
                switch (Type)
                {
                    case (ChipTypes.White):   
                        return 1;
                    break;
                    case (ChipTypes.Red):
                       return 5;
                    break;
                    case (ChipTypes.Blue):
                        return 10;
                    break;
                    case (ChipTypes.Green):
                        return 25;
                    break;
                    case (ChipTypes.Black):
                       return 100;
                    break;
                    case (ChipTypes.Purple):
                       return 500;
                    break;
                    case (ChipTypes.Orange):
                        return 1000;
                    break;
                    default:
                        return -1;
                    break;
                }
            }
        }
        
    }
}