// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Transport.Admin.Portal
{
    using System;

    public record StorageRow
    {
        public int Index;
        public string Name;
        public Guid Id;
    }
}
