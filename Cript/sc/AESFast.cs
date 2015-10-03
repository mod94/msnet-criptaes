using System;
using sc;

namespace aes {

public sealed class AESFast : IBlockCipher
{
	AESFastEngine en = null;
	AESFastEngine de = null;

	public AESFast()
	{}

	public bool InitCipher(byte[] key)
	{
		en = new AESFastEngine();
		en.init(true, key);
		de = new AESFastEngine();
		de.init(false, key);
		return true;
	}

	public void Cipher(byte[] inb, byte[] outb)
	{
		en.processBlock(inb, 0, outb, 0);
	}

	public void InvCipher(byte[] inb, byte[] outb)
	{
		de.processBlock(inb, 0, outb, 0);
	}

	public int[] KeySizesInBytes()
	{
		return new int[] {16, 24, 32};
	}

	public int BlockSizeInBytes()
	{
		return 16;
	}

}//EOC

}