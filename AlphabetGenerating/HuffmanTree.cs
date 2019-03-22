using System;
using System.Dynamic;

namespace huffman_encoder.TextCrawling
{
    public class HuffmanTree : IComparable<HuffmanTree>
    {
        public int Frequency { get; set; }
        public char Character { get; }

        public HuffmanTree Left { get; set; }
        public HuffmanTree Right { get; set; }
   
        public int CompareTo(HuffmanTree other)
        {
            return Frequency.CompareTo(other.Frequency);
        }
    }
}