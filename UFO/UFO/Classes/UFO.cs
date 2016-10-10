using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFOGame.Classes
{
    public class UFO
    {
        public UFO(int crewSize)
        {
            this.abductionQuota = crewSize + (crewSize / 2);
            this.crewSize = crewSize;
            engagedInCombat = false;
            destroyed = false;
            cowsAbducted = 0;
            shipHealth = 10;
            tankHealth = 10;
        }

        private int crewSize;
        public int CrewSize
        {
            get { return crewSize; }
            set { crewSize = value; }
        }

        private int abductionQuota;
        public int AbductionQuota
        {
            get { return abductionQuota; }
        }

        private int cowsAbducted;
        public int CowsAbducted
        {
            get { return cowsAbducted; }
        }

        public void Abduct(int numberOfCows)
        {
            cowsAbducted += numberOfCows;
        }

        private bool engagedInCombat;
        public bool EngagedInCombat
        {
            get { return engagedInCombat; }
        }

        public void SeenByHumans()
        {
            engagedInCombat = true;
        }

        public void destroyHumans()
        {
            engagedInCombat = false;
            tankHealth = 10;
        }

        Random num = new Random();

        private int numberAbducted;
        public int NumberAbducted
        {
            get { return numberAbducted; }
        }

        public int AbductionEvent(int cowChanceMod, int tankChanceMod)
        {
            numberAbducted = num.Next(cowChanceMod * ((crewSize > 15) ? crewSize / 15 : 1));
            this.Abduct(numberAbducted);
            int tankChance = num.Next(tankChanceMod);
            if (tankChance == 1)
            {
                this.SeenByHumans();
            }
            return numberAbducted;
        }

        private int shipHealth;
        public int ShipHealth
        {
            get { return shipHealth; }
        }

        private int tankHealth;
        public int TankHealth
        {
            get { return tankHealth; }
        }

        public void TakeDamage()
        {
            shipHealth--;
        }

        public void Attack(int damage)
        {
            tankHealth -= damage;
        }

        public void Attack(int lowestDamage, int highestDamage)
        {
            int damage = num.Next(lowestDamage, highestDamage);
            tankHealth -= damage;
        }

        private bool destroyed;
        public bool Destroyed
        {
            get { return destroyed; }
        }
    }
}
