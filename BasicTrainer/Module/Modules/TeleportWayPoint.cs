using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class TeleportWayPoint : BasicModule
    {
        public TeleportWayPoint(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        protected override void onEnable()
        {
            Game.Player.Character.Position = World.GetWaypointPosition();
            UI.ShowSubtitle("Teleported you to the waypoint");
            toggle();            
        }

        protected override void onDisable() {}
    }
}
