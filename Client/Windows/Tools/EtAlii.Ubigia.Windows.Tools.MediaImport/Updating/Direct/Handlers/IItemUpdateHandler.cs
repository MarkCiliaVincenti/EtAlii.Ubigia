﻿namespace EtAlii.Ubigia.Windows.Tools.MediaImport
{
    internal interface IItemUpdateHandler
    {
        void Handle(ItemCheckAction action, string localStart, string remoteStart);
    }
}
