using ProductionStacking.Server.Models;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using System.Collections.Concurrent;

namespace ProductionStacking.Server.Stores
{
    [Injectable(InjectionType = InjectionType.Singleton)]
    public class HideoutAutomationStore(JsonStore<ProductionStackingData> jsonStore)
    {
        private const string filename = "productionstacking.json";

        private readonly ConcurrentDictionary<MongoId, ProductionStackingData> hideoutAutomationData = [];

        public ProductionStackingData Get(MongoId profileId)
        {
            if (hideoutAutomationData.TryGetValue(profileId, out ProductionStackingData? data))
                return data;

            data = jsonStore.Load(profileId, filename);
            if (data == null)
                data = new ProductionStackingData();
            hideoutAutomationData[profileId] = data;
            return data;
        }

        public void Set(MongoId profileId)
        {
            if (hideoutAutomationData.TryGetValue(profileId, out ProductionStackingData? data))
                jsonStore.Save(data, profileId, filename);
        }
    }
}