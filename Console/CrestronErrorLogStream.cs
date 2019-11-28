using System;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;

namespace Crestron.SimplSharp.CrestronIO
	{
	public class CrestronErrorLogStream : Stream
		{
		public override bool CanRead
			{
			get { return false; }
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
			throw new NotImplementedException ();
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
			ErrorLog.Notice (Encoding.ASCII.GetString (buffer, offset, count));
			}
		}

	public class CrestronErrorLogTextWriter : StreamWriter
		{
		public CrestronErrorLogTextWriter ()
			: base (new CrestronErrorLogStream ())
			{

			}
		}
	}