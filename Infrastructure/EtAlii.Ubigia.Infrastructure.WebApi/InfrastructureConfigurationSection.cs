﻿namespace EtAlii.Ubigia.Infrastructure.Transport.Owin.WebApi
{
    using System.Configuration;
    using EtAlii.Ubigia.Infrastructure.Functional;
    using EtAlii.Ubigia.Infrastructure.Transport;

    public class InfrastructureConfigurationSection : ConfigurationSection, IInfrastructureConfigurationSection
    {
        [ConfigurationProperty("name", IsRequired = false)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = false)]
        public string Password 
        {
            get { return this["password"] as string; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("account", IsRequired = true)]
        public string Account
        {
            get
            {
                return this["account"] as string;
            }
        }

        [ConfigurationProperty("address", IsRequired = true)]
        public string Address
        {
            get
            {
                return this["address"] as string;
            }
        }

        public IInfrastructureConfiguration ToInfrastructureConfiguration()
        {
            var systemConnectionCreationProxy = new SystemConnectionCreationProxy();
            var configuration = new InfrastructureConfiguration(systemConnectionCreationProxy)
                .Use(Name, Address, Account, Password);
            return configuration;
        }
    }
}