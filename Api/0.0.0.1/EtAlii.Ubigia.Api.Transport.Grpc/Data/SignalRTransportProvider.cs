namespace EtAlii.Ubigia.Api.Transport.SignalR
{
	using System;
	using System.Net.Http;

	public class SignalRTransportProvider : ITransportProvider
    {
        private string _authenticationToken;
	    private readonly Func<HttpMessageHandler> _httpMessageHandlerFactory;

	    public SignalRTransportProvider(Func<HttpMessageHandler> httpMessageHandlerFactory)
	    {
		    _httpMessageHandlerFactory = httpMessageHandlerFactory;
	    }

		public static SignalRTransportProvider Create(Func<HttpMessageHandler> httpMessageHandlerFactory = null)
        {
	        return new SignalRTransportProvider(httpMessageHandlerFactory);//new ClientHttpMessageHandler());
        }

        public ISpaceTransport GetSpaceTransport()
        {
            return new SignalRSpaceTransport(
	            _httpMessageHandlerFactory?.Invoke(),
				v => _authenticationToken = v, 
                () => _authenticationToken);
        }
    }
}