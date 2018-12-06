using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class UnlimitedAmmo : BasicModule
    {
        public UnlimitedAmmo(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            Player player = Game.Player;
            Weapon curWeapon = player.Character.Weapons.Current;
            if (curWeapon.AmmoInClip < curWeapon.MaxAmmoInClip)
                curWeapon.AmmoInClip = curWeapon.DefaultClipSize;
            curWeapon.Ammo = curWeapon.MaxAmmo;           
        }
    }
}
