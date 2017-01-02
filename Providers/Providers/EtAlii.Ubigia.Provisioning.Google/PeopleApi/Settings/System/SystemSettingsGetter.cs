﻿namespace EtAlii.Ubigia.Provisioning.Google.PeopleApi
{
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Logical;

    public class SystemSettingsGetter : ISystemSettingsGetter
    {
        public SystemSettings Get(IDataContext context)
        {
            var script = new[]
            {
                "/Providers += Google/PeopleApi",
                "<= /Providers/Google/PeopleApi"
            };

            var settings = new SystemSettings();

            DynamicNode result = null;
            var task = Task.Run(async () =>
            {
                var lastSequence = await context.Scripts.Process(script);
                result = await lastSequence.Output.Cast<DynamicNode>();
            });
            task.Wait();

            object value = null;

            if (result.TryGetValue("ClientId", out value))
            {
                settings.ClientId = (string)value;
            }

            if (result.TryGetValue("ProjectId", out value))
            {
                settings.ProjectId = (string)value;
            }

            if (result.TryGetValue("AuthenticationUrl", out value))
            {
                settings.AuthenticationUrl = (string)value;
            }

            if (result.TryGetValue("TokenUrl", out value))
            {
                settings.TokenUrl = (string)value;
            }

            if (result.TryGetValue("AuthenticationProviderx509CertificateUrl", out value))
            {
                settings.AuthenticationProviderx509CertificateUrl = (string)value;
            }

            if (result.TryGetValue("ClientSecret", out value))
            {
                settings.ClientSecret = (string)value;
            }

            if (result.TryGetValue("RedirectUrl", out value))
            {
                settings.RedirectUrl = (string)value;
            }

            return settings;
        }
    }
}
