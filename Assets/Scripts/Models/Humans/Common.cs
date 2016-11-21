using System;
using System.Collections.Generic;
using Assets.Scripts.Models.Items;
using Assets.Scripts.Models.Items.Armor;
using Assets.Scripts.Models.Items.Weapons;
using Assets.Scripts.Models.Stats;
using Assets.Scripts.Models.Skills;
using System.Linq;

namespace Assets.Scripts.Models.Humans
{
    [Serializable]
    public class Common : Human
    {

        private string name = "John Doe";
        private List<Item> items = new List<Item>();
        private Stats stats = new Stats();
        private Skills skills = new Skills();

        public void addItem(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Armor> getArmor()
        {
            List<Armor> armor = new List<Armor>();
            foreach (Item item in items)
                if (item is Armor)
                    armor.Add(item as Armor);
            return armor;
        }

        public List<Item> getItems()
        {
            return items;
        }

        public SkillsContainer getSkills()
        {
            return skills;
        }

        public StatsContainer getStats()
        {
            return stats;
        }

        public Weapon getWeapon()
        {
            Weapon weapon = null;
            foreach (Item item in items)
                if (item is Weapon && (weapon == null || weapon.getDamage() < (item as Weapon).getDamage()))
                    weapon = item as Weapon;
            return weapon;
        }

        public float getLoadout()
        {
            return items.Sum(i => i.getWeight());
        }

        public float getCapacity()
        {
            return stats.getStrength() * 10;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public class Stats : StatsContainer
        {

            private float agility = 3;
            private float intelligence = 3;
            private float life = 5;
            private float strength = 3;

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

        public class Skills : SkillsContainer
        {

            private Cooking cooking = new Cooking();
            private Melee melee = new Melee();
            private Mechanics mechanics = new Mechanics();
            private Shooting shooting = new Shooting();

            public Cooking getCooking()
            {
                return cooking;
            }

            public Melee getMelee()
            {
                return melee;
            }

            public Mechanics getMechanics()
            {
                return mechanics;
            }

            public Shooting getShooting()
            {
                return shooting;
            }
        }

    }
}
