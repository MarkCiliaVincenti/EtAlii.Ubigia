﻿namespace EtAlii.Ubigia.Windows.Tools.MediaImport
{
    using System;
    using System.ComponentModel;
    using EtAlii.xTechnology.Mvvm;
    using EtAlii.xTechnology.Structure;

    internal class ItemUpdater : BindableBase, IItemUpdater
    {
        public FolderSyncConfiguration Configuration { get { return _configuration; } set { SetProperty(ref _configuration, value); } }
        private FolderSyncConfiguration _configuration;

        private readonly ISelector<ItemCheckAction, IItemUpdateHandler> _selector;
        private string _remoteStart;
        private string _localStart;

        public ItemUpdater(
            IItemCreatedHandler itemCreatedHandler,
            IItemDestroyedHandler itemDestroyedHandler,
            IItemChangedHandler itemChangedHandler,
            IItemRenameHandler itemRenameHandler)
        {
            PropertyChanged += OnPropertyChanged;

            _selector = new Selector<ItemCheckAction, IItemUpdateHandler>()
                .Register(a => a.Change == ItemChange.Created, itemCreatedHandler)
                .Register(a => a.Change == ItemChange.Destroyed, itemDestroyedHandler)
                .Register(a => a.Change == ItemChange.Changed && a.OldItem == null, itemChangedHandler)
                .Register(a => a.Change == ItemChange.Changed && a.OldItem != null, itemRenameHandler);
        }

        public void Update(ItemCheckAction action)
        {
            var handler = _selector.TrySelect(action);
            handler?.Handle(action, _localStart, _remoteStart);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Configuration":
                    _remoteStart =
                        $"\"{String.Join("\"/\"", Configuration.RemoteName.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries))}\"";
                    _localStart = Configuration.LocalFolder;
                    break;
            }
        }
    }
}
