using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace huffman_encoder.TextCrawling
{
    class TextCrawler
    {
        private TextCrawler _instance;
        public TextCrawler Instance => _instance ?? (_instance = new TextCrawler());

        public FrequencyMap CrawlFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileLoadException("File does not exist!");
            }

            var text = File.ReadAllText(filePath);
            var freqMap = ComputeFrequencyMap(text);
            
            return freqMap;
        }

        private FrequencyMap ComputeFrequencyMap(string text)
        {
            var dic = new Dictionary<char, int>();
            foreach (var character in text)
            {
                if (!dic.ContainsKey(character))
                {
                    dic[character] = 0;
                }

                dic[character]++;
            }

            var map = new FrequencyMap(dic);
            return map;
        }
        
    }
}