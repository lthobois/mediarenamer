// *******************************************************************************
//	Title:			ShelExRenamer.cs
//	Description:	TV Show Renamer shell extension
//	Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************


using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using MediaRenamer;


namespace ShellExt
{
	[Guid("6B3A1F0C-C382-40d6-AA13-33B0AB46EEAA")]
	public class MediaRenamerContextMenu: IShellExtInit, IContextMenu
	{

		#region Protected Members
		protected const string guid = "{6B3A1F0C-C382-40d6-AA13-33B0AB46EEAA}";
		protected uint m_hDrop = 0;

		#endregion

		#region IContextMenu
		// IContextMenu
		int	IContextMenu.QueryContextMenu(uint hMenu, uint iMenu, int idCmdFirst, int idCmdLast, uint uFlags)
		{
			uint nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
			String[] selectedFiles = new String[nselected];
			int needRenaming=0;
			for (int i=0; i<nselected; i++)
			{
				StringBuilder sb = new StringBuilder(1024);
				Helpers.DragQueryFile(m_hDrop, (uint)i, sb, sb.Capacity + 1);
				if (TVShowRenamer.Parser.validEpisodeFile(sb.ToString().ToLower()))
				{
					selectedFiles[i] = sb.ToString();
					needRenaming++;
				}
			}
			if (selectedFiles.Length == 0) return 0;
			if (needRenaming==0) return 0;
			// Create the popup to insert
			uint hmnuPopup = Helpers.CreatePopupMenu();

			int id = 1;
			if ( (uFlags & 0xf) == 0 || (uFlags & (uint)CMF.CMF_EXPLORE) != 0)
			{
				if (selectedFiles.Length > 0)
				{
					// Populate the popup menu with file-specific items
					id = PopulateMenu(hmnuPopup, idCmdFirst+ id);
				}
					
				// Add the popup to the context menu
				MENUITEMINFO mii = new MENUITEMINFO();
				mii.cbSize = 48;
				mii.fMask = (uint) MIIM.TYPE | (uint)MIIM.STATE | (uint) MIIM.SUBMENU;
				mii.hSubMenu = (int) hmnuPopup;
				mii.fType = (uint) MF.STRING;
				mii.dwTypeData = "MediaRenamer";
				mii.fState = (uint) MF.ENABLED;
				Helpers.InsertMenuItem(hMenu, (uint)iMenu, 1, ref mii);

				// Add a separator
				/*
				MENUITEMINFO sep = new MENUITEMINFO();
				sep.cbSize = 48;
				sep.fMask = (uint )MIIM.TYPE;
				sep.fType = (uint) MF.SEPARATOR;
				Helpers.InsertMenuItem(hMenu, iMenu+1, 1, ref sep);
				*/
			}
			return id;
		}

		void AddMenuItem(uint hMenu, string text, int id, uint position)
		{
			MENUITEMINFO mii = new MENUITEMINFO();
			mii.cbSize = 48;
			mii.fMask = (uint)MIIM.ID | (uint)MIIM.TYPE | (uint)MIIM.STATE;
			mii.wID	= id;
			mii.fType = (uint)MF.STRING;
			mii.dwTypeData	= text;
			mii.fState = (uint)MF.ENABLED;
			Helpers.InsertMenuItem(hMenu, position, 1, ref mii);
		}

		void AddSeperator(uint hMenu, uint position)
		{
			MENUITEMINFO sep = new MENUITEMINFO();
			sep.cbSize = 48;
			sep.fMask = (uint )MIIM.TYPE;
			sep.fType = (uint) MF.SEPARATOR;
			Helpers.InsertMenuItem(hMenu, position, 1, ref sep);
		}

		int PopulateMenu(uint hMenu, int id)
		{
			// Grab some info about the file
			AddMenuItem(hMenu, i18n.t("shell_search"), id, 0);
			AddMenuItem(hMenu, i18n.t("shell_rename"), ++id, 1);
			AddMenuItem(hMenu, i18n.t("shell_movie"), ++id, 2);
			AddSeperator(hMenu, 3);
			AddMenuItem(hMenu, i18n.t("shell_launchtv"), ++id, 4);
			AddMenuItem(hMenu, i18n.t("shell_launchmovie"), ++id, 5);
			return id++;
		}
		

