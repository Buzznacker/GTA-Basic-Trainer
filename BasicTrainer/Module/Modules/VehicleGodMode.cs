using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTrainer.Module.Modules
{
    public class VehicleGodMode : BasicModule
    {
        private int ticksWaited = 0;

        public VehicleGodMode(string name, MenuType type, Category category) : base(name, type, category) { }

        public override void onTick()
        {
            ticksWaited++;
            if(ticksWaited == 50)
            {
                Vehicle currentVeh = Game.Player.Character.CurrentVehicle;
                if(currentVeh != null) 
                    currentVeh.Repair();                               
                ticksWaited = 0;
            }            
        }
    }
}
