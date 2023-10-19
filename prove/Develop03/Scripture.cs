using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Formats.Asn1;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

class Scripture
{
    private Reference _reference { get;}
    private List<Word> _words{ get; }

    public Scripture(string text)
    {   
        // Example: "Proverbs 3:5-6"
        _reference = new Reference("Proverbs", 3, 5 ,6);
        _words = text.Split(" ").Select(text => new Word(text)).ToList();
    }
    //This code will return true if it finds any hidden word and false if none of the words are hidden.
    public bool HasHiddenWords()
    {
        return _words.Any(word => word._hidden);
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        List<Word> hiddenWords;
        int index;
        do
        {
            index = random.Next(_words.Count);
            Console.WriteLine(index);
        }
        while (_words[index]._hidden);
        {
            _words[index].Hide();
            hiddenWords = _words[index].Hide();
        }
        if (hiddenWords.Count == _words.Count)
        {
            // if all words are hidden, than stop.
            Console.WriteLine("All words are hidden.");
            return;
        }  

        
    }
        public string Render()
    {   
        return $"{_reference}: {string.Join(" ", hiddenWords.Select(word => word.Render()))}";
    }

}