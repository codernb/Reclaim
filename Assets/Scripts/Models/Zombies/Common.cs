using Assets.Scripts.Models.Stats;
using System;

namespace Assets.Scripts.Models.Zombies
{
    [Serializable]
    public class Common : Zombie
    {
        private Stats stats = new Stats();

        public StatsContainer getStats()
        {
            return stats;
        }

        public class Stats : StatsContainer
        {

            private float agility = 1;
            private float intelligence = 1;
            private float life = 5;
            private float strength = 2;

            public float getAgility()
            {
                return agility;
            }

            public void setAgility(float agility)
            {
                this.agility = agility;
            }

            public float getIntelligence()
            {
                return intelligence;
            }

            public void setIntelligence(float intelligence)
            {
                this.intelligence = intelligence;
            }

            public float getLife()
            {
                return life;
            }

            public void setLife(float life)
            {
                this.life = life;
            }

            public float getStrength()
            {
                return strength;
            }

            public void setStrength(float strength)
            {
                this.strength = strength;
            }

        }

    }
}
