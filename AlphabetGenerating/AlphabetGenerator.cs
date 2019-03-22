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

        public Alphabet GenerateAlphabet(Dictionary<char, int> frequencies)
        {
            var queue = new PriorityQueue<HuffmanTree>();
            return null;
        }

        private PriorityQueue<HuffmanTree> initQueue(Dictionary<char, int> frequencies)
        {
            var list = new List<HuffmanTree>();
            foreach (var (key, value) in frequencies)
            {
                var tree = new HuffmanTree();
            }
        }
    }
}