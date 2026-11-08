using HarmonyLib;
using SPTarkov.Reflection.Patching;
using SPTarkov.Server.Core.Controllers;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using System.Reflection;

namespace ProductionStacking.Server.Patches
{
    public class GameStart : AbstractPatch
    {
        [PatchPostfix]
        public static void PatchPostfix(MongoId sessionId)
        {
            if (ModServices.Get<ProductionStackingService>() is ProductionStackingService automationService)
                automationService.StartFromStack(sessionId);
        }

        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(GameController), nameof(GameController.GameStart));
        }
    }
}