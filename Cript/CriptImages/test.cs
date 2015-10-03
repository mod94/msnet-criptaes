using System;
using System.IO;
using System.Security.Cryptography;

public class T
{
	public static void Main()
	{
		FileStream fs = File.OpenRead("App.ico");
		SHA256Managed sha256 = new SHA256Managed();
		byte[] b = sha256.ComputeHash(fs);
		fs.Close();
		PB(b);
		fs = File.OpenRead("App.ico");
		sha256 = new SHA256Managed();
		byte[] buffer = new byte[0x1000];
		while(true)
		{
			int n = fs.Read(buffer, 0, 0x1000);
			if(n == 0x1000)
			{
				sha256.TransformBlock(buffer, 0, 0x1000, buffer, 0);
			}
			else
			{
				sha256.TransformFinalBlock(buffer, 0, n);
				break;
			}
		}
		fs.Close();
		PB(sha256.Hash);

	}

	private static void PB(byte[] b)
	{
		if(b == null)
		{ Console.WriteLine("NULL"); return; }
		for(int i = 0; i < b.Length; i++)
		Console.Write(b[i].ToString("X") + " ");
		Console.WriteLine("");
	}
}