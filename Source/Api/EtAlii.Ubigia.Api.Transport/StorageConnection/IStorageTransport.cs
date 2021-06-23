﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Transport
{
	using System;
	using System.Threading.Tasks;
    using EtAlii.xTechnology.MicroContainer;

    public interface IStorageTransport
    {
        bool IsConnected { get; }

        Uri Address { get; }

        Task Start();
        Task Stop();
        
        IScaffolding[] CreateScaffolding();
    }
}
