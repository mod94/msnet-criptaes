using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;

namespace Cript
{
    public class MID
    {

		private static string mid = string.Empty;

		public static string GetMID()
		{
			if((mid != null) && (mid.Length > 0)) return mid;
			mid = string.Empty;
			mid += GetVolumeSerial(null);
			mid += GetMACAddress();
			mid += GetCPUId();
			mid += RunQuery("BaseBoard", "Product");
			mid += RunQuery("BaseBoard", "Manufacturer");
			return mid;
		}

		private static string RunQuery(string TableName, string MethodName)
		{
			ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_" + TableName);
			foreach(ManagementObject mo in mos.Get())
			{
				try
				{
					return mo[MethodName].ToString();
				}
				catch
				{
				}
				finally
				{
					mo.Dispose();
				}
			}
			return string.Empty;
		}

		private static string GetVolumeSerial(string strDriveLetter)
		{
			string t = string.Empty;
			try
			{
				if( (strDriveLetter==null) || strDriveLetter.Equals(string.Empty)) strDriveLetter="C";
				ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter +":\"");
				disk.Get();
				t = disk["VolumeSerialNumber"].ToString();
				disk.Dispose();
			}
			catch{}
			return t;
		}

		private static string GetMACAddress()
		{
			string MACAddress=String.Empty;
			try
			{
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach(ManagementObject mo in moc)
				{
					if(MACAddress.Equals(String.Empty))  // only return MAC Address from first card
					{
						if((bool)mo["IPEnabled"] == true)
						{
							MACAddress= mo["MacAddress"].ToString();
							mo.Dispose();
							break;
						}
					}
					mo.Dispose();
				}
			}
			catch{}
			//MACAddress=MACAddress.Replace(":","");
			return MACAddress;
		}

		private static string GetCPUId()
		{
			string cpuInfo =  String.Empty;
			try
			{
				ManagementClass mc = new ManagementClass("Win32_Processor");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach(ManagementObject mo in moc)
				{
					if(cpuInfo.Equals(String.Empty))
					{// only return cpuInfo from first CPU
						cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
						mo.Dispose();
						break;
					}
					mo.Dispose();
				}
			}
			catch{}
			return cpuInfo;
		}
    }//EOC
}