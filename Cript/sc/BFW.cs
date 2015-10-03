using System;
using sc;

namespace aes {

public sealed class BFW : IBlockCipher, IDisposable
{
	public BFW()
	{}

	public bool InitCipher(byte[] key)
	{
		Init(key);
		return IsValid();
	}

	//inb, outb 8 bytes
	public void Cipher(byte[] inb, byte[] outb)
	{
		Encipher(inb, outb, 8);
	}

	//inb, outb 8 bytes
	public void InvCipher(byte[] inb, byte[] outb)
	{
		Decipher(inb, outb, 8);
	}

	public int[] KeySizesInBytes()
	{
		return new int[] {8, 16, 32, 24, 56};
	}

	public int BlockSizeInBytes()
	{
		return 8;
	}

	//////////////////////////////////////////////////////////

	public void Dispose()
	{
		Array.Clear(pbx, 0, pbx.Length);
		Array.Clear(sbx0, 0, sbx0.Length);
		Array.Clear(sbx1, 0, sbx1.Length);
		Array.Clear(sbx2, 0, sbx2.Length);
		Array.Clear(sbx3, 0, sbx3.Length);
		Array.Clear(blx, 0, blx.Length);
	}

	private uint[] pbx = new uint[BFC.PBE];
	private uint[] sbx0 = new uint[BFC.SBE];
	private uint[] sbx1 = new uint[BFC.SBE];
	private uint[] sbx2 = new uint[BFC.SBE];
	private uint[] sbx3 = new uint[BFC.SBE];
	private byte[] blx = new byte[BFC.BLOCK_SIZE];

	#region init
	internal bool Init(byte[] key)
	{
		if((key == null) || (key.Length <= 0)) return false;

		_Init();
		_InitPBX(key);

		uint unHi = 0;
		uint unLo = 0;
		_ExpandKey(pbx, BFC.PBE, ref unHi, ref unLo);
		_ExpandKey(sbx0, BFC.SBE, ref unHi, ref unLo);
		_ExpandKey(sbx1, BFC.SBE, ref unHi, ref unLo);
		_ExpandKey(sbx2, BFC.SBE, ref unHi, ref unLo);
		_ExpandKey(sbx3, BFC.SBE, ref unHi, ref unLo);

		return true;
	}

	private void _InitPBX(byte[] key)
	{
		uint unBuild = 0;
		int nKeyPos = 0;
		int nKeyEnd = key.Length;
		for (int i = 0; i < BFC.PBE; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				unBuild = (unBuild << 8) | key[nKeyPos];

				if (++nKeyPos == nKeyEnd)
				{
					nKeyPos = 0;
				}
			}
			pbx[i] ^= unBuild;
		}
	}

	private void _ExpandKey(uint[] data, int max, ref uint unHi, ref uint unLo)
	{
		uint[] box = data;
		for (int i = 0; i < max;)
		{
			//_Encode(unHi, unLo, ref unHi, ref unLo);
			byte[] block = U2B(unHi, unLo);
			Encipher(block, block, BFC.BLOCK_SIZE);
			B2U(block, ref unHi, ref unLo);
			
			box[i++] = unHi;
			box[i++] = unLo;
		}
	}

	private void _Init()
	{
		Array.Copy(BFC.PBI, 0, pbx,  0, BFC.PBI.Length);
		Array.Copy(BFC.SB0, 0, sbx0, 0, BFC.SB0.Length);
		Array.Copy(BFC.SB1, 0, sbx1, 0, BFC.SB1.Length);
		Array.Copy(BFC.SB2, 0, sbx2, 0, BFC.SB2.Length);
		Array.Copy(BFC.SB3, 0, sbx3, 0, BFC.SB3.Length);
	}

	#endregion init

	#region encrypt

	private byte[] U2B(uint hi, uint lo)
	{
		byte[] block = blx;

		block[0] = (byte)(hi >> 24);
		block[1] = (byte)(hi >> 16);
		block[2] = (byte)(hi >>  8);
		block[3] = (byte) hi;
		block[4] = (byte)(lo >> 24);
		block[5] = (byte)(lo >> 16);
		block[6] = (byte)(lo >>  8);
		block[7] = (byte) lo;
	
		return block;
	}

