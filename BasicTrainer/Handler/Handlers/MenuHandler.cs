using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeUI;
using GTA;
using BasicTrainer.Module;

namespace BasicTrainer.Handler.Handlers
{
    public class MenuHandler : Handler
    {
        public MenuHandler(Main instaceOfMain) : base(instaceOfMain) { }

        public void onItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            foreach (BasicModule module in main.getModules())
            {
                if (selectedItem.Text == module.getName())
                    module.toggle();
            }
        }

        public void onCheckBoxChangedHandler(UIMenu sender, UIMenuCheckboxItem selectedCheckbox, bool isChecked)
        {
            foreach (BasicModule module in main.getModules())
            {
                if (selectedCheckbox.Text == module.getName())
                    module.toggle(isChecked);
            }
        }

    }
}
