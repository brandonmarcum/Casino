using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.ChickenFight
{
    class Chicken
    {
        public int Health;
        public int Attack;
        public int Evasion;
        public int StatTotal;
        public bool Betted;
        public bool Standing;

        public Chicken()
        {
            Random rand = new Random();

            StatTotal = 400;
            int x = StatTotal / int.Parse(1.6.ToString());
            Health = rand.Next(5, x);
            int j = (StatTotal - x) / int.Parse(2.ToString());
            Attack = rand.Next(5, j);
            Evasion = StatTotal - (Health + Attack);

            Standing = true;
            Betted = false;
        }

        public int DecreaseHealth(int damage)
        {
            Health -= damage;

            if (Health <= 0)
                Standing = false;

            return Health;
        }

        public bool Evade()
        {
            Random rand = new Random();

            if (Evasion < rand.Next(StatTotal * int.Parse(1.5.ToString())))
                return false;
            
            return true;
        }

    }
}
