﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting
{
    using EtAlii.xTechnology.MicroContainer;

    internal class StartHostCommand : HostCommandBase, IStartHostCommand
    {
        public string Name => "Host/Start";

        public StartHostCommand(IHost host)
            : base(host)
        {
        }

        public async void Execute()
        {
            // Backup any previous host properties that need to be remembered.
            //var property = Host.Property

            // Replace the original host by a completely fresh instance.
            var host = Factory.Create<IHost>(Host.Options);
            var hostWrapper = Host as HostWrapper;
            hostWrapper?.Replace(host);

            // And restore the previous host properties.
            // Host.Property = property

            await Host
                .Start()
                .ConfigureAwait(false);
        }

        protected override void OnHostStateChanged(State state)
        {
            CanExecute = state != State.Running;
        }
    }
}
