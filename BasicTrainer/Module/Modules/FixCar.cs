using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class FixCar : BasicModule
    {
        public FixCar(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            Ped curPlayer = Game.Player.Character;
            if(curPlayer.IsInVehicle())
            {
                curPlayer.CurrentVehicle.Repair();
                UI.ShowSubtitle("Car has been repaired");
            }
            else            
                UI.ShowSubtitle("You are not in any vehicles");
            toggle();         
        }

        protected override void onDisable() { }

        protected override void onEnable() { }

    }
}
