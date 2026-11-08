using Comfort.Common;
using EFT.Hideout;
using HarmonyLib;
using ProductionStacking.Production;
using ProductionStacking.Helpers;
using SPT.Reflection.Patching;
using System;
using System.Reflection;

namespace ProductionStacking.Patches.View
{
    internal class ProduceView_Show : ModulePatch
    {
        [PatchPostfix]
        public static void PatchPostfix(ProduceView __instance)
        {
            try
            {
                ProduceView produceView = __instance;
                if (produceView == null)
                    return;
                Singleton<ProductionService>.Instance.AddProduceView(produceView);
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionToConsole(ex);
            }
        }

        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.FirstMethod(typeof(ProduceView), this.isTargetMethod);
        }

        private bool isTargetMethod(MethodInfo method)
        {
            return method.Name == nameof(ProduceView.Show);
        }
    }
}