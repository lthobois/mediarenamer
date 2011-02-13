using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MediaRenamer.Common {
    public abstract class ParserBase {
        // Valid extensions
        internal String[] extension = {
            ".avi", ".mkv", ".mpg", ".mpeg", ".mov", ".wmv",
			".rpm", ".ogm", ".srt", ".sub", ".mp4", ".divx",
            ".idx", ".rar", ".ts", ".m2ts",".iso", ".smi"};

        internal String scanPath = "";

        public ParserBase(String path) {
            if (!path.EndsWith(@"\")) path += @"\";
            scanPath = path;
        }

        abstract internal void scanFolder(String folder);

        public void startScan() {
            if (scanPath == "")
                return;
            scanFolder(scanPath);
        }

        public event ScanProgressHandler ScanProgress;
        protected virtual void OnScanProgress(int pos, int max) {
            ScanProgressHandler handler = ScanProgress;
            if (handler != null) {
                handler.Invoke(pos, max);
            }
        }

        public event ScanDone ScanDone;
        protected virtual void OnScanDone() {
            ScanDone handler = ScanDone;
            if (handler != null) {
                handler.Invoke();
            }
        }

        /// <summary>
        /// Checks for valid extensions
        /// </summary>
        /// <param name="name">filename</param>
        /// <returns></returns>
        internal bool isValidExt(String name) {
            name = name.ToLower();
            foreach (String ext in extension) {
                if (name.EndsWith(ext)) return true;
            }
            return false;
        }

        protected bool isDVD(string filePath) {
            if (File.GetAttributes(filePath).HasFlag(FileAttributes.Directory)) {
                foreach (String subFilePath in Directory.GetFileSystemEntries(filePath)) {
                    if (subFilePath.ToUpper().EndsWith("VIDEO_TS")) {
                        if (File.GetAttributes(subFilePath).HasFlag(FileAttributes.Directory)) {
                            foreach (String childVIDEO_TS in Directory.GetFileSystemEntries(subFilePath)) {
                                if (childVIDEO_TS.ToUpper().EndsWith(".VOB"))
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