	private void B2U(byte[] b, ref uint hi, ref uint lo)
	{
		hi = (((uint)b[0]) << 24) |
			(((uint)b[1]) << 16) |
			(((uint)b[2]) <<  8) |
			b[3];

		lo = (((uint)b[4]) << 24) |
			(((uint)b[5]) << 16) |
			(((uint)b[6]) <<  8) |
			b[7];
	}
/*
	private void _Encode(
		uint hi,
		uint lo,
		ref uint outHi,
		ref uint outLo)
	{
		byte[] block = U2B(hi, lo);
		Encipher(block, block, BFC.BLOCK_SIZE);
		B2U(block, ref outHi, ref outLo);
	}
	*/
/*
	private void _Decode(
		uint hi,
		uint lo,
		ref uint outHi,
		ref uint outLo)
	{
		byte[] block = U2B(hi, lo);
		Decipher(block, block, BFC.BLOCK_SIZE);
		B2U(block, ref outHi, ref outLo);
	}
	*/

	private int Encipher(byte[] inBuf, byte[] outBuf, int cnt)
	{
		int nEnd;
		uint hi, lo;
		int inStart = 0;
		int outStart = 0;

		cnt &= ~(BFC.BLOCK_SIZE - 1);
		nEnd = inStart + cnt;

		uint[] sbox1 = sbx0;
		uint[] sbox2 = sbx1;
		uint[] sbox3 = sbx2;
		uint[] sbox4 = sbx3;

		uint[] pbox = pbx;

		uint pbox00 = pbox[ 0];
		uint pbox01 = pbox[ 1];
		uint pbox02 = pbox[ 2];
		uint pbox03 = pbox[ 3];
		uint pbox04 = pbox[ 4];
		uint pbox05 = pbox[ 5];
		uint pbox06 = pbox[ 6];
		uint pbox07 = pbox[ 7];
		uint pbox08 = pbox[ 8];
		uint pbox09 = pbox[ 9];
		uint pbox10 = pbox[10];
		uint pbox11 = pbox[11];
		uint pbox12 = pbox[12];
		uint pbox13 = pbox[13];
		uint pbox14 = pbox[14];
		uint pbox15 = pbox[15];
		uint pbox16 = pbox[16];
		uint pbox17 = pbox[17];



		while (inStart < nEnd)
		{
			hi = (((uint)inBuf[inStart    ]) << 24) |
				(((uint)inBuf[inStart + 1]) << 16) |
				(((uint)inBuf[inStart + 2]) <<  8) |
				inBuf[inStart + 3];

			lo = (((uint)inBuf[inStart + 4]) << 24) |
				(((uint)inBuf[inStart + 5]) << 16) |
				(((uint)inBuf[inStart + 6]) <<  8) |
				inBuf[inStart + 7];
			inStart += 8;

			hi ^= pbox00;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox01;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox02;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox03;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox04;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox05;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox06;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox07;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox08;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox09;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox10;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox11;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox12;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox13;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox14;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox15;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox16;

			lo ^= pbox17;

			/*
			outBuf[outStart    ] = (byte)(lo >> 24);
			outBuf[outStart + 1] = (byte)(lo >> 16);
			outBuf[outStart + 2] = (byte)(lo >>  8);
			outBuf[outStart + 3] = (byte) lo;

			outBuf[outStart + 4] = (byte)(hi >> 24);
			outBuf[outStart + 5] = (byte)(hi >> 16);
			outBuf[outStart + 6] = (byte)(hi >>  8);
			outBuf[outStart + 7] = (byte) hi;
			*/
			U2B2(outBuf, outStart, lo, hi);
			outStart += 8;
		}

		return cnt;
	}

