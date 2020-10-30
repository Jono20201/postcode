using System;

namespace Postcode.Exceptions
{
    public class ProviderAlreadyRegisteredException : Exception
    {
        public ProviderAlreadyRegisteredException() : base(
            "A provider has already been registered. You can only register one provider at a time currently.")
        {
        }
    }
}