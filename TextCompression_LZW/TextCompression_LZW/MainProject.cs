using System;
using System.Text;
using System.Collections.Generic;

namespace CompressionLZW
{
	public class MainProject
	{
		public static void Main (string[] args)
		{
			Compression compression = new Compression (new StringBuilder ("A_ASA_DA_CASA"));
			compression.startCompression ();
			compression.printDictionary ();

			Decompression decompression = new Decompression (compression.getDictionary(), compression.getTextCompressed());
			decompression.startDecompression ();
			decompression.printTextDecompressed();
		}
	}
}