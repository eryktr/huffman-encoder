using System;
using System.Reflection.PortableExecutable;
using huffman_encoder.TextCrawling;

namespace huffman_encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            TextCrawler cr = TextCrawler.Instance;
            var fr = cr.CrawlFile("LICENSE");
        }
    }
}