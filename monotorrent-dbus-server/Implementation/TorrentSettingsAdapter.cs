// TorrentSettings.cs
//
// Copyright (c) 2008 Alan McGovern (alan.mcgovern@gmail.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System;
using NDesk.DBus;
using MonoTorrent.Client;

namespace MonoTorrent.DBus
{
	
	internal class TorrentSettingsAdapter : ITorrentSettings
	{
		private ObjectPath path;
		private TorrentSettings settings;
		
		public TorrentSettings Settings
		{
			get { return settings; }
		}
		
		public ObjectPath Path
		{
			get { return path; }
		}
		
		public bool InitialSeedingEnabled {
			get { return settings.InitialSeedingEnabled; }
			set { settings.InitialSeedingEnabled = value; }
		}

		public int MaxDownloadSpeed {
			get { return settings.MaxDownloadSpeed; }
			set { settings.MaxDownloadSpeed = value; }
		}

		public int MaxUploadSpeed {
			get { return settings.MaxUploadSpeed; }
			set { settings.MaxUploadSpeed = value; }
		}

		public int MaxConnections {
			get { return settings.MaxConnections; }
			set { settings.MaxConnections = value; }
		}

		public int UploadSlots {
			get { return settings.UploadSlots; }
			set { settings.UploadSlots = value; }
		}

		
		#region ITorrentSettings implementation 

		ObjectPath IExportable.GetPath ()
		{
			return Path;
		}
		
		bool ITorrentSettings.GetInitialSeedingEnabled ()
		{
			return InitialSeedingEnabled;
		}
		
		void ITorrentSettings.SetInitialSeedingEnabled (bool initialSeeding)
		{
			InitialSeedingEnabled = initialSeeding;
		}
		
		int ITorrentSettings.GetMaxDownloadSpeed ()
		{
			return MaxDownloadSpeed;
		}
		
		void ITorrentSettings.SetMaxDownloadSpeed (int maxSpeed)
		{
			MaxDownloadSpeed = maxSpeed;
		}
		
		int ITorrentSettings.GetMaxUploadSpeed ()
		{
			return MaxUploadSpeed;
		}
		
		void ITorrentSettings.SetMaxUploadSpeed (int maxSpeed)
		{
			MaxUploadSpeed = maxSpeed;
		}
		
		int ITorrentSettings.GetMaxConnections ()
		{
			return MaxConnections;
		}
		
		void ITorrentSettings.SetMaxConnections (int maxConnections)
		{
			MaxConnections = maxConnections;
		}
		
		int ITorrentSettings.GetUploadSlots ()
		{
			return UploadSlots;
		}
		
		void ITorrentSettings.SetUploadSlots (int slots)
		{
			UploadSlots = slots;
		}
		
		#endregion 
		
		
		public TorrentSettingsAdapter (TorrentSettings settings, ObjectPath path)
		{
			this.path = path;
			this.settings = settings;
		}
	}
}
