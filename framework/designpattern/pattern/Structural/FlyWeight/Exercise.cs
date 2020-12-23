using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Structural.FlyWeight
{
    public class Exercise : IDesignPatternDemo
    {
        public string Title => "11.3";

        public string Description => "FlyWeight - Exercise";

        public void Run()
        {
            var s = new Sentence("alpha beta gamma");
            s[1].Capitalize = true;
            s[2].Capitalize = true;
            WriteLine(s);
        }
    }

    public class Sentence
    {
        private string[] _words;
        private Dictionary<int, WordToken> _tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            _words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                var wt = new WordToken();
                _tokens.Add(index, wt);
                return wt;
            }
        }

        public override string ToString()
        {
            var ws = new List<string>();
            for (var i = 0; i < _words.Length; i++)
            {
                var w = _words[i];
                if (_tokens.ContainsKey(i) && _tokens[i].Capitalize)
                    w = w.ToUpperInvariant();
                ws.Add(w);
            }
            return string.Join(" ", ws);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
