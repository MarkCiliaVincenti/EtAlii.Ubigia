﻿namespace EtAlii.Ubigia.Infrastructure.Transport.User.Api.SignalR.AspNetCore
{
    using System.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Primitives;

    public class HubBase : Hub
    {
        private readonly ISimpleAuthenticationTokenVerifier _authenticationTokenVerifier;

        public HubBase(ISimpleAuthenticationTokenVerifier authenticationTokenVerifier)
        {
            _authenticationTokenVerifier = authenticationTokenVerifier;
        }

        public override Task OnConnectedAsync()
        {
            Context.GetHttpContext().Request.Headers.TryGetValue("Authentication-Token", out StringValues stringValues);
            var authenticationToken = stringValues.Single();
            _authenticationTokenVerifier.Verify(authenticationToken, Role.User, Role.System);

            return base.OnConnectedAsync();
        }

        //public override Task OnReconnectedAsync()
        //{
        //    var authenticationToken = Context.Headers.Get("Authentication-Token");
        //    _authenticationTokenVerifier.Verify(authenticationToken, null);

        //    return base.OnReconnected();
        //}
    }
}