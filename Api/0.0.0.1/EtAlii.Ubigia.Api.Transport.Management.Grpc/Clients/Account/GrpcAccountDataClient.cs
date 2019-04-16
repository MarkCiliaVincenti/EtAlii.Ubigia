﻿namespace EtAlii.Ubigia.Api.Transport.Management.Grpc
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport.Grpc;
    using EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol;
    using global::Grpc.Core;
    using AdminAccountPostSingleRequest = EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.AccountPostSingleRequest;
    using AdminAccountSingleRequest = EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.AccountSingleRequest;
    using AdminAccountMultipleRequest = EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.AccountMultipleRequest;

    public class GrpcAccountDataClient : IAccountDataClient<IGrpcStorageTransport>
    {
        private AccountGrpcService.AccountGrpcServiceClient _client;
        private IGrpcStorageTransport _transport;

        public async Task<Api.Account> Add(string accountName, string accountPassword, AccountTemplate template)
        {
            try
            {
                var account = AccountExtension.ToWire(new Api.Account
                {
                    Name = accountName,
                    Password = accountPassword,
                });
    
                var request = new AdminAccountPostSingleRequest
                {
                    Account = account,
                    Template = template.Name
                };
                var call = _client.PostAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Account.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Add()", e);
            }
        }

        public async Task Remove(System.Guid accountId)
        {
            try
            {
                var request = new AdminAccountSingleRequest
                {
                    Id = GuidExtension.ToWire(accountId)
                };
                var call = _client.DeleteAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Remove()", e);
            }
        }

        public async Task<Api.Account> Change(System.Guid accountId, string accountName, string accountPassword)
        {
            try
            {
                var account = AccountExtension.ToWire(new Api.Account
                {
                    Id = accountId,
                    Name = accountName,
                    Password = accountPassword,
                });
    
                var request = new AdminAccountSingleRequest
                {
                    Account = account,
                };
                var call = _client.PutAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Account.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Change()", e);
            }
        }

        public async Task<Api.Account> Change(Api.Account account)
        {
            try
            {
                var request = new AdminAccountSingleRequest
                {
                    Account = AccountExtension.ToWire(account),
                };
                var call = _client.PutAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Account.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Change()", e);
            }
        }

        public async Task<Api.Account> Get(string accountName)
        {
            try
            {
                var request = new AdminAccountSingleRequest
                {
                    Name = accountName,
                };
                var call = _client.GetSingleAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Account.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Get()", e);
            }
        }

        public async Task<Api.Account> Get(System.Guid accountId)
        {
            try
            {
                var request = new AdminAccountSingleRequest
                {
                    Id = GuidExtension.ToWire(accountId)
                };
                var call = _client.GetSingleAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Account.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.Get()", e);
            }
        }

        public async Task<IEnumerable<Api.Account>> GetAll()
        {
            try
            {
                var request = new AdminAccountMultipleRequest
                {
                };
                var call = _client.GetMultipleAsync(request, _transport.AuthenticationHeaders);
                var response = await call.ResponseAsync;
    
                return response.Accounts.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcAccountDataClient)}.GetAll()",e);
            }
        }

        public async Task Connect(IStorageConnection connection)
        {
            await Connect((IStorageConnection<IGrpcStorageTransport>) connection);
        }

        public async Task Disconnect(IStorageConnection connection)
        {
            await Disconnect((IStorageConnection<IGrpcStorageTransport>)connection);
        }

        public Task Connect(IStorageConnection<IGrpcStorageTransport> connection)
        {
            _transport = connection.Transport;
            _client = new AccountGrpcService.AccountGrpcServiceClient(_transport.Channel);
            return Task.CompletedTask;
        }

        public Task Disconnect(IStorageConnection<IGrpcStorageTransport> connection)
        {
            _transport = null;
            _client = null;
            return Task.CompletedTask;
        }
    }
}
