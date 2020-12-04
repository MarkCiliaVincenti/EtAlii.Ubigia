﻿namespace EtAlii.Ubigia.Infrastructure.Hosting.TestHost.NetCore
{
	using System.Net;
	using System.Net.Http;
	using EtAlii.Ubigia.Api.Transport.WebApi;
	using IHttpClientFactory = EtAlii.Ubigia.Api.Transport.WebApi.IHttpClientFactory;

	internal class TestHttpClientFactory : IHttpClientFactory
	{
		private readonly xTechnology.Hosting.IHostTestContext _testContext;

        public TestHttpClientFactory(xTechnology.Hosting.IHostTestContext testContext)
        {
	        _testContext = testContext;
        }

        public HttpClient Create(ICredentials credentials, string hostIdentifier, string authenticationToken)
        {
	        var handler = _testContext.CreateHandler();
#pragma warning disable CA2000 // The HttpClient is instructed to dispose the handler.            
			var client = new HttpClient(new TestHttpClientMessageHandler(handler, credentials, hostIdentifier, authenticationToken), true);
#pragma warning restore CA2000
            
	        // Set the Accept header for BSON.
	        client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(PayloadMediaTypeFormatter.MediaType);

			return client;
        }
    }
}