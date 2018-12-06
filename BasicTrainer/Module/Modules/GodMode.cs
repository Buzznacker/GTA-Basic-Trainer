using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class GodMode : BasicModule
    {
        public GodMode(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            Ped playerPed = Game.Player.Character;
            if (playerPed.Health < playerPed.MaxHealth)
                playerPed.Health = playerPed.MaxHealth;
            
        }

        protected override void onEnable()
        {
            Ped playerPed = Game.Player.Character;
            base.onEnable();
            playerPed.IsFireProof = true;
            playerPed.IsExplosionProof = true;
        }

        protected override void onDisable()
        {
            base.onDisable();
            Ped playerPed = Game.Player.Character;
            playerPed.IsFireProof = false;
            playerPed.IsExplosionProof = false;
        }
    }
}
