using ProductionStacking.Server.Models;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using System.Collections.Concurrent;

namespace ProductionStacking.Server.Stores
{
    [Injectable(InjectionType = InjectionType.Singleton)]
    public class ProductionStackingStore(JsonStore<ProductionStackingData> jsonStore)
    {
        private const string filename = "productionstacking.json";

        private readonly ConcurrentDictionary<MongoId, ProductionStackingData> productionStackingData = [];

        public ProductionStackingData Get(MongoId profileId)
        {
            if (productionStackingData.TryGetValue(profileId, out ProductionStackingData? data))
                return data;

            data = jsonStore.Load(profileId, filename);
            if (data == null)
                data = new ProductionStackingData();
            productionStackingData[profileId] = data;
            return data;
        }

        public void Set(MongoId profileId)
        {
            if (productionStackingData.TryGetValue(profileId, out ProductionStackingData? data))
                jsonStore.Save(data, profileId, filename);
        }
    }
}