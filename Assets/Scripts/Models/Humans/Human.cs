using Assets.Scripts.Models.Items;
using Assets.Scripts.Models.Items.Armor;
using Assets.Scripts.Models.Items.Weapons;
using Assets.Scripts.Models.Skills;
using Assets.Scripts.Models.Stats;
using System.Collections.Generic;

namespace Assets.Scripts.Models.Humans
{
    public interface Human
    {

        StatsContainer getStats();
        SkillsContainer getSkills();

        Weapon getWeapon();
        List<Armor> getArmor();

        void addItem(Item item);
        List<Item> getItems();

    }
}
