using System;
using Postcode.PostcodesIO.Options;

namespace Postcode.PostcodesIO.Extensions
{
    public static class PostcodeOptionsBuilderExtensions
    {
        static PostcodeServiceOptions AddPostcodeIO(this PostcodeServiceOptions builder)
        {
            builder.RegisterProvider(new PostcodesIoClient(new PostcodeIoOptions()));

            return builder;
        }

        static PostcodeServiceOptions AddPostcodeIO(
            this PostcodeServiceOptions builder,
            Action<PostcodeIoOptions> configureOptions
        )
        {
            var options = new PostcodeIoOptions();

            configureOptions(options);

            builder.RegisterProvider(new PostcodesIoClient(options));

            return builder;
        }
    }
}