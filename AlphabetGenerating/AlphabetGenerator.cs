using System;
using System.Collections.Generic;

namespace huffman_encoder.TextCrawling
{
    class AlphabetGenerator
    {

        private readonly Dictionary<char, string> codesDict = new Dictionary<char, string>();
        public Alphabet GenerateAlphabet(IDictionary<char, int> frequencies)
        {
            var queue = initQueue(frequencies);
            HuffmanTree root = null;
            while (queue.Count > 1)
            {
                var first = queue.Pop();
                var second = queue.Pop();
                var f1 = first.Frequency;
                var f2 = second.Frequency;
                var sum = new HuffmanTree(f1+ f2, '-', first, second);
                queue.Push(sum);
                root = sum;
            }

            collectCodes(root);
            return new Alphabet(codesDict);
        }

        private PriorityQueue<HuffmanTree> initQueue(IDictionary<char, int> frequencies)
        {
            var list = new List<HuffmanTree>();
            foreach (var (key, value) in frequencies)
            {
                var tree = new HuffmanTree(value, key);
                list.Add(tree);
            }
            var queue = new PriorityQueue<HuffmanTree>(list);
            return queue;
        }

        private void collectCodes(HuffmanTree tree,  string code = null)
        {
            if (code == null) code = "";
            if (tree.Left == null && tree.Right == null && tree.Character != '-')
            {
                codesDict.Add(tree.Character, code);
                return;
            }
            collectCodes(tree.Left, code+"0" );
            collectCodes(tree.Right,code+"1");
        }
    }
}