using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace huffman_encoder.TextCrawling
{
    internal class PriorityQueue<T>: IEnumerable<T> where T: IComparable<T>
    {
        private readonly List<T> _elements;
        private readonly Comparison<T> _comparison;

        private void ReorderFrequencies()
        {
            _elements.Sort((e1, e2) => _comparison(e1, e2));
        }
        
        public PriorityQueue(List<T> elements, Comparison<T> comparison = null) 
        {
            _elements = elements;
            _comparison = comparison ?? ((x, y) => x.CompareTo(y));
            ReorderFrequencies();
        }

        public T Pop()
        {
            return _elements.First();
        }

        public void Push(T elem)
        {
            _elements.Add(elem);
            ReorderFrequencies();
        }

        public bool NotEmpty()
        {
            return _elements.Any();
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
}