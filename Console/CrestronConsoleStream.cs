using System;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;

namespace Crestron.SimplSharp.CrestronIO
	{
	public class CrestronConsoleStream : Stream
		{
		public override bool CanRead
			{
			get { throw new NotImplementedException (); }
			}

		public override bool CanSeek
			{
			get { return false; }
			}

		public override bool CanWrite
			{
			get { return true; }
			}

		public override long Length
			{
			get { throw new NotImplementedException (); }
			}

		public override long Position
			{
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
			}

		public override void Flush ()
			{
			}

		public override int Read (byte[] buffer, int offset, int count)
			{
			throw new NotImplementedException ();
			}

		public override long Seek (long offset, SeekOrigin origin)
			{
			throw new NotImplementedException ();
			}

		public override void SetLength (long value)
			{
			throw new NotImplementedException ();
			}

		public override void Write (byte[] buffer, int offset, int count)
			{
			CrestronConsole.Print (Encoding.ASCII.GetString (buffer, offset, count));
			}
		}

	public class CrestronConsoleTextWriter : StreamWriter
		{
		public CrestronConsoleTextWriter ()
			: base (new CrestronConsoleStream (), Encoding.ASCII)
			{
			base.AutoFlush = true;
			}

		}
	}