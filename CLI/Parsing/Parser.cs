using System;
using System.Collections.Generic;
using System.Linq;

namespace huffman_encoder.CLI.Parsing
{
    internal static class Parser
    {
        private const string ENCODE_ARG = "encode";
        private const string DECODE_ARG = "decode";

        private const string USAGE_MSG = "Usage: encode <file_to_encode> <output_file> OR" +
                                         "decode <file_to_decode> <alphabet_fie> <output_file>";
        
        public static Settings ParseArguments(string[] args)
        {
            try
            {
                if (AreValid(args))
                {
                    
                    var mode = GetRunMode(args);
                    var settings = new Settings(mode);
                    switch (mode)
                    {
                        case RunMode.ENCODE:
                            settings.FileToEncode = args[2];
                            settings.OutputFile = args[3];
                            break;
                        case RunMode.DECODE:
                            settings.FileToDecode = args[2];
                            settings.AlphabetFile = args[3];
                            settings.OutputFile = args[4];
                            break;
                        default:
                            throw new ArgumentException(USAGE_MSG);
                    }
                    return settings;
                }
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private static bool CorrectArgNumber(string[] args)
        {
            var expectedLength = args[1] == ENCODE_ARG ? 4 : 5;
            var length = args.Length;
            if (expectedLength != length)
            {
                throw new ArgumentException($"Incorrect number or arguments! {length} given," +
                                            $" {expectedLength} expected ");
            }

            return true;
        }

        private static bool ContainsBoth(string[] args)
        {
            return args.Contains(ENCODE_ARG) && args.Contains(DECODE_ARG);
        }

        private static bool ContainsNone(string[] args)
        {
            return !(args.Contains(ENCODE_ARG) || args.Contains(DECODE_ARG));
        }

        private static bool AreValid(string[] args)
        {
            if (ContainsBoth(args))
            {
                throw new ArgumentException(USAGE_MSG);
            }
            
            if (ContainsNone(args))
            {
                throw new ArgumentException(USAGE_MSG);
            }

            return CorrectArgNumber(args);
        }

        private static RunMode GetRunMode(string[] args)
        {
            return args[1] == DECODE_ARG ? RunMode.DECODE : RunMode.ENCODE;
        }
    }
}