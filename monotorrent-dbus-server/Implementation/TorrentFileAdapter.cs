// TorrentFileAdapter.cs
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
using MonoTorrent.Common;
using NDesk.DBus;

namespace MonoTorrent.DBus
{
	internal class TorrentFileAdapter : ITorrentFile
	{
		private TorrentFile file;
		private ObjectPath path;
		
		public int EndPieceIndex {
			get { return file.EndPieceIndex; }
		}

		public long Length {
			get { return file.Length; }
		}

		public string FilePath {
			get { return file.Path; }
		}

		public ObjectPath Path {
			get { return path; }
		}
		
		public double Progress {
			get { return file.BitField.PercentComplete / 100.0f; }
		}

		public Priority Priority {
			get { return EnumAdapter.Adapt (file.Priority); }
			set { file.Priority = EnumAdapter.Adapt (value); }
		}

		public int StartPieceIndex {
			get { return file.StartPieceIndex; }
		}

		
		#region ITorrentFile implementation 

		ObjectPath IExportable.GetPath ()
		{
			return Path;
		}
		
		int ITorrentFile.GetEndPieceIndex ()
		{
			return EndPieceIndex;
		}
		
		long ITorrentFile.GetLength ()
		{
			return Length;
		}
		
		string ITorrentFile.GetFilePath ()
		{
			return FilePath;
		}
		
		double ITorrentFile.GetProgress ()
		{
			return Progress;
		}
		
		Priority ITorrentFile.GetPriority ()
		{
			return Priority;
		}
		
		void ITorrentFile.SetPriority (Priority priority)
		{
			Priority = priority;
		}
		
		int ITorrentFile.GetStartPieceIndex ()
		{
			return StartPieceIndex;
		}
		
		#endregion 
		
		
		
		public TorrentFileAdapter(TorrentFile file, ObjectPath path)
		{
			this.file = file;
			this.path = path;
		}
	}
}
