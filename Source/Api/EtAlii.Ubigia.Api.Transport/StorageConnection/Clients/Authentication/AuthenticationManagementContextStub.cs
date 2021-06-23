// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Transport
{
    using System.Threading.Tasks;

    public class AuthenticationManagementContextStub : IAuthenticationManagementContext
    {
        public IAuthenticationManagementDataClient Data { get; }

        public AuthenticationManagementContextStub()
        {
            Data = new AuthenticationManagementDataClientStub();
        }

        public Task Open(IStorageConnection storageConnection)
        {
            return Task.CompletedTask;
        }

        public Task Close(IStorageConnection storageConnection)
        {
            return Task.CompletedTask;
        }

    }
}