using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games
{
    class RussianRoulette
    {
        public List<bool> PlayerGun;
        public List<bool> OpponentGun;
        int turn;
        string status;

        public RussianRoulette()
        {
            LoadGuns();
            turn = 0;
            status = "playing";
        }

        public void LoadGuns()
        {
            for(int i = 0; i < 6; i++)
            {
                PlayerGun[i] = false;
                OpponentGun[i] = false;
            }

            Random random = new Random();
            PlayerGun[random.Next(0, 7)] = true;
            Random random2 = new Random();
            OpponentGun[random2.Next(0, 7)] = true;
        }

        public void NextTurn()
        {
            status = PlayerFire();
            if(status == "playing")
                status = OpponentFire();
            turn++;
        }

        public string PlayerFire()
        {
            if (PlayerGun[turn])
                return "lose";

            return "playing";
        }

        public string OpponentFire()
        {
            if (OpponentGun[turn])
                return "win";

            return "playing";
        }

    }
}
