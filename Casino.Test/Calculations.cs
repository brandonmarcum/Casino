using System;
using Xunit;
using Casino.Library.Games;
using Casino.Library.Models;

namespace Casino.Test
{
    public class Calculations
    {

        [Fact]
        public void PlaceBetInGame()
        {
            User user = new User();
            ChipHelper ch = new ChipHelper();
            Chips chips = new Chips();

        

            user.UserPocket.AllChips[2].Amount = 50;
            ch.RemoveFromPocket(user.UserPocket, user.UserPocket.AllChips[2], 15*user.UserPocket.AllChips[2].Value);

            Assert.True(user.UserPocket.AllChips[2].Amount == 35);

            ch.AddToPocket(user.UserPocket, user.UserPocket.AllChips[2], 20*user.UserPocket.AllChips[2].Value);

            Assert.True(user.UserPocket.AllChips[2].Amount == 55);
        }

      
    }
}
