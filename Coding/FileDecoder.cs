using System.IO;
using System.Linq;
using System.Text;
using huffman_encoder.TextCrawling;

namespace huffman_encoder.Encoding
{
    internal static class FileDecoder
    {
        public static void DecodeFile(string inputFile, string alphabetFile, string outputFile)
        {
            var alphabet = new Alphabet(alphabetFile);
            DecodeFile(inputFile, alphabet, outputFile);
        }
        private static void DecodeFile(string inputFile,  Alphabet alphabet, string outputFile)
        {
            var codedText = File.ReadAllText(inputFile);
            var decodedText = new StringBuilder("");

            for (int i = 0; i < codedText.Length; i++)
            {
                var codedSymbol = codedText[i].ToString();

                while (!alphabet.toDict().ContainsValue(codedSymbol))
                {
                    codedSymbol += codedText[++i];
                }

                var character = alphabet.toDict().First(c => alphabet.GetCodeFor(c.Key) == codedSymbol).Key;

                decodedText.Append(character);
                File.WriteAllText(outputFile, decodedText.ToString());
            }
        }
    }
}