using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;

namespace BasicTrainer.Module.Modules
{
    public class SearchVehicle : BasicModule
    {
        public SearchVehicle(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        protected override void onEnable()
        {
            string inputName = Game.GetUserInput(50);
            Vehicle veh = World.CreateVehicle(inputName, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)), Game.Player.Character.Heading - 90);
            if(veh != null)
            {
                veh.NumberPlate = "SEB DIEU";
                veh.CanTiresBurst = false;
                veh.PlaceOnGround();
                UI.ShowSubtitle("You successfully spawned a " + inputName);
            }
            else
            {
                UI.ShowSubtitle("Cannot find " + inputName);
            }
            toggle();
        }

        protected override void onDisable() {}
    }
}
