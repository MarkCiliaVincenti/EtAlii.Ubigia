﻿namespace EtAlii.Ubigia.Windows.Diagnostics.StorageBrowser
{
    using EtAlii.Ubigia.Api.Management;
    using EtAlii.xTechnology.Logging;
    using EtAlii.xTechnology.Mvvm;

    public class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        public IStoragesViewModel Storages { get { return _storages; } }
        private readonly IStoragesViewModel _storages;

        public IAccountsViewModel Accounts { get { return _accounts; } }
        private readonly IAccountsViewModel _accounts;

        public ISpacesViewModel Spaces { get { return _spaces; } }
        private readonly ISpacesViewModel _spaces;

        public IRolesViewModel Roles { get { return _roles; } }
        private readonly IRolesViewModel _roles;

        protected IManagementConnection Connection { get { return _connection; } }
        private readonly IManagementConnection _connection;

        private readonly ILogger _logger;

        public MainWindowViewModel(
            IManagementConnection connection, 
            IStoragesViewModel storagesViewModel,
            IAccountsViewModel accountsViewModel, 
            ISpacesViewModel spacesViewModel, 
            IRolesViewModel rolesViewModel,
            ILogger logger)
        {
            _logger = logger;   
            _connection = connection;
            _storages = storagesViewModel;
            _accounts = accountsViewModel;
            _spaces = spacesViewModel;
            _roles = rolesViewModel;

            Accounts.PropertyChanged += OnAccountsPropertyChanged; 
        }

        void OnAccountsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case AccountsViewModel.SelectedAccountProperty:
                    Spaces.SelectedAccount = Accounts.SelectedAccount;
                    Roles.SelectedAccount = Accounts.SelectedAccount;
                    break;
            }
        }
    }
}
