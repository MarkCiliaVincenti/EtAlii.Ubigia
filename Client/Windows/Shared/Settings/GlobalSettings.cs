﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EtAlii.Ubigia.Client.Windows
{
    public class GlobalSettings : BindableSettingsBase
    {
        public bool StartAutomatically { get { return GetValue(ref _startAutomatically, true); } set { SetProperty(ref _startAutomatically, value); } }
        private Nullable<bool> _startAutomatically;

        public bool RememberLoginCredentials { get { return GetValue(ref _rememberLoginCredentials, false); } set { SetProperty(ref _rememberLoginCredentials, value); } }
        private Nullable<bool> _rememberLoginCredentials;

        public bool AutomaticallySendLogFiles { get { return GetValue(ref _automaticallySendLogFiles, true); } set { SetProperty(ref _automaticallySendLogFiles, value); } }
        private Nullable<bool> _automaticallySendLogFiles;

        public string ConsoleTarget { get { return GetValue(ref _consoleTarget, null); } set { SetProperty(ref _consoleTarget, value); } }
        private string _consoleTarget;

        public ObservableCollection<StorageSettings> Storage { get { return _storage; } }
        private readonly ObservableCollection<StorageSettings> _storage = new ObservableCollection<StorageSettings>();

        public GlobalSettings()
        {
            using (var storagesKey = GetSubKey(Settings.StoragesNaming))
            {
                foreach (var storageKey in storagesKey.GetSubKeyNames())
                {
                    var storageSettings = new StorageSettings(storageKey);
                    Storage.Add(storageSettings);
                }
            }

            Storage.CollectionChanged += OnStorageSettingsChanged;
        }

        void OnStorageSettingsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    foreach (StorageSettings storageSettings in e.OldItems)
                    {
                        storageSettings.Delete();
                    }
                    break;
            }
        }
    }
}
