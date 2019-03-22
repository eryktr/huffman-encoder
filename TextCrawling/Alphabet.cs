using System;
using System.Collections.Generic;

namespace huffman_encoder.TextCrawling
{
    class Alphabet
    {
        private readonly Dictionary<char, string> _alphabet;

        public Alphabet(Dictionary<char, string> alphabet)
        {
            _alphabet = alphabet;
        }

        public string GetCodeFor(char letter)
        {
            if (!_alphabet.ContainsKey(letter))
            {
                throw new ArgumentException($"{letter} is not in the alphabet");
            }

            return _alphabet[letter];
        }
    }
}