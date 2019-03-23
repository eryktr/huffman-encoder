using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using huffman_encoder.TextCrawling;

namespace huffman_encoder.Encoding
{
    internal static class FileEncoder
    {
        public static void EncodeFile(string fileName, Alphabet alphabet, string outputFile)
        {
            var text = File.ReadAllText(fileName);
            text = cleanText(text, alphabet);
            
            foreach (var character in text)
            {
                text = text.Replace(character.ToString(), alphabet.GetCodeFor(character));
            }
            
            File.WriteAllText(outputFile, text);
        }

        private static string cleanText(string text, Alphabet alphabet)
        {
            var list = text.ToLower().Where(alphabet.Contains);
            var sb = new StringBuilder("");
            foreach (var c in list)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}