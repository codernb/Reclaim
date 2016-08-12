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

            private int agility = 1;
            private int intelligence = 1;
            private int life = 5;
            private int strength = 2;

            public int getAgility()
            {
                return agility;
            }

            public int getIntelligence()
            {
                return intelligence;
            }

            public int getLife()
            {
                return life;
            }

            public int getStrength()
            {
                return strength;
            }
        }

    }
}
