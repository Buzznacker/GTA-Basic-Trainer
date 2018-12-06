using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GTA;

namespace BasicTrainer.Module
{
    public enum MenuType
    {
        BUTTON,
        CHECKBOX
    }

    public enum Category
    {
        Player,
        Vehicle,
        Weapons,
        Misc
    }

    public abstract class BasicModule : Module
    {
        private readonly string name;
        private readonly Keys toggleKey;
        private readonly MenuType menuType;
        private readonly Category category;
        private bool enabled;
        
        public BasicModule(string name, MenuType menuType, Category category, Keys key)
        {
            this.name = name;
            this.menuType = menuType;
            this.category = category;
            this.toggleKey = key;
        } 

        public BasicModule(string name, MenuType menuType, Category category)
        {
            this.name = name;
            this.menuType = menuType;
            this.category = category;
            this.toggleKey = Keys.None;
        }

        public void toggle()
        {            
            if(!enabled)
            {
                enabled = true;
                onEnable();
                return;
            }
            enabled = false;
            onDisable();
        }

        public void toggle(bool param)
        {
            if(param)
            {
                enabled = true;
                onEnable();
                return;
            }

            enabled = false;
            onDisable();
        }

        protected virtual void onEnable() => UI.Notify(name + " has been enabled");

        protected virtual void onDisable() => UI.Notify(name + " has been disabled");

        public virtual void onTick() {}

        public virtual void onKeyDown(object sender, KeyEventArgs e) {}

        public virtual void onKeyUp(object sender, KeyEventArgs e) {}

        public bool isEnabled() => enabled;

        public string getName() => name;

        public MenuType getMenuType() => this.menuType;

        public Category getCategory() => this.category;

        public Keys getToggleKey() => toggleKey;
    }
}
