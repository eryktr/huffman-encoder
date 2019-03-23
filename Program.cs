using huffman_encoder.CLI;
using huffman_encoder.CLI.Parsing;
using huffman_encoder.Encoding;

namespace huffman_encoder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var settings = Parser.ParseArguments(args);
            if (settings.Mode == RunMode.ENCODE)
            {
                RunEncode(settings);
            }
            else
            {
                RunDecode(settings);
            }

        }

        private static void RunEncode(Settings settings)
        {
            var input = settings.FileToEncode;
            var output = settings.OutputFile;
            FileEncoder.EncodeFile(input, output);
        }

        private static void RunDecode(Settings settings)
        {
            var input = settings.FileToDecode;
            var alphabet = settings.AlphabetFile;
            var output = settings.OutputFile;
            FileDecoder.DecodeFile(input, alphabet, output);
        }
    }
}