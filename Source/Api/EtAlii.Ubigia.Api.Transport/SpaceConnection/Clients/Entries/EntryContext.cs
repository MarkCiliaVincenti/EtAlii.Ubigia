﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Transport
{
    public class EntryContext : SpaceClientContextBase<IEntryDataClient, IEntryNotificationClient>, IEntryContext
    {
        public EntryContext(
            IEntryNotificationClient notifications, 
            IEntryDataClient data) 
            : base(notifications, data)
        {
        }
    }
}
