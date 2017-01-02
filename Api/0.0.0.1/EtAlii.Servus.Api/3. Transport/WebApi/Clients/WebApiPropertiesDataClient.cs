﻿namespace EtAlii.Servus.Api.Transport.WebApi
{
    using System.Threading.Tasks;

    internal class WebApiPropertiesDataClient : WebApiClientBase, IPropertiesDataClient<IWebApiSpaceTransport>
    {
        public WebApiPropertiesDataClient()
        {
        }

        public async Task Store(Identifier identifier, PropertyDictionary properties)
        {
            var address = Connection.AddressFactory.Create(Connection.Storage, RelativeUri.Properties, UriParameter.EntryId, identifier.ToString());
            await Connection.Client.Post(address, properties);
            PropertiesHelper.SetStored(properties, true);
        }

        public async Task<PropertyDictionary> Retrieve(Identifier identifier, ExecutionScope scope)
        {
            return await scope.Cache.GetProperties(identifier, async () =>
            {
                var address = Connection.AddressFactory.Create(Connection.Storage, RelativeUri.Properties, UriParameter.EntryId, identifier.ToString());
                var result = await Connection.Client.Get<PropertyDictionary>(address);
                if (result != null)
                {
                    PropertiesHelper.SetStored(result, true);
                    // properties.Stored is not serialized in the PropertyDictionaryConverter.
                }
                return result;
            });
        }
    }
}
