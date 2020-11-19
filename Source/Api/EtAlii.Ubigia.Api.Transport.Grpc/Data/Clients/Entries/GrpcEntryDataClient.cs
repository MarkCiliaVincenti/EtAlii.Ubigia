﻿namespace EtAlii.Ubigia.Api.Transport.Grpc
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol;
    using global::Grpc.Core;
    using EntryRelation = EtAlii.Ubigia.EntryRelation;
    using Identifier = EtAlii.Ubigia.Identifier;
    using Root = EtAlii.Ubigia.Root;

    internal class GrpcEntryDataClient : GrpcClientBase, IEntryDataClient<IGrpcSpaceTransport>
    {
        private EntryGrpcService.EntryGrpcServiceClient _client;
        private IGrpcSpaceTransport _transport;

        public async Task<IEditableEntry> Prepare()
        {
            try
            {
                var request = new EntryPostRequest { SpaceId = Connection.Space.Id.ToWire() };
                var response = await _client.PostAsync(request, _transport.AuthenticationHeaders);
                //return await _invoker.Invoke<Entry>(_connection, GrpcHub.Entry, "Post", Connection.Space.Id)
                return response.Entry.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcEntryDataClient)}.Prepare()", e);
            }
        }

        public async Task<IReadOnlyEntry> Change(IEditableEntry entry, ExecutionScope scope)
        {
            try
            {
                var request = new EntryPutRequest { Entry = ((IComponentEditableEntry)entry).ToWire() };
                var response = await _client.PutAsync(request, _transport.AuthenticationHeaders);
                //var result = await _invoker.Invoke<Entry>(_connection, GrpcHub.Entry, "Put", entry)

                scope.Cache.InvalidateEntry(entry.Id);
                // TODO: CACHING - Most probably the invalidateEntry could better be called on the result.id as well.
                //scope.Cache.InvalidateEntry(result.Id)
                return response.Entry.ToLocal();
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcEntryDataClient)}.Change()", e);
            }
        }

        public async Task<IReadOnlyEntry> Get(Root root, ExecutionScope scope, EntryRelation entryRelations = EntryRelation.None)
        {
            return await Get(root.Identifier, scope, entryRelations);
        }

        public async Task<IReadOnlyEntry> Get(Identifier entryIdentifier, ExecutionScope scope, EntryRelation entryRelations = EntryRelation.None)
        {
            try
            {
                return await scope.Cache.GetEntry(entryIdentifier, async () =>
                {
                    var request = new EntrySingleRequest { EntryId = entryIdentifier.ToWire(), EntryRelations = entryRelations.ToWire() };
                    var response = await _client.GetSingleAsync(request, _transport.AuthenticationHeaders);
                    //return await _invoker.Invoke<Entry>(_connection, GrpcHub.Entry, "GetSingle", entryIdentifier, entryRelations)
                    return response.Entry.ToLocal();
                });
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcEntryDataClient)}.Get()", e);
            }
        }

        public async IAsyncEnumerable<IReadOnlyEntry> Get(IEnumerable<Identifier> entryIdentifiers, ExecutionScope scope, EntryRelation entryRelations = EntryRelation.None)
        {
            // TODO: this can be improved by using one single Web API call.

            // The structure below might seem weird.
            // But it is not possible to combine a try-catch with the yield needed
            // enumerating an IAsyncEnumerable.
            // The only way to solve this is using the enumerator. 
            using var enumerator = entryIdentifiers.GetEnumerator();
            var hasResult = true;
            while (hasResult)
            {
                IReadOnlyEntry item;
                try
                {
                    hasResult = enumerator.MoveNext();
                    
                    item = hasResult
                        ? await scope.Cache.GetEntry(enumerator.Current, async () =>
                        {
                            var request = new EntrySingleRequest { EntryId = enumerator.Current.ToWire(), EntryRelations = entryRelations.ToWire() };
                            var response = await _client.GetSingleAsync(request, _transport.AuthenticationHeaders);
                            return response.Entry.ToLocal();
                        })
                        : null;

                }
                catch (RpcException e)
                {
                    throw new InvalidInfrastructureOperationException($"{nameof(GrpcEntryDataClient)}.Get()", e);
                }

                if (item != null)
                {
                    yield return item;
                }
            }
        }

        public IAsyncEnumerable<IReadOnlyEntry> GetRelated(Identifier entryIdentifier, EntryRelation entriesWithRelation, ExecutionScope scope, EntryRelation entryRelations = EntryRelation.None)
        {
            try
            {
                return scope.Cache.GetRelatedEntries(entryIdentifier, entriesWithRelation, () => GetRelated(entryIdentifier, entriesWithRelation, entryRelations));
            }
            catch (RpcException e)
            {
                throw new InvalidInfrastructureOperationException($"{nameof(GrpcEntryDataClient)}.GetRelated()", e);
            }
        }

        private async IAsyncEnumerable<IReadOnlyEntry> GetRelated(Identifier entryIdentifier, EntryRelation entriesWithRelation, EntryRelation entryRelations)
        {
            var request = new EntryRelatedRequest { EntryId = entryIdentifier.ToWire(), EntryRelations = entryRelations.ToWire(), EntriesWithRelation = entriesWithRelation.ToWire() };
            var call = _client.GetRelated(request, _transport.AuthenticationHeaders);
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                yield return response.Entry.ToLocal();
            }
        }

        public override async Task Connect(ISpaceConnection<IGrpcSpaceTransport> spaceConnection)
        {
            await base.Connect(spaceConnection);

            _transport = ((IGrpcSpaceConnection)spaceConnection).Transport;
            _client = new EntryGrpcService.EntryGrpcServiceClient(_transport.Channel);
        }

        public override async Task Disconnect()
        {
            await base.Disconnect();
            _transport = null;
            _client = null;
        }
    }
}
