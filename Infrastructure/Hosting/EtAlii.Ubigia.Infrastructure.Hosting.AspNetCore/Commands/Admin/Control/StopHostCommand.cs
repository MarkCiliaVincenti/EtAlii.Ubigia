﻿namespace EtAlii.Ubigia.Infrastructure.Hosting.Owin
{
    using System;
    using EtAlii.Ubigia.Infrastructure.Functional;
    using EtAlii.xTechnology.Hosting;

    class StopHostCommand : HostCommandBase, IStopHostCommand
    {
        public string Name => "Admin/API service/Stop";

        public void Execute()
        {
            Host.Stop();
        }

        protected override void OnHostStateChanged(HostState state)
        {
            CanExecute = state == HostState.Running;
        }
    }
}