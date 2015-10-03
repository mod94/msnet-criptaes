using System;
using System.Runtime.InteropServices;

namespace Cript
{
	internal sealed class DiskInfo
	{
		private DiskInfo()
		{}

		[DllImport("kernel32")]
		internal static extern int GetDiskFreeSpaceEx(
			string lpDirectoryName,                 // directory name
			ref ulong lpFreeBytesAvailable,    // bytes available to caller
			ref ulong lpTotalNumberOfBytes,    // bytes on disk
			ref ulong lpTotalNumberOfFreeBytes // free bytes on disk
			);

		internal static ulong FreeDiskSpace(string dir, ref ulong total)
		{
			ulong cf = 0, t = 0, f = 0;
			if((dir != null) && dir.StartsWith("\\\\"))
			{
				if(!dir.EndsWith("\\")) dir += "\\";
			}
			if(GetDiskFreeSpaceEx(dir, ref cf, ref t, ref f) == 0) return 0;
			total = t;
			return cf;
		}
	
	}//EOC
}
