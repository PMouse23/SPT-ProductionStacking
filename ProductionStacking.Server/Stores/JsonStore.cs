using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Utils;
using System.IO;

namespace ProductionStacking.Server.Stores
{
    [Injectable(InjectionType = InjectionType.Singleton)]
    public class JsonStore<T>(FileUtil fileUtil, JsonUtil jsonUtil)
    {
        private const string profileDataFilepathPrefix = "user/profileData/";

        public T? Load(MongoId profileId, string fileName)
        {
            string fullPath = Path.Combine(profileDataFilepathPrefix, profileId, fileName);
            if (fileUtil.FileExists(fullPath))
                return jsonUtil.Deserialize<T>(fileUtil.ReadFile(fullPath));
            return default;
        }

        public void Save(T obj, MongoId profileId, string fileName)
        {
            string? json = jsonUtil.Serialize(obj, true);
            if (json == null)
                return;
            string fullPath = Path.Combine(profileDataFilepathPrefix, profileId, fileName);
            fileUtil.WriteFile(fullPath, json);
        }
    }
}