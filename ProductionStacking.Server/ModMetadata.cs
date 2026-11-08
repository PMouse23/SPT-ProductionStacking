using SPTarkov.Server.Core.Models.Spt.Mod;
using System.Collections.Generic;

namespace ProductionStacking.Server
{
    public record ModMetadata : IModMetadata
    {
        public string ModGuid { get; init; } = "com.KnotScripts.ProductionStacking";
        public string Name { get; init; } = "ProductionStacking";

        public string Author { get; init; } = "KnotScripts";

        public List<string>? Contributors { get; init; }

        public SemanticVersioning.Version Version { get; init; } = new(typeof(ModMetadata).Assembly.GetName().Version?.ToString(3));

        public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.0");

        public bool HasPrepatcher { get; init; } = false;

        public List<string>? Incompatibilities { get; init; }

        public Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }

        public string? Url { get; init; } = "https://github.com/PMouse23/SPT-ProductionStacking";

        public string License { get; init; } = "MIT";
    }
}
