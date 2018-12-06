using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class ClearWantedLevel : BasicModule
    {
        public ClearWantedLevel(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            Game.Player.WantedLevel = 0;
            UI.ShowSubtitle("Clear Wanted Level");
            toggle();
        }

        protected override void onDisable() {}

        protected override void onEnable() {}


    }
}
