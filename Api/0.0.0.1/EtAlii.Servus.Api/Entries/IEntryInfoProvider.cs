﻿namespace EtAlii.Servus.Api
{
    using EtAlii.Servus.Api;

    public interface IEntryInfoProvider
    {
        Entry Entry { get; }
        Identifier EntryId { get; }

        Storage TargetStorage { get; }
    }
}
