﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting
{
    internal class StopHostCommand : HostCommandBase, IStopHostCommand
    {
        public string Name => "Host/Stop";

        public StopHostCommand(IHost host)
            : base(host)
        {
        }

        public async void Execute()
        {
            await Host
                .Stop()
                .ConfigureAwait(false);
        }

        protected override void OnHostStateChanged(State state)
        {
            CanExecute = state == State.Running;
        }
    }
}
