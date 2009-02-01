/**
 * Copyright 2009 Benjamin Schirmer
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace MediaRenamer.Common
{
    class WindowsAPI
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindFirstChangeNotification(string path, bool sub, FileNotifyChange filt);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool FindNextChangeNotification(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool FindCloseChangeNotification(IntPtr handle);
    }

    #region SHFileOperationFlag
    public enum FileNotifyChange
    {
        /// <summary> FILE_NOTIFY_CHANGE_FILE_NAME </summary>
        FileName = 0x00000001,
        /// <summary> FILE_NOTIFY_CHANGE_DIR_NAME </summary>
        DirName = 0x00000002,
        /// <summary> FILE_NOTIFY_CHANGE_ATTRIBUTES </summary>
        Attributes = 0x00000004,
        /// <summary> FILE_NOTIFY_CHANGE_SIZE </summary>
        Size = 0x00000008,
        /// <summary> FILE_NOTIFY_CHANGE_LAST_WRITE </summary>
        LastWrite = 0x00000010,
        /// <summary> FILE_NOTIFY_CHANGE_LAST_ACCESS </summary>
        LastAccess = 0x00000020,
        /// <summary> FILE_NOTIFY_CHANGE_CREATION </summary>
        Creation = 0x00000040,
        /// <summary> FILE_NOTIFY_CHANGE_SECURITY </summary>
        Security = 0x00000100
    }
    #endregion
    public class ChangeEvent : WaitHandle
    {
        public ChangeEvent(string path, bool sub, FileNotifyChange filt)
        {
            Handle = WindowsAPI.FindFirstChangeNotification(path, sub, filt);
            if (Handle == InvalidHandle)
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
        }

        public void Next()
        {
            bool ok = WindowsAPI.FindNextChangeNotification(Handle);
            if (!ok)
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
        }

        protected override void Dispose(bool x)
        {
            bool ok;
            if (Handle != InvalidHandle)
                ok = WindowsAPI.FindCloseChangeNotification(Handle);
            Handle = InvalidHandle;
        }
    }

    public delegate void FileSystemChangeHandler();

    /// <summary>
    /// FileSystemWatcher
    /// </summary>
    public class FileSystemWatcher
    {
        ManualResetEvent endEvent;
        private string watchFolderPath;
        private bool watchSubfolders = true;
        private FileNotifyChange watchFor = FileNotifyChange.Size;

        #region get/set Methods

        public string WatchFolderPath
        {
            get
            {
                return watchFolderPath;
            }
            set
            {
                watchFolderPath = value;
            }
        }

        public bool WatchSubfolders
        {
            get
            {
                return watchSubfolders;
            }
            set
            {
                watchSubfolders = value;
            }
        }

        public FileNotifyChange WatchForChange
        {
            get
            {
                return watchFor;
            }
            set
            {
                watchFor = value;
            }
        }

        #endregion

        public event FileSystemChangeHandler Change;

        protected virtual void OnChange()
        {
            FileSystemChangeHandler handler = Change;
            if (handler != null)
            {
                handler();
            }
        }

        public void EndSet()
        {
            endEvent.Set();
        }

        public void Run()
        {
            endEvent = new ManualResetEvent(false);
            ChangeEvent fileFolderChange = new ChangeEvent(watchFolderPath, watchSubfolders, watchFor);
            WaitHandle[] waits = new WaitHandle[2] { fileFolderChange, endEvent };
            do
            {
                int waitStatus = WaitHandle.WaitAny(waits);
                if (waitStatus == 0)
                {
                    OnChange();
                    // Go to next Event
                    fileFolderChange.Next();
                }
                else
                {
                    break;
                }
            }
            while (true);

            fileFolderChange.Close();
        }
    }
}
