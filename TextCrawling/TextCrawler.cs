using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace huffman_encoder.TextCrawling
{
    internal class TextCrawler
    {
        private static TextCrawler _instance;

        private TextCrawler()
        {
        }

        public static TextCrawler Instance => _instance ?? (_instance = new TextCrawler());

        public FrequencyMap CrawlFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileLoadException("File does not exist!");

            var text = File.ReadAllText(filePath);
            var freqMap = ComputeFrequencyMap(text);

            return freqMap;
        }

        private FrequencyMap ComputeFrequencyMap(string text)
        {
            var letters = Enumerable.Range(97, 26).Select(code => (char) code);

            var dic = new Dictionary<char, int>();
            foreach (var character in text.ToLower())
            {
                if (!dic.ContainsKey(character)) dic[character] = 0;

                dic[character]++;
            }

            var map = new FrequencyMap(dic);
            return map;
        }
    }
}