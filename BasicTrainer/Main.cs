using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTA;
using GTA.Native;
using GTA.Math;
using NativeUI;
using BasicTrainer.Handler;
using BasicTrainer.Handler.Handlers;
using BasicTrainer.Module;
using BasicTrainer.Module.Modules;
using System.Windows.Forms;
using System.Drawing;

namespace BasicTrainer
{
    public class Main : Script
    {
        private List<IModule> modules;
        private Dictionary<Category, UIMenu> _subMenus;
        private UIMenu _menu;
        private MenuPool _menuPool;
        private MenuHandler _menuHandler;

        public Main()
        {         
            Tick += onTick;
            KeyUp += onKeyUp;
                      
            // Initialization of Modules          
            modules = new List<IModule>();
            registerModule(new UnlimitedAmmo("Unlimited Ammo", MenuType.CHECKBOX, Category.Weapons));
            registerModule(new GodMode("God Mode", MenuType.CHECKBOX, Category.Player));
            registerModule(new AddWantedLevel("Add Wanted Level", MenuType.BUTTON, Category.Player));
            registerModule(new ClearWantedLevel("Clear Wanted Level", MenuType.BUTTON, Category.Player));
            registerModule(new FixCar("Fix Car", MenuType.BUTTON, Category.Vehicle));
            registerModule(new SlowMotionAim("Slow Motion While Aiming", MenuType.CHECKBOX, Category.Weapons));
            registerModule(new SearchVehicle("Search Vehicle by name", MenuType.BUTTON, Category.Vehicle));
            registerModule(new VehicleGodMode("VehicleGodMode", MenuType.CHECKBOX, Category.Vehicle));
            registerModule(new TeleportWayPoint("Teleport to waypoint", MenuType.BUTTON, Category.Misc));

            _subMenus = new Dictionary<Category, UIMenu>();
            _menu = new UIMenu("Seb's Trainer I", "Gros trainer de cave");
            _menuPool = new MenuPool();
            _menuPool.Add(_menu);
            initMenu();
        }

        public void onTick(object sender, EventArgs e)
        {                   
            modules.ForEach(mod =>
            {
                if (mod.isEnabled())
                {
                    mod.onTick();                    
                }
            });          
            _menuPool.ProcessMenus();
        }

        public void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (_menuPool.IsAnyMenuOpen())
                {
                    _menuPool.CloseAllMenus();
                }
                else
                    _menu.Visible = true;
            }

            if(e.KeyCode == Keys.K)
            {
                Player player = Game.Player;
                Model model = new Model("prop_money_bag_01");
                model.Request(50);

                if(model.IsInCdImage && model.IsValid)
                {
                    while (!model.IsLoaded) Script.Wait(50);
                    World.CreatePickup(PickupType.MoneyPaperBag, player.Character.GetOffsetInWorldCoords(new Vector3(0, 2, 0)), model, 40000);
                }
                else
                {
                    UI.ShowSubtitle("Model is not valid");
                }
            }
                
            modules.ForEach(mod =>
            {               
                if (e.KeyCode == mod.getToggleKey())
                {                    
                    mod.toggle();
                }
            });
        }

        private void initMenu()
        { 
            _menuHandler = new MenuHandler(this);
            _menu.OnItemSelect += _menuHandler.onItemSelectHandler;
            _menu.OnCheckboxChange += _menuHandler.onCheckBoxChangedHandler;

            foreach(Category category in Enum.GetValues(typeof(Category)))
            {
                UIMenu subMenu = _menuPool.AddSubMenu(_menu, category.ToString());
                _subMenus.Add(category, subMenu);
                subMenu.OnItemSelect += _menuHandler.onItemSelectHandler;
                subMenu.OnCheckboxChange += _menuHandler.onCheckBoxChangedHandler;

                foreach(BasicModule module in modules)
                {
                    if(module.getCategory() == category)
                    {
                        if (module.getMenuType() == MenuType.BUTTON)
                            subMenu.AddItem(new UIMenuItem(module.getName()));
                        else if (module.getMenuType() == MenuType.CHECKBOX)
                            subMenu.AddItem(new UIMenuCheckboxItem(module.getName(), false));
                    }                 
                }
            }          
                                                             
            setupWeaponSelectorMenu();
            setupVehicleSelectorMenu();
        }

        private void setupVehicleSelectorMenu()
        {
            // Weapon Selector
            UIMenu vehicleMenu;
            _subMenus.TryGetValue(Category.Vehicle, out vehicleMenu);
            UIMenu vehicleSelectorMenu = _menuPool.AddSubMenu(vehicleMenu, "Vehicle Spawner");


            foreach (VehicleHash vehHash in Enum.GetValues(typeof(VehicleHash)))
                vehicleSelectorMenu.AddItem(new UIMenuItem(vehHash.ToString()));

            vehicleSelectorMenu.OnItemSelect += (sender, item, index) =>
            {
                VehicleHash vehHash = (VehicleHash)Enum.Parse(typeof(VehicleHash), item.Text);
                Vehicle veh = World.CreateVehicle(vehHash, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)), Game.Player.Character.Heading - 90);
                veh.NumberPlate = "SEB DIEU";
                veh.CanTiresBurst = false;
                veh.PlaceOnGround();                
            };
        }
      
        private void setupWeaponSelectorMenu()
        {
            // Weapon Selector
            UIMenu weaponMenu;
            _subMenus.TryGetValue(Category.Weapons, out weaponMenu);
            UIMenu weaponSelectorMenu = _menuPool.AddSubMenu(weaponMenu, "Weapon Selector");

            foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash)))
                weaponSelectorMenu.AddItem(new UIMenuItem(weaponHash.ToString()));

            weaponSelectorMenu.OnItemSelect += (sender, item, index) =>
                Game.Player.Character.Weapons.Give((WeaponHash)Enum.Parse(typeof(WeaponHash), item.Text), 9999, true, true);
        }

        private void registerModule(BasicModule module) => this.modules.Add(module);

        public List<IModule> getModules() => this.modules;
    }
}
