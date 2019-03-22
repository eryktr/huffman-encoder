using System;
using System.Collections.Generic;

namespace huffman_encoder.TextCrawling
{
    class FrequencyMap
    {
        private readonly Dictionary<char, int> _frequencies;

        public FrequencyMap(Dictionary<char, int> frequencies)
        {
            _frequencies = frequencies;
        }

        public int GetFrequency(char character)
        {
            if (!_frequencies.ContainsKey(character))
            {
                throw new ArgumentException($"{character} is not in the map!");
            }

            return _frequencies[character];
        }
        
        
    }
}