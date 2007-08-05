using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using MediaRenamer.Common;

namespace MediaRenamerService
{
    public partial class MediaRenamerService : ServiceBase
    {

        WatchedFolderEntry[] watchedFolders;

        public MediaRenamerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            loadFolders();
        }

        private void loadFolders()
        {
            Object[] items = Settings.GetValueAsArray(SettingKeys.WatchedFolders);
            watchedFolders = new WatchedFolderEntry[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                watchedFolders[i] = (WatchedFolderEntry)items[i];
            }
        }

        protected override void OnStop()
        {
            foreach (WatchedFolderEntry folder in watchedFolders)
            {
                folder.stopThread();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            foreach (WatchedFolderEntry folder in watchedFolders)
            {
                folder.stopThread();
            }
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            loadFolders();
        }
    }
}
