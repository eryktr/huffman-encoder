using System;
using System.Collections.Generic;
using System.IO;

namespace huffman_encoder.TextCrawling
{
    internal class Alphabet
    {
        private readonly Dictionary<char, string> _alphabet;

        public Alphabet(Dictionary<char, string> alphabet)
        {
            _alphabet = alphabet;
        }

        public Alphabet(string fileName)
        {
            var dict = new Dictionary<char, string>();
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var pair = line.Split(":");
                var key = pair[0][0];
                var val = pair[1];
                dict.Add(key, val);
            }

            _alphabet = dict;
        }

        public string GetCodeFor(char letter)
        {
            if (!_alphabet.ContainsKey(letter)) throw new ArgumentException($"{letter} is not in the alphabet");

            return _alphabet[letter];
        }

        public bool Contains(char letter)
        {
            return _alphabet.ContainsKey(letter);
        }

        public Dictionary<char, string> toDict()
        {
            return _alphabet;
        }
        
    }
}
