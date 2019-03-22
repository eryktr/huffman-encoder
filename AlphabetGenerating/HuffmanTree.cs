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
   
        public int CompareTo(HuffmanTree other) => Frequency.CompareTo(other.Frequency);
        
        public HuffmanTree(int frequency, char character, HuffmanTree left = null, HuffmanTree right = null)
        {
            Frequency = frequency;
            Character = character;
            Left = left;
            Right = right;
        }
    }
}