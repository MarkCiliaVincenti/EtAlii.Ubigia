﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia
{
    using System;
    using System.Linq;
    using EtAlii.xTechnology.MicroContainer;

    /// <summary>
    /// The UseExtensions class provides methods with which configuration specific settings can be configured without losing configuration type.
    /// This comes in very handy during the fluent method chaining involved.
    /// </summary>
    public static class ConfigurationUseExtensions
    {
        /// <summary>
        /// Add a set of extensions to the configuration.
        /// Filtering is applied to make sure each extension is only applied once.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        public static TConfiguration Use<TConfiguration, TExtension>(this TConfiguration configuration, TExtension[] extensions)
            where TConfiguration: IExtensible
            where TExtension : IExtension
        {
            if (extensions == null)
            {
                throw new ArgumentException("No extensions specified", nameof(extensions));
            }

            configuration.Extensions = configuration.Extensions
                .Concat(extensions.Cast<IExtension>()) // TODO: This cast feels not needed.
                .Distinct()
                .ToArray();
            return configuration;
        }

        /// <summary>
        /// Use the extensions from one configuration in another.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="otherConfiguration"></param>
        /// <typeparam name="TConfiguration"></typeparam>
        /// <returns></returns>
        public static TConfiguration Use<TConfiguration>(this TConfiguration configuration, ConfigurationBase otherConfiguration)
            where TConfiguration : IExtensible
        {
            configuration.Extensions = ((IExtensible)otherConfiguration).Extensions;

            return configuration;
        }
    }
}
