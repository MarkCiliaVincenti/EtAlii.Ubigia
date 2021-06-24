﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Transport
{

    public interface IWebsiteBrowser
    {
        void BrowseTo(string relativeAddress);
    }
}
