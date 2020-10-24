using System;
using Microsoft.Extensions.DependencyInjection;
using Postcode.Contracts;

namespace Postcode.Extensions
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceCollection AddPostcode(
            this IServiceCollection services,
            Action<PostcodeServiceOptions> builder
        )
        {
            var options = new PostcodeServiceOptions();

            builder(options);

            if (options.Client == null)
                throw new ArgumentNullException(nameof(options.Client), "At least one provider must be registered.");

            services.AddSingleton(options.Client);

            return services;
        }
    }
}