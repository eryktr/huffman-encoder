using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace huffman_encoder.TextCrawling
{
    internal class FrequencyPriorityQueue : IEnumerable<Tuple<char, int>>
    {
        private IList<Tuple<char, int>> _frequencies;

        private void ReorderFrequencies()
        {
            _frequencies = _frequencies.OrderBy(elem => elem.Item2).ToList();
        }
        
        public FrequencyPriorityQueue(IDictionary<char, int> frequencies)
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
            foreach (var (item1, item2) in _frequencies)
            {
                if (item1 == character)
                {
                    return item2;
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

        public IEnumerator<Tuple<char, int>> GetEnumerator()
        {
            return _frequencies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _frequencies.GetEnumerator();
        }
    }
}