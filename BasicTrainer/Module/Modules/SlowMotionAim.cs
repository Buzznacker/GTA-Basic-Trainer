using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;

namespace BasicTrainer.Module.Modules
{
    public class SlowMotionAim : BasicModule
    {
        private bool _bSlowMowed = false;

        public SlowMotionAim(string name, MenuType menuType, Category category) : base(name, menuType, category) { }

        public override void onTick()
        {
            Player player = Game.Player;
            if (player.IsAiming)
            {
                if (!_bSlowMowed)
                {
                    _bSlowMowed = true;
                    Game.TimeScale = 0.5f;
                }
            }
            else if(_bSlowMowed)
            {
                setSpeedBackToNormal();
            }
             
        }

        protected override void onDisable()
        {
            base.onDisable();
            setSpeedBackToNormal();
        }

        private void setSpeedBackToNormal()
        {
            Game.TimeScale = 1.5f;
            _bSlowMowed = false;
        }
    }
}
