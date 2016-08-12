using Assets.Scripts.Models.Items.Weapons;
using System;

namespace Assets.Scripts.Models.Skills
{
    [Serializable]
    public class Melee
    {

        public int getDamage(MeleeWeapon weapon)
        {
            return weapon.getDamage();
        }

    }
}
