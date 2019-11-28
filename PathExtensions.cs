using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace Crestron.SimplSharp.CrestronIO
	{
	public static class PathEx
		{
		public static string GetTempFileName ()
			{
			FileStream f = null;
			string path;
			int count = 0;

			var rnd = new Random ();
			do
				{
				int num = rnd.Next ();
				num++;
				path = Path.Combine (GetTempPath (), "tmp" + num.ToString ("x") + ".tmp");

				try
					{
					f = new FileStream (path, FileMode.CreateNew, (FileAccess)FileAccess.ReadWrite);
					}
				catch (IOException)
					{
					if (!File.Exists (path) || count++ > 65536)
						throw;
					}
				catch (UnauthorizedAccessException ex)
					{
					if (count++ > 65536)
						throw new IOException (ex.Message, ex);
					}
				} while (f == null);

			f.Close ();
			return path;
			}

		public static string GetTempPath ()
			{
			return String.Format ("\\Nvram\\App{0:D2}\\Temp\\{1}\\", InitialParametersClass.ApplicationNumber, InitialParametersClass.ProgramIDTag);
			}

		public static string GetFullPath (string path)
			{
			if (string.IsNullOrEmpty (path) || Path.IsPathRooted (path))
				return path;

			return Path.Combine (InitialParametersClass.ProgramDirectory.ToString (), path);
			}

		internal static bool IsDsc (char c)
			{
			return c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar;
			}

		internal static string DirectorySeparatorStr = Convert.ToString (Path.DirectorySeparatorChar);

		public static string GetPathRoot (string path)
			{
			if (path == null)
				return null;

			if (path.Trim ().Length == 0)
				throw new ArgumentException ("The specified path is not of a legal form.");

			if (!Path.IsPathRooted (path))
				return String.Empty;

			if (Path.DirectorySeparatorChar == '/')
				{
				// UNIX
				return IsDsc (path[0]) ? DirectorySeparatorStr : String.Empty;
				}
			else
				{
				// Windows
				int len = 2;

				if (path.Length == 1 && IsDsc (path[0]))
					return DirectorySeparatorStr;
				else if (path.Length < 2)
					return String.Empty;

				if (IsDsc (path[0]) && IsDsc (path[1]))
					{
					// UNC: \\server or \\server\share
					// Get server
					while (len < path.Length && !IsDsc (path[len]))
						len++;

					// Get share
					if (len < path.Length)
						{
						len++;
						while (len < path.Length && !IsDsc (path[len]))
							len++;
						}

					return DirectorySeparatorStr +
					       DirectorySeparatorStr +
					       path.Substring (2, len - 2).Replace (Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
					}
				else if (IsDsc (path[0]))
					{
					// path starts with '\' or '/'
					return DirectorySeparatorStr;
					}
				else if (path[1] == Path.VolumeSeparatorChar)
					{
					// C:\folder
					if (path.Length >= 3 && (IsDsc (path[2])))
						len++;
					}
				else
					return DirectorySeparatorStr;

				return path.Substring (0, len);
				}
			}

		public static string GetRandomFileName ()
			{
			// returns a 8.3 filename (total size 12)
			StringBuilder sb = new StringBuilder (12);
			// using strong crypto but without creating the file
			//RandomNumberGenerator rng = RandomNumberGenerator.Create ();
			var rng = new Random ();
			byte[] buffer = new byte[11];
			rng.NextBytes (buffer);

			for (int i = 0; i < buffer.Length; i++)
				{
				if (sb.Length == 8)
					sb.Append ('.');

				// restrict to length of range [a..z0..9]
				int b = (buffer[i] % 36);
				char c = (char)(b < 26 ? (b + 'a') : (b - 26 + '0'));
				sb.Append (c);
				}

			return sb.ToString ();
			}

		public static char[] GetInvalidFileNameChars ()
			{
			// return a new array as we do not want anyone to be able to change the values
			return new char[41]
				{
				'\x00', '\x01', '\x02', '\x03', '\x04', '\x05', '\x06', '\x07',
				'\x08', '\x09', '\x0A', '\x0B', '\x0C', '\x0D', '\x0E', '\x0F', '\x10', '\x11', '\x12',
				'\x13', '\x14', '\x15', '\x16', '\x17', '\x18', '\x19', '\x1A', '\x1B', '\x1C', '\x1D',
				'\x1E', '\x1F', '\x22', '\x3C', '\x3E', '\x7C', ':', '*', '?', '\\', '/'
				};
			}

		public static string ChangeExtension (string path, string extension)
			{
			return Path.ChangeExtension (path, extension);
			}

		public static string Combine (string path1, string path2)
			{
			return Path.Combine (path1, path2);
			}

		public static string Combine (string path1, string path2, string path3)
			{
			return Path.Combine(Path.Combine (path1, path2), path3);
			}

		public static string Combine (string path1, string path2, string path3, string path4)
			{
			return Path.Combine (Path.Combine(Path.Combine (path1, path2), path3), path4);
			}

		public static string Combine (params string[] paths)
			{
			if (paths.Length == 0)
				return String.Empty;
			if (paths.Length == 1)
				return paths[0];
			var result = Path.Combine (paths[0], paths[1]);
			if (paths.Length == 2)
				return result;
			for (int ix = 2; ix < paths.Length; ++ix)
				result = Path.Combine (result, paths[ix]);
			return result;
			}

		public static string GetDirectoryName (string path)
			{
			return Path.GetDirectoryName (path);
			}

		public static string GetExtension (string path)
			{
			return Path.GetExtension (path);
			}

		public static string GetFileName (string path)
			{
			return Path.GetFileName (path);
			}

		public static string GetFileNameWithoutExtension (string path)
			{
			return Path.GetFileNameWithoutExtension (path);
			}

		public static char[] GetInvalidPathChars ()
			{
			return Path.GetInvalidPathChars ();
			}

		public static bool HasExtension (string path)
			{
			return Path.HasExtension (path);
			}

		public static bool IsPathRooted (string path)
			{
			return Path.IsPathRooted (path);
			}

		public static long GetFreeSpace (string path)
			{
			return Path.GetFreeSpace (path);
			}

		public static readonly char AltDirectorySeparatorChar = Path.AltDirectorySeparatorChar;

		public static readonly char DirectorySeparatorChar = Path.DirectorySeparatorChar;

		public static readonly char PathSeparator = Path.PathSeparator;

		public static readonly char VolumeSeparatorChar = Path.VolumeSeparatorChar;
		}
	}