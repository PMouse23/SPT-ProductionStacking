using ProductionStacking.Server.Patches;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductionStacking.Server
{
    [Injectable(TypePriority = OnLoadOrder.Preload)]
    public class OnLoad(IServiceProvider serviceProvider) : IOnLoad
    {
        Task IOnLoad.OnLoadAsync(CancellationToken cancellationToken)
        {
            ModServices.Provider = serviceProvider;

            new GameStart().Enable();
            new HandleRecipe().Enable();
            new MoveItem().Enable();
            new SingleProductionStart().Enable();
            new UnstackRewardIntoValidSize().Enable();

            return Task.CompletedTask;
        }
    }
}
