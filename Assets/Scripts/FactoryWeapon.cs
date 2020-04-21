using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    static class FactoryWeapon
    {
        public static Weapon Factory(string weapon)
        {
            switch (weapon)
            {
                case "Gun":
                    return new Gun();
                    break;
                case "Sword":
                    return new Sword();
                    break;
            }

            return null;
        }
    }
}
