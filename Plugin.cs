using BepInEx;
using BepInEx.Configuration;
using ProductionStacking.Patches.Hideout;
using ProductionStacking.Patches.View;
using ProductionStacking.Helpers;
using System;
using UnityEngine;

namespace ProductionStacking
{
    [BepInPlugin("com.KnotScripts.ProductionStacking", "ProductionStacking", VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string VERSION = "0.1.0";

        private ConfigEntry<bool> debug;
        private ConfigEntry<KeyboardShortcut> specialShortcut;

        private void Awake()
        {
            try
            {
                LogHelper.Logger = this.Logger;

                this.enablePatches();
                this.setConfigurables();
            }
            catch (Exception exception)
            {
                LogHelper.LogException(exception);
            }
        }

        private void enablePatches()
        {
            new HideoutClass_SetInventoryController().Enable();

            new HideoutProductionRequirementView_Show().Enable();
            new ProduceView_Close().Enable();
            new ProduceView_Show().Enable();
            new ProduceView_Update().Enable();
            new ProduceView_UpdateView().Enable();
            new ProductionPanel_Show().Enable();
        }

        private void global_SettingChanged(object sender, EventArgs e)
        {
            this.setGlobalSettings();
        }

        private void setConfigurables()
        {
            this.debug = this.Config.Bind("General", "Debug", false, "Debug");
            this.debug.SettingChanged += this.global_SettingChanged;

            this.specialShortcut = this.Config.Bind("ProductionStacking", "SpecialShortcut", new KeyboardShortcut(KeyCode.LeftControl), "Key(s) to press to do some special operations like unstacking.");
            this.specialShortcut.SettingChanged += this.global_SettingChanged;
            this.setGlobalSettings();
        }

        private void setGlobalSettings()
        {
            Globals.Debug = this.debug.Value;
            Globals.SpecialShortcut = this.specialShortcut.Value;
        }
    }
}