﻿namespace EtAlii.Ubigia.Api.Management
{
    using System;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport;

    internal class ManagementConnection : IManagementConnection
    {
        public bool IsConnected => _connection?.IsConnected ?? false;

        public Storage Storage => _connection?.Storage;

        public IStorageContext Storages => _connection?.Storages;

        public IAccountContext Accounts => _connection?.Accounts;

        public ISpaceContext Spaces => _connection?.Spaces;

        public IManagementConnectionConfiguration Configuration => _configuration;
        private readonly IManagementConnectionConfiguration _configuration;

        private IStorageConnection _connection;

        internal ManagementConnection(IManagementConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDataConnection> OpenSpace(Guid accountId, Guid spaceId)
        {
            var account = await Accounts.Get(accountId);
            var space = await Spaces.Get(spaceId);
            return await OpenSpace(account.Name, space.Name);
        }

        public async Task<IDataConnection> OpenSpace(Space space)
        {
            var account = await Accounts.Get(space.AccountId);
            return await OpenSpace(account.Name, space.Name);
        }

        public async Task<IDataConnection> OpenSpace(string accountName, string spaceName)
        {
            var connectionConfiguration = new DataConnectionConfiguration()
                .Use(_configuration.TransportProvider)
                .Use(_configuration.Address)
                .Use(accountName, spaceName, null);
            var dataConnection = new DataConnectionFactory().Create(connectionConfiguration);
            await dataConnection.Open();
            return dataConnection;
        }

        public async Task Open()
        {
            if (IsConnected)
            {
                throw new InvalidInfrastructureOperationException(InvalidInfrastructureOperation.ConnectionAlreadyOpen);
            }

            var configuration = new StorageConnectionConfiguration()
                .Use(_configuration.TransportProvider.GetStorageTransport())
                .Use(_configuration.Address)
                .Use(_configuration.AccountName, _configuration.Password);
            _connection = new StorageConnectionFactory().Create(configuration);
            await _connection.Open();
        }
        public async Task Close()
        {
            if (!IsConnected)
            {
                throw new InvalidInfrastructureOperationException("The connection is already closed");
            }

            await _connection.Close();
            _connection = null;
        }

        #region Disposable

        private bool _disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    if (IsConnected)
                    {
                        var task = Task.Run(async () =>
                        {
                            await Close();
                        });
                        task.Wait();
                    }
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                _disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ManagementConnection()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion Disposable

    }
}
