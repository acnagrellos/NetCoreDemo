using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiStructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIfElse(
            this IServiceCollection services,
            bool condition,
            Func<IServiceCollection, IServiceCollection> actionIf,
            Func<IServiceCollection, IServiceCollection> actionElse)
        {
            return condition ? actionIf(services) : actionElse(services);
        }
    }
}
