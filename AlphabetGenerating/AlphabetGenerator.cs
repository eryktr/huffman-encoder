using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;

namespace huffman_encoder.TextCrawling
{
    class AlphabetGenerator
    {
        private static AlphabetGenerator _instance;
        private AlphabetGenerator() {}
        public static AlphabetGenerator Instance => _instance ?? (_instance = new AlphabetGenerator());

    }
}