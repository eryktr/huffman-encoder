using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace huffman_encoder.TextCrawling
{
    internal class FrequencyMap
    {
        private IList<Tuple<char, int>> _frequencies;

        private void ReorderFrequencies()
        {
            _frequencies = _frequencies.OrderBy(elem => elem.Item2).ToList();
        }
        
        public FrequencyMap(IDictionary<char, int> frequencies)
        {
            _frequencies = new List<Tuple<char, int>>();
            foreach (var (key, value) in frequencies)
            {
                _frequencies.Add(new Tuple<char, int>(key, value));
            }
            ReorderFrequencies();
        }

        public int GetFrequency(char character)
        {
            foreach (var pair in _frequencies)
            {
                if (pair.Item1 == character)
                {
                    return pair.Item2;
                }
            }
            throw new ArgumentException("Character is not in the map!");
        }

        public Tuple<char, int> Pop()
        {
            return _frequencies.First();
        }

        public void Push(Tuple<char, int> pair)
        {
            _frequencies.Add(pair);
            ReorderFrequencies();
        }
        
        public IList<Tuple<char, int>> ToList()
        {
            return _frequencies;
        }
    }
}