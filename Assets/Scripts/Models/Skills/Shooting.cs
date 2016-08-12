using Assets.Scripts.Models.Items.Weapons;
using System;

namespace Assets.Scripts.Models.Skills
{
    [Serializable]
    public class Shooting
    {

        public int getDamage(Firearm weapon)
        {
            return weapon.getDamage();
        }

    }
}
