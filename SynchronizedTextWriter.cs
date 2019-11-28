//
// System.IO.TextWriter.cs
//
// Authors:
//   Marcin Szczepanski (marcins@zipworld.com.au)
//   Miguel de Icaza (miguel@gnome.org)
//   Paolo Molaro (lupus@ximian.com)
//   Marek Safar (marek.safar@gmail.com)

//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
// Copyright 2011 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Text;
#if SSHARP
using Crestron.SimplSharp;
using GC = Crestron.SimplSharp.CrestronEnvironment.GC;
#if NET_4_5
using SSMono.Threading.Tasks;
#endif
#else
#endif
using System.Runtime.InteropServices;

#if SSPRO
namespace SSMono.IO.Async
#elif SSHARP
namespace Crestron.SimplSharp.CrestronIO
#else
namespace System.IO
#endif
	{
	//
	// Sychronized version of the TextWriter.
	//
	[Serializable]
	internal sealed class SynchronizedWriter : TextWriter
		{
		private TextWriter writer;
		private bool neverClose;

		public SynchronizedWriter (TextWriter writer)
			: this (writer, false)
			{
			}

		public SynchronizedWriter (TextWriter writer, bool neverClose)
			{
			this.writer = writer;
			this.neverClose = neverClose;
			}

		public override void Close ()
			{
			if (neverClose)
				return;

			lock (this)
				{
				writer.Close ();
				}
			}

		protected override void Dispose (bool disposing)
			{
			if (!neverClose && disposing)
				{
				lock (this)
					{
					writer.Dispose ();
					}
				}
			}

		public override void Flush ()
			{
			lock (this)
				{
				writer.Flush ();
				}
			}

		#region Write methods

		public override void Write (bool value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (char value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (char[] value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (Decimal value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (int value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (long value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (object value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (float value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (double value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (string value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (uint value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (ulong value)
			{
			lock (this)
				{
				writer.Write (value);
				}
			}

		public override void Write (string format, object value)
			{
			lock (this)
				{
				writer.Write (format, value);
				}
			}

		public override void Write (string format, object[] value)
			{
			lock (this)
				{
				writer.Write (format, value);
				}
			}

		public override void Write (char[] buffer, int index, int count)
			{
			lock (this)
				{
				writer.Write (buffer, index, count);
				}
			}

		public override void Write (string format, object arg0, object arg1)
			{
			lock (this)
				{
				writer.Write (format, arg0, arg1);
				}
			}

		public void Write (string format, object arg0, object arg1, object arg2)
			{
			lock (this)
				{
				writer.Write (format, arg0, arg1, arg2);
				}
			}

		#endregion

		#region WriteLine methods

		public override void WriteLine ()
			{
			lock (this)
				{
				writer.WriteLine ();
				}
			}

		public override void WriteLine (bool value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (char value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (char[] value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (Decimal value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (double value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (int value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (long value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (object value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (float value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (string value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (uint value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (ulong value)
			{
			lock (this)
				{
				writer.WriteLine (value);
				}
			}

		public override void WriteLine (string format, object value)
			{
			lock (this)
				{
				writer.WriteLine (format, value);
				}
			}

		public override void WriteLine (string format, object[] value)
			{
			lock (this)
				{
				writer.WriteLine (format, value);
				}
			}

		public override void WriteLine (char[] buffer, int index, int count)
			{
			lock (this)
				{
				writer.WriteLine (buffer, index, count);
				}
			}

		public override void WriteLine (string format, object arg0, object arg1)
			{
			lock (this)
				{
				writer.WriteLine (format, arg0, arg1);
				}
			}

		public void WriteLine (string format, object arg0, object arg1, object arg2)
			{
			lock (this)
				{
				writer.WriteLine (format, arg0, arg1, arg2);
				}
			}

		#endregion

#if NET_4_5
		public override Task FlushAsync ()
			{
			lock (this)
				{
				return writer.FlushAsync ();
				}
			}

		public override Task WriteAsync (char value)
			{
			lock (this)
				{
				return writer.WriteAsync (value);
				}
			}

		public override Task WriteAsync (char[] buffer, int index, int count)
			{
			lock (this)
				{
				return writer.WriteAsync (buffer, index, count);
				}
			}

		public override Task WriteAsync (string value)
			{
			lock (this)
				{
				return writer.WriteAsync (value);
				}
			}

		public override Task WriteLineAsync ()
			{
			lock (this)
				{
				return writer.WriteLineAsync ();
				}
			}

		public override Task WriteLineAsync (char value)
			{
			lock (this)
				{
				return writer.WriteLineAsync (value);
				}
			}

		public override Task WriteLineAsync (char[] buffer, int index, int count)
			{
			lock (this)
				{
				return writer.WriteLineAsync (buffer, index, count);
				}
			}

		public override Task WriteLineAsync (string value)
			{
			lock (this)
				{
				return writer.WriteLineAsync (value);
				}
			}
#endif

		public override Encoding Encoding
			{
			get
				{
				lock (this)
					{
					return writer.Encoding;
					}
				}
			}

		public override IFormatProvider FormatProvider
			{
			get
				{
				lock (this)
					{
					return writer.FormatProvider;
					}
				}
			}

		public override string NewLine
			{
			get
				{
				lock (this)
					{
					return writer.NewLine;
					}
				}

			set
				{
				lock (this)
					{
					writer.NewLine = value;
					}
				}
			}
		}

	public static class TextWriterEx
		{
		public static TextWriter Synchronized (TextWriter writer)
			{
			return Synchronized (writer, false);
			}

		internal static TextWriter Synchronized (TextWriter writer, bool neverClose)
			{
			if (writer == null)
				throw new ArgumentNullException ("writer is null");

			if (writer is SynchronizedWriter)
				return writer;

			return new SynchronizedWriter (writer, neverClose);
			}
		}
	}