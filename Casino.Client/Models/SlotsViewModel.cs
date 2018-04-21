using System;
using Casino.Library.Games;

namespace Casino.Client.Models
{
    public class SlotsViewModel
    {
        public string RequestId { get; set; }
        public static Slots Slots{ get; set; }
        
        public SlotsViewModel()
        {
        }
    }
}