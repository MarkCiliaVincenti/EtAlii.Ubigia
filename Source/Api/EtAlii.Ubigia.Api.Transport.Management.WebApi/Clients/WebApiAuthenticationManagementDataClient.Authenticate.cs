﻿namespace EtAlii.Ubigia.Api.Transport.Management.WebApi
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport.WebApi;

    public partial class WebApiAuthenticationManagementDataClient
    {
        public async Task Authenticate(IStorageConnection storageConnection, string accountName, string password)
        {
            var webApiConnection = (IWebApiStorageConnection)storageConnection;

            var authenticationToken = await GetAuthenticationToken(
                webApiConnection.Client, 
                webApiConnection.AddressFactory, 
                accountName, 
                password, 
                storageConnection.Transport.Address);

            if (!string.IsNullOrWhiteSpace(authenticationToken))
            {
                webApiConnection.Client.AuthenticationToken = authenticationToken;
            }
            else
            {
                var message = $"Unable to authenticate on the specified storage ({storageConnection.Transport.Address})";
                throw new UnauthorizedInfrastructureOperationException(message);
            }
        }

        private static async Task<string> GetAuthenticationToken(IInfrastructureClient client, IAddressFactory addressFactory, string accountName, string password, Uri address)
        {
            string authenticationToken;
            if (password == null && client.AuthenticationToken != null)
            {
				// These lines are needed to make the downscale from admin/system to user account based authentication tokens.
	            var credentials = new NetworkCredential(accountName, (string)null);
	            var localAddress = addressFactory.Create(address, RelativeUri.Authenticate, UriParameter.AccountName, accountName, UriParameter.AuthenticationToken);
	            authenticationToken = await client.Get<string>(localAddress, credentials).ConfigureAwait(false);
            }
            else
            {
                var credentials = new NetworkCredential(accountName, password);
                var localAddress = addressFactory.Create(address, RelativeUri.Authenticate);
                authenticationToken = await client.Get<string>(localAddress, credentials).ConfigureAwait(false);
            }

            if (string.IsNullOrWhiteSpace(authenticationToken))
            {
                throw new UnauthorizedInfrastructureOperationException(InvalidInfrastructureOperation.UnableToAthorize);
            }
            return authenticationToken;
        }
    }
}
