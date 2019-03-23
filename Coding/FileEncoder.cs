using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using huffman_encoder.TextCrawling;

namespace huffman_encoder.Encoding
{
    internal static class FileEncoder
    {
        public static void EncodeFile(string fileName, Alphabet alphabet, string outputFile)
        {
            var alphabetFilename = outputFile + ".alphabet";
            var text = File.ReadAllText(fileName);
            text = cleanText(text, alphabet);
            
            foreach (var character in text)
            {
                text = text.Replace(character.ToString(), alphabet.GetCodeFor(character));
            }
            
            WriteOutputFile(text, outputFile);
            WriteAlphabetFile(alphabetFilename, alphabet);
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

        private static void WriteOutputFile(string text, string outputFile)
        {
            File.WriteAllText(outputFile, text);
        }
        
        private static void WriteAlphabetFile(string alphabetFilename, Alphabet alphabet)
        {
            foreach (var pair in alphabet.toDict())
            {
                using (var file = new StreamWriter(alphabetFilename, true))
                {
                    file.WriteLine($"{pair.Key}:{pair.Value}");
                }
            }
        }
    }
}