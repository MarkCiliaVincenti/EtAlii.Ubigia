﻿namespace EtAlii.Ubigia.Infrastructure.Transport.User.Api.AspNetCore
{
    public class UserSignalRService : ServiceBase
    {
        public override void Start()
        {
        }

        public override void Stop()
        {
        }

        protected override void Initialize(IHost host, ISystem system, IModule[] moduleChain, out Status status)
        {
            status = new Status(nameof(UserSignalRService));
        }
    }
}
