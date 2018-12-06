using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class AddWantedLevel : BasicModule
    {
        public AddWantedLevel(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            int wantedLevel = Game.Player.WantedLevel;
            if (wantedLevel != 5)
            {
                Game.Player.WantedLevel++;
                UI.ShowSubtitle("Brought Wanted Level one level higher");
            }
            else
                UI.ShowSubtitle("Cannot bring wanted level any higher");
            toggle();          
        }

        protected override void onDisable() { }

        protected override void onEnable() { }
    }
}
