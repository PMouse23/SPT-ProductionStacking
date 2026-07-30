using ProductionStacking.Server.Patches;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System.Threading.Tasks;

namespace ProductionStacking.Server
{
    [Injectable(TypePriority = OnLoadOrder.PreSptModLoader)]
    public class OnLoad() : IOnLoad
    {
        Task IOnLoad.OnLoad()
        {
            new GameStart().Enable();
            new HandleRecipe().Enable();
            new MoveItem().Enable();
            new SingleProductionStart().Enable();
            new UnstackRewardIntoValidSize().Enable();

            return Task.CompletedTask;
        }
    }
}