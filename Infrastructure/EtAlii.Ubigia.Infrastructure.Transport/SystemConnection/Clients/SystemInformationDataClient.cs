﻿namespace EtAlii.Ubigia.Infrastructure.Transport
{
    using System.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api;
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.Ubigia.Infrastructure.Functional;

    internal sealed class SystemInformationDataClient : SystemStorageClientBase, IInformationDataClient
    {
        private readonly IInfrastructure _infrastructure;

        public SystemInformationDataClient(IInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        public Task<Storage> GetConnectedStorage(ISpaceConnection connection, string address)
        {
            if (connection.Storage != null)
            {
                throw new InvalidInfrastructureOperationException(InvalidInfrastructureOperation.SpaceAlreadyOpen);
            }

            var storage = _infrastructure.Storages.GetLocal();

            // We do not want the address pushed to us from the server. 
            // If we get here then we already know how to contact the server. 
            storage.Address = address;

            return Task.FromResult(storage);
        }
        public Task<Storage> GetConnectedStorage(IStorageConnection storageConnection)
        {
            if (storageConnection.Storage != null)
            {
                throw new InvalidInfrastructureOperationException(InvalidInfrastructureOperation.SpaceAlreadyOpen);
            }

            var storage = _infrastructure.Storages.GetLocal();

            // We do not want the address pushed to us from the server. 
            // If we get here then we already know how to contact the server. 
            storage.Address = storageConnection.Transport.Address.ToString();

            return Task.FromResult(storage);
        }

        public Task<ConnectivityDetails> GetConnectivityDetails(IStorageConnection connection)
        {
            var serviceDetails = _infrastructure.Configuration.ServiceDetails.Single(sd => sd.IsSystemService);

            var result = new ConnectivityDetails
            {
                ManagementAddress = serviceDetails.ManagementAddress.ToString(),
                DataAddress = serviceDetails.DataAddress.ToString(),
            };
            return Task.FromResult(result);
        }
    }
}
