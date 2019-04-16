﻿namespace EtAlii.Ubigia.Provisioning.Google
{
    using EtAlii.Ubigia.Provisioning.Google.PeopleApi;

    public class GoogleProvider : IProvider
    {
        private readonly ISystemSettingsProvider _systemSettingsProvider;

        private readonly IImporter[] _importers;
        private readonly IUpdater[] _updaters;

        public IProviderConfiguration Configuration { get; }

        public GoogleProvider(
            IProviderConfiguration configuration, 
            ISystemSettingsProvider systemSettingsProvider,
            IMailImporter mailImporter,
            ICalendarImporter calendarImporter,
            IPeopleImporter peopleImporter,
            IPeopleApiUpdater peopleApiUpdater)
        {
            Configuration = configuration;
            _systemSettingsProvider = systemSettingsProvider;
            _importers = new IImporter[]
            {
                mailImporter,
                calendarImporter,
                peopleImporter,
            };

            _updaters = new IUpdater[]
            {
                peopleApiUpdater
            };
        }

        public void Stop()
        {
            foreach (var importer in _importers)
            {
                importer.Stop();
            }
            foreach (var updater in _updaters)
            {
                updater.Stop();
            }
        }

        public void Start()
        {
            var task = _systemSettingsProvider.Update();
            task.Wait();
            
            foreach (var updater in _updaters)
            {
                updater.Start();
            }
            foreach (var importer in _importers)
            {
                importer.Start();
            }
        }
    }
}
