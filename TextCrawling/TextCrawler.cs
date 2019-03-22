using System.IO;

namespace huffman_encoder.TextCrawling
{
    class TextCrawler
    {
        private TextCrawler _instance;
        public TextCrawler Instance => _instance ?? (_instance = new TextCrawler());

        public Alphabet CrawlFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileLoadException("File does not exist!");
            }

            var text = File.ReadAllText(filePath);
            
            
            return null;
        }
    }
}