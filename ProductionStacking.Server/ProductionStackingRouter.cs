using ProductionStacking.Server.Models;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Utils;

namespace ProductionStacking.Server
{
    [Injectable]
    public class ProductionStackingRouter(JsonUtil jsonUtil, ProductionStackingService automationService) : StaticRouter(jsonUtil, [
        new RouteAction("/ProductionStacking/State",
                 async (url, requestData, sessionId, output) => jsonUtil.Serialize(await automationService.GetState(sessionId))!),
        new RouteAction<UnstackProductionRequestData>("/ProductionStacking/Unstack",
                 async (url, requestData, sessionId, output) => jsonUtil.Serialize(await automationService.Unstack(sessionId, requestData))!),
        new RouteAction<NextProductionRequestData>("/ProductionStacking/StartFromStack",
                 async (url, requestData, sessionId, output) => jsonUtil.Serialize(await automationService.StartFromStack(sessionId, requestData))!),
        new RouteAction<FindProductionRequestData>("/ProductionStacking/CanFindProduction",
            async (url, requestData, sessionId, output) => jsonUtil.Serialize(await automationService.CanFindProduction(sessionId, requestData))!),
        ])
    {
    }
}