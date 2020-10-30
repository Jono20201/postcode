using Postcode.Contracts;
using Postcode.Exceptions;

namespace Postcode
{
    public class PostcodeServiceOptions
    {
        public IPostcodeClient Client { get; private set; }

        public void RegisterProvider(IPostcodeClient client)
        {
            if (Client != null)
                throw new ProviderAlreadyRegisteredException();

            Client = client;
        }
    }
}