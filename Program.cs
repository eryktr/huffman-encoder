using System;
using System.Collections.Generic;
using huffman_encoder.TextCrawling;

namespace huffman_encoder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cr = TextCrawler.Instance;
            var fr = cr.CrawlFile("LICENSE");
            var a = new AlphabetGenerator().GenerateAlphabet(fr);
            
            
        }
    }
}