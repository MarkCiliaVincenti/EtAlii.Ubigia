﻿namespace EtAlii.Ubigia.Infrastructure.Fabric
{
    using System;
    using EtAlii.Ubigia.Storage;

    public class FabricContextConfiguration : IFabricContextConfiguration
    {
        //public IFabricContextExtension[] Extensions { get { return _extensions; } }
        //private IFabricContextExtension[] _extensions;

        public IStorage Storage { get { return _storage; } }
        private IStorage _storage;

        public FabricContextConfiguration()
        {
            //_extensions = new IFabricContextExtension[0];
        }

        //public IFabricContextConfiguration Use(IFabricContextExtension[] extensions)
        //{
        //    if (extensions == null)
        //    {
        //        throw new ArgumentException(nameof(extensions));
        //    }

        //    _extensions = extensions
        //        .Concat(_extensions)
        //        .Distinct()
        //        .ToArray();
        //    return this;
        //}

        public IFabricContextConfiguration Use(IStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentException(nameof(storage));
            }

            _storage = storage;

            return this;
        }
    }
}
