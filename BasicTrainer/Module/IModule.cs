using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicTrainer.Module
{
    public interface Module
    {
        /// <summary>
        /// Author: Seb
        /// Description: Toggles the mod on/off depending on the current status.
        /// </summary>
        void toggle();

        /// <summary>
        /// Author: Seb
        /// Description: Toggles the mod to the status of "status".
        /// </summary>
        /// <param name="status">bool that determines if the mod will be on or off.</param>
        void toggle(bool status);

        /// <summary>
        /// Author: Seb
        /// Description: Method called every tick in enabled mods.
        /// </summary>
        void onTick();

        /// <summary>
        /// Author: Seb
        /// Description: Method called when a key is put down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">KeyEventArgs contains information such as the key pressed</param>
        void onKeyDown(object sender, KeyEventArgs e);

        /// <summary>
        /// Author: Seb
        /// Description: Method called when a key is put up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">KeyEventArgs contains information such as the key pressed</param>
        void onKeyUp(object sender, KeyEventArgs e);

        /// <summary>
        /// Author: Seb
        /// Description: Returns current status of the module.
        /// </summary>
        /// <returns>enabled</returns>
        bool isEnabled();

        /// <summary>
        /// Author: Seb
        /// Description: Gets the name of the module
        /// </summary>
        /// <returns>name</returns>
        string getName();

        /// <summary>
        /// Author: Seb
        /// Description: Gets the kind of menu object the mod will occupy in the menu
        /// </summary>
        /// <returns>menuType</returns>
        MenuType getMenuType();

        /// <summary>
        /// Author: Seb 
        /// Description: Gets the kind of category the mod is part of.
        /// </summary>
        /// <returns>category</returns>
        Category getCategory();

        /// <summary>
        /// Author: Seb
        /// Description: Gets the toggle key if there is one.
        /// </summary>
        /// <returns>toggleKey</returns>
        Keys getToggleKey();
    }
}
