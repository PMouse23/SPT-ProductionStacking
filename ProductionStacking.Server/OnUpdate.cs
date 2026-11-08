using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Servers;
using System.Threading;
using System.Threading.Tasks;

namespace ProductionStacking.Server
{
    [Injectable(TypePriority = OnLoadOrder.SaveCallbacks)]
    public class OnUpdate(HideoutConfig hideoutConfig, SaveServer saveServer, ProductionStackingService productionStackingService) : IOnUpdate
    {
        protected readonly HideoutConfig HideoutConfig = hideoutConfig;

        async Task<bool> IOnUpdate.OnUpdateAsync(long secondsSinceLastRun, CancellationToken cancellationToken)
        {
            if (secondsSinceLastRun < HideoutConfig.RunIntervalSeconds)
                return false;

            foreach (var (sessionId, profile) in saveServer.GetProfiles())
                productionStackingService.UpdateProductionQueue(sessionId, profile.CharacterData?.PmcData);

            return true;
        }
    }
}