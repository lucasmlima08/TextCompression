using System;
using System.Text;
using System.Collections.Generic;

namespace CompressionLZW
{
	public class Decompression
	{
		private List<String> dictionary;
		private StringBuilder textCompressed;

		private StringBuilder textOriginal;

		public Decompression (List<String> dictionary, StringBuilder textCompressed)
		{
			this.dictionary = dictionary;
			this.textCompressed = textCompressed;

			textOriginal = new StringBuilder();
		}

		public void startDecompression()
		{
			string stringCompressed = textCompressed.ToString ();

			string[] arrayTextCompressed = stringCompressed.Split (' ');

			for (int i = 0; i < arrayTextCompressed.Length-1; i++) {

				int index = Convert.ToInt32(arrayTextCompressed[i]+"");

				textOriginal.Append (dictionary[index]);
			}
		}

		public void printTextDecompressed()
		{
			Console.WriteLine ("Apresentando a Descompressão:");

			Console.WriteLine ();

			Console.WriteLine ("Texto Comprimido: " + textCompressed.ToString());

			Console.WriteLine ("Texto Original: " + textOriginal.ToString());

			Console.WriteLine ();
		}
	}
}