		void IContextMenu.GetCommandString(int idCmd, uint uFlags, int pwReserved, StringBuilder commandString, int cchMax)
		{
			switch(uFlags)
			{
			case (uint)GCS.VERB:
				commandString = new StringBuilder("...");
				break;
			case (uint)GCS.HELPTEXT:
				commandString = new StringBuilder("..."); 
				break;
			}
		}

		
		void IContextMenu.InvokeCommand (IntPtr pici)
		{
			try
			{
				Type typINVOKECOMMANDINFO = Type.GetType("ShellExt.INVOKECOMMANDINFO");
				INVOKECOMMANDINFO ici = (INVOKECOMMANDINFO)Marshal.PtrToStructure(pici, typINVOKECOMMANDINFO);

				uint nselected = Helpers.DragQueryFile(m_hDrop, 0xffffffff, null, 0);
				String[] selectedFiles = new String[nselected];
				for (int i=0; i<nselected; i++)
				{
					StringBuilder sb = new StringBuilder(1024);
					Helpers.DragQueryFile(m_hDrop, (uint)i, sb, sb.Capacity + 1);
					String fileName = sb.ToString();
					selectedFiles[i] = fileName;
					if (TVShowRenamer.Parser.validEpisodeFile(fileName))
					{
						selectedFiles[i] = fileName;
					}
				}
				if (selectedFiles.Length == 0) return;

				Array.Sort(selectedFiles);

				TVShowRenamer.Parser parse = new TVShowRenamer.Parser();
				TVShowRenamer.Episode ep = null;
				MovieRenamer.Movie movie = null;
				String[] renamedFiles = null;
				bool needRenaming = false;
				FileInfo fi = null;
				switch (ici.verb-1)
				{
					case 0:
						renamedFiles = new String[selectedFiles.Length];
						needRenaming = false;
						for (int i=0; i<selectedFiles.Length; i++)
						{
							if (selectedFiles[i] == null) continue;

							ep = new TVShowRenamer.Episode(selectedFiles[i]);
							ep = parse.parseFile(selectedFiles[i]);
							if (ep.needRenaming() && !ep.special) 
							{
								fi = new FileInfo(ep.filename);
								String dir = fi.DirectoryName;
								if (!dir.EndsWith(@"\")) dir += @"\";
								renamedFiles[i] = dir+ep.modifiedName()+fi.Extension;
								needRenaming = true;
							}
							else
							{
								renamedFiles[i] = null;
							}
						}

						String msg = i18n.t("shell_newname")+"\n";
						for (int i=0; i<selectedFiles.Length; i++)
						{
							if (renamedFiles[i] != null)
							{
								msg += new FileInfo(renamedFiles[i]).Name+"\n";
							}
						}
						msg += "\n"+i18n.t("shell_question");

						if (needRenaming)
						{
							if (MessageBox.Show(msg, 
								"MediaRenamer",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
							{
								for (int i=0; i<selectedFiles.Length; i++)
								{
									if (renamedFiles[i] != null)
									{
										fi = new FileInfo(selectedFiles[i]);
										fi.MoveTo(renamedFiles[i]);
									}
								}
							}
						}
						else 
						{
							MessageBox.Show(i18n.t("shell_nonew"), "MediaRenamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						break;
					case 1:
						for (int i=0; i<selectedFiles.Length; i++)
						{
							ep = new TVShowRenamer.Episode(selectedFiles[i]);
							ep = parse.parseFile(selectedFiles[i]);
							if (ep.needRenaming() && !ep.special) 
							{
								fi = new FileInfo(ep.filename);
								String dir = fi.DirectoryName;
								if (!dir.EndsWith(@"\")) dir += @"\";
								fi.MoveTo(dir+ep.modifiedName()+fi.Extension);
							}
						}
						break;
					case 2:
						renamedFiles = new String[selectedFiles.Length];
						needRenaming = false;
						for (int i=0; i<selectedFiles.Length; i++)
						{
							if (selectedFiles[i] == null) continue;

							MovieRenamer.Parser p = new MovieRenamer.Parser( Directory.GetParent(selectedFiles[i]).FullName.ToString() );
							movie = p.parseFile(selectedFiles[i]);

							if ( movie.needRenaming() )
							{
								fi = new FileInfo(movie.filename);
								String dir = fi.DirectoryName;
								if (!dir.EndsWith(@"\")) dir += @"\";
								renamedFiles[i] = dir+movie.modifiedName()+fi.Extension;
								needRenaming = true;
							}
							else
							{
								renamedFiles[i] = null;
							}
						}

						String msg2 = i18n.t("shell_newname")+"\n";
						for (int i=0; i<selectedFiles.Length; i++)
						{
							if (renamedFiles[i] != null)
							{
								msg2 += new FileInfo(renamedFiles[i]).Name+"\n";
							}
						}
						msg2 += "\n"+i18n.t("shell_question");


						if (needRenaming)
						{
							if (MessageBox.Show(msg2, 
								"MediaRenamer",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
							{
								for (int i=0; i<selectedFiles.Length; i++)
								{
									if (renamedFiles[i] != null)
									{
										fi = new FileInfo(selectedFiles[i]);
										fi.MoveTo(renamedFiles[i]);
									}
								}
							}
						}
						else 
						{
							MessageBox.Show(i18n.t("shell_nonew"), "MediaRenamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						break;
					case 3:
						RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer");
						String exeFile = key.GetValue("path").ToString()+@"\TVShowRenamer.exe";
						key.Close();
						System.Diagnostics.Process.Start(exeFile);
						break;
					case 4:
						RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer");
						String exeFile2 = key2.GetValue("path").ToString()+@"\MovieRenamer.exe";
						key2.Close();
						System.Diagnostics.Process.Start(exeFile2);
						break;
				}
			}
			catch(Exception E)
			{
				MessageBox.Show("Crashed: "+E.Message);
			}
		}
		#endregion

		#region IShellExtInit
		int	IShellExtInit.Initialize (IntPtr pidlFolder, IntPtr lpdobj, uint hKeyProgID)
		{
			try
			{
				if (lpdobj != (IntPtr)0)
				{
					// Get info about the directory
					IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(lpdobj);
					FORMATETC fmt = new FORMATETC();
					fmt.cfFormat = CLIPFORMAT.CF_HDROP;
					fmt.ptd		 = 0;
					fmt.dwAspect = DVASPECT.DVASPECT_CONTENT;
					fmt.lindex	 = -1;
					fmt.tymed	 = TYMED.TYMED_HGLOBAL;
					STGMEDIUM medium = new STGMEDIUM();
					dataObject.GetData(ref fmt, ref medium);
					m_hDrop = medium.hGlobal;
				}
			}
			catch(Exception)
			{
			}
			return 0;
		}

		#endregion
		
		#region Registration
		[System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
		static void RegisterServer(String str1)
		{
			try
			{
				// For Winnt set me as an approved shellex
				//System.Console.WriteLine("Registering");
				RegistryKey root;
				RegistryKey rk;
				root = Registry.LocalMachine;
				rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
				rk.SetValue(guid.ToString(), "TV Show Renamer shell extension");
				rk.Close();

				//System.Console.WriteLine("General Registering done");
				// Set "Folder\\shellex\\ContextMenuHandlers\\TV_Show_Renamer" regkey to my guid
				root = Registry.ClassesRoot;
				String[] extension = TVShowRenamer.Parser.extension;
				foreach (String ext in extension)
				{
					//System.Console.WriteLine("Registering for "+ext);
					rk = root.OpenSubKey(ext);
					if (rk == null) continue;
					String dk = (String)rk.GetValue("");
					rk.Close();
					if (dk != null)
					{
						//System.Console.WriteLine("Writing contexthandler for "+dk);
						rk = root.CreateSubKey(dk+"\\shellex\\ContextMenuHandlers\\TVShowRenamer");
						rk.SetValue("", guid.ToString());
						rk.Close();
					}
				}
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}

		[System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
		static void UnregisterServer(String str1)
		{
			try
			{
				RegistryKey root;
				RegistryKey rk;

				// Remove ShellExtenstions registration
				root = Registry.LocalMachine;
				rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
				rk.DeleteValue(guid, false);
				rk.Close();

				// Delete  regkey
				root = Registry.ClassesRoot;
				String[] extension = TVShowRenamer.Parser.extension;
				foreach (String ext in extension)
				{
					rk = root.OpenSubKey(ext);
					if (rk == null) continue;
					String dk = (String)rk.GetValue("");
					rk.Close();
					if (dk != null)
					{
						rk = root.OpenSubKey(dk+"\\shellex\\ContextMenuHandlers", true);
						rk.DeleteSubKey("TVShowRenamer", false);
						rk.Close();
					}
				}
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}
		#endregion

	}
}
