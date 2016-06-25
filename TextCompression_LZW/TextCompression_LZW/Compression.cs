using System;
using System.Text;
using System.Collections.Generic;

namespace CompressionLZW
{
	public class Compression
	{
		private StringBuilder textOriginal;
		private StringBuilder textCompressed;
		private List<String> dictionary;

		public Compression (StringBuilder textOriginal)
		{
			this.textOriginal = textOriginal;

			textCompressed = new StringBuilder();
			dictionary = new List<String> ();
		}

		private void startDictionary()
		{
			for (int i = 0; i < textOriginal.Length; i++) {

				Boolean exist = hasElementDictionary(textOriginal [i] + "");

				if (!exist) {
					dictionary.Add (textOriginal[i]+"");
				}
			}
		}

		private Boolean hasElementDictionary(String stringIndex)
		{
			for (int i = 0; i < dictionary.Count; i++) {

				if (dictionary [i].Equals(stringIndex)) {
					return true;
				}
			}
			return false;
		}

		private int indexElementDictionary(String stringIndex)
		{
			for (int i = 0; i < dictionary.Count; i++) {

				if (dictionary [i].Equals(stringIndex)) {
					return i;
				}
			}
			return -1;
		}

		public void startCompression()
		{
			// Inicia o dicionário.
			if (textOriginal.Equals("")) {
				return;
			} else {
				startDictionary ();
			}

			// Inicia a compressão.
			StringBuilder textAux = new StringBuilder ();

			int index = dictionary.Count;
			for (int i = 0; i < textOriginal.Length; i++) {

				textAux.Append (textOriginal [i]);

				int indexAux = indexElementDictionary(textAux.ToString());

				if (indexAux == -1) {
					dictionary.Add (textAux.ToString());
					textAux = new StringBuilder();
					textCompressed.Append (index + " ");
					i--;

				} else {
					index = indexAux;

					// Verifica se é o final (última condição).
					if (i+1 >= textOriginal.Length) {
						textCompressed.Append (index + " ");
					}
				}
			}
		}

		public void printDictionary()
		{
			Console.WriteLine ("Apresentando a Compressão:");

			Console.WriteLine ();

			Console.WriteLine ("Texto Original: " + textOriginal.ToString());

			String stringAux = "";

			for (int i = 0; i < dictionary.Count; i++) {
				stringAux += dictionary [i] + " ";
			}

			Console.WriteLine ("Dicionário: " + stringAux);

			Console.WriteLine ("Texto Comprimido: " + textCompressed.ToString());

			Console.WriteLine ();
		}

		public List<String> getDictionary()
		{
			return dictionary;
		}

		public StringBuilder getTextCompressed()
		{
			return textCompressed;
		}
	}
}

