using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProductionStacking.Server
{
    internal static class ModServices
    {
        internal static T? Get<T>() where T : class
        {
            return Provider?.GetService<T>();
        }

        internal static IServiceProvider? Provider { get; set; }
    }
}
