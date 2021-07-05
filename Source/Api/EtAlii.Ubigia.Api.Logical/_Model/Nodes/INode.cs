﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Logical
{
    using System.ComponentModel;

    public interface INode : INotifyPropertyChanged
    {
        Identifier Id { get; }
        string Type { get; }
        bool IsModified { get; }
    }
}
