﻿namespace EtAlii.Ubigia.Api
{
    using System;
    using System.Linq;

    /// <summary>
    /// This is the base class for all configuration classes.
    /// It provides out of the box support for extensions.
    /// </summary>
    public abstract class Configuration : IConfiguration, IEditableConfiguration
    {
        /// <summary>
        /// The extensions added to this configuration.
        /// </summary>
        protected IExtension[] Extensions { get; private set; }
        IExtension[] IEditableConfiguration.Extensions { get => Extensions; set => Extensions = value; } 
        protected Configuration()
        {
            Extensions = Array.Empty<IExtension>();
        }

        public TExtension[] GetExtensions<TExtension>()
            where TExtension : IExtension
        {
            return Extensions.OfType<TExtension>().ToArray();
        }
    }
}