	private int Decipher(byte[] inBuf, byte[] outBuf, int cnt)
	{
		int nEnd;
		uint hi, lo;
		int inStart = 0;
		int outStart = 0;

		cnt &= ~(BFC.BLOCK_SIZE - 1);
		nEnd = inStart + cnt;

		uint[] sbox1 = sbx0;
		uint[] sbox2 = sbx1;
		uint[] sbox3 = sbx2;
		uint[] sbox4 = sbx3;

		uint[] pbox = pbx;

		uint pbox00 = pbox[ 0];
		uint pbox01 = pbox[ 1];
		uint pbox02 = pbox[ 2];
		uint pbox03 = pbox[ 3];
		uint pbox04 = pbox[ 4];
		uint pbox05 = pbox[ 5];
		uint pbox06 = pbox[ 6];
		uint pbox07 = pbox[ 7];
		uint pbox08 = pbox[ 8];
		uint pbox09 = pbox[ 9];
		uint pbox10 = pbox[10];
		uint pbox11 = pbox[11];
		uint pbox12 = pbox[12];
		uint pbox13 = pbox[13];
		uint pbox14 = pbox[14];
		uint pbox15 = pbox[15];
		uint pbox16 = pbox[16];
		uint pbox17 = pbox[17];



		while (inStart < nEnd)
		{
			hi = (((uint)inBuf[inStart    ]) << 24) |
				(((uint)inBuf[inStart + 1]) << 16) |
				(((uint)inBuf[inStart + 2]) <<  8) |
				inBuf[inStart + 3];

			lo = (((uint)inBuf[inStart + 4]) << 24) |
				(((uint)inBuf[inStart + 5]) << 16) |
				(((uint)inBuf[inStart + 6]) <<  8) |
				inBuf[inStart + 7];
			inStart += 8;

			hi ^= pbox17;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox16;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox15;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox14;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox13;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox12;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox11;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox10;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox09;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox08;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox07;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox06;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox05;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox04;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox03;
			lo ^= (((sbox1[(int)(hi >> 24)] + sbox2[(int)((hi >> 16) & 0x0ff)]) ^ sbox3[(int)((hi >> 8) & 0x0ff)]) + sbox4[(int)(hi & 0x0ff)]) ^ pbox02;
			hi ^= (((sbox1[(int)(lo >> 24)] + sbox2[(int)((lo >> 16) & 0x0ff)]) ^ sbox3[(int)((lo >> 8) & 0x0ff)]) + sbox4[(int)(lo & 0x0ff)]) ^ pbox01;

			lo ^= pbox00;
/*
			outBuf[outStart    ] = (byte)(lo >> 24);
			outBuf[outStart + 1] = (byte)(lo >> 16);
			outBuf[outStart + 2] = (byte)(lo >>  8);
			outBuf[outStart + 3] = (byte) lo;

			outBuf[outStart + 4] = (byte)(hi >> 24);
			outBuf[outStart + 5] = (byte)(hi >> 16);
			outBuf[outStart + 6] = (byte)(hi >>  8);
			outBuf[outStart + 7] = (byte) hi;
*/
			U2B2(outBuf, outStart, lo, hi);
			outStart += 8;
		}

		return cnt;
	}

	private static void U2B2(byte[] b, int start, uint lo, uint hi)
	{
		b[start] = (byte)(lo >> 24);
		b[start + 1] = (byte)(lo >> 16);
		b[start + 2] = (byte)(lo >>  8);
		b[start + 3] = (byte) lo;

		b[start + 4] = (byte)(hi >> 24);
		b[start + 5] = (byte)(hi >> 16);
		b[start + 6] = (byte)(hi >>  8);
		b[start + 7] = (byte) hi;	
	}

	#endregion encrypt

	private bool IsValid()
	{
		int i, j;
		for (i = 0; i < BFC.SBE - 1; i++)
		{
			j = i + 1;
			while (j < BFC.SBE)
			{
				if ((sbx0[i] == sbx0[j]) |
					(sbx1[i] == sbx1[j]) |
					(sbx2[i] == sbx2[j]) |
					(sbx3[i] == sbx3[j])) break;
				else j++;
			}
			if (j < BFC.SBE)
			{
				return false;
			}
		}
		return true;
	}

}//EOC

}