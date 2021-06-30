﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Transport.Grpc
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	internal class GrpcContentNotificationClient : GrpcClientBase, IContentNotificationClient<IGrpcSpaceTransport>
    {
        //private HubConnection _connection
//        private readonly string _name
        private readonly IEnumerable<IDisposable> _subscriptions = Array.Empty<IDisposable>();

        public event Action<Identifier> Updated = delegate { };
        public event Action<Identifier> Stored = delegate { };

//        public GrpcContentNotificationClient()
//        [
//            //_name = GrpcHub.Content
//        ]
//        private void OnUpdated(Identifier identifier)
//        [
//            Updated(identifier)
//        ]
//
//        private void OnStored(Identifier identifier)
//        [
//            Stored(identifier)
//        ]

        public override async Task Connect(ISpaceConnection<IGrpcSpaceTransport> spaceConnection)
        {
            await base.Connect(spaceConnection).ConfigureAwait(false);

            // Make sure client notifications over Grpc works again.
            // More details can be found in the GitHub item below:
            // https://github.com/vrenken/EtAlii.Ubigia/issues/82

            //_connection = new HubConnectionFactory().Create(spaceConnection.Transport, new Uri(spaceConnection.Storage.Address + GrpcHub.BasePath + "/" + _name, UriKind.Absolute))
	        //await _connection.StartAsync()

	        //_subscriptions = new[]
	        //[
		    //    _connection.On<Identifier>("updated", OnUpdated),
		    //    _connection.On<Identifier>("stored", OnStored),
	        //]
        }

        public override async Task Disconnect()
        {
            await base.Disconnect().ConfigureAwait(false);

            //await _connection.DisposeAsync()
            //_connection = null

			foreach (var subscription in _subscriptions)
			{
				subscription.Dispose();
			}
		}
	}
}
