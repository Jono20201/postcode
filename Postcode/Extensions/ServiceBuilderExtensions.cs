using System;
using Microsoft.Extensions.DependencyInjection;

namespace Postcode.Extensions
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceCollection AddLookup(this IServiceCollection services, Func<PostcodeOptionsBuilder> builder)
        {
            return services;
        }
    }
}