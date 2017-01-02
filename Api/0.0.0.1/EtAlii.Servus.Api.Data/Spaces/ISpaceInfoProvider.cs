﻿namespace EtAlii.Servus.Api
{
    using EtAlii.Servus.Client.Model;
    using System;

    public interface ISpaceInfoProvider 
    {
        string SpaceName { get; }
        Space Space { get; }
        Guid SpaceId { get; }

        Account Account { get; }
        string AccountName { get; }
        Guid AccountId { get; }

        Storage TargetStorage { get; }
    }
}
