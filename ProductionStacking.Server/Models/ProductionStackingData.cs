using SPTarkov.Server.Core.Models.Eft.Hideout;
using SPTarkov.Server.Core.Models.Enums.Hideout;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductionStacking.Server.Models
{
    public record ProductionStackingData
    {
        [JsonPropertyName("completedProductions")]
        public List<HideoutSingleProductionStartRequestData> CompletedProductions { get; } = [];

        [JsonPropertyName("areaProductionsAndPayment")]
        public Dictionary<HideoutAreas, LinkedList<ProductionStartRequestAndPaymentData>> AreaProductionsAndPayment { get; } = [];
    }
}