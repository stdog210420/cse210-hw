using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Formats.Asn1;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

class Scripture
{
    public Reference _reference{ get; set; }
    public List<Word> _words{ get; set; }
    public int _wordsToHide;

    public Scripture(Reference _reference, string text)
    {   
        // initialized _reference
        _words = text.Split(" ").Select(wordtext => new Word(wordtext)).ToList();

    }
    //This code will return true if it finds any hidden word and false if none of the words are hidden.

    public bool HasHiddenWords()
    {
        return _words.Any(word => word._hidden);
    }

    public int HideRandomWord()
    {
        Random random = new Random();
        List<Word> hiddenWords = _words.Where(word => word._hidden).ToList();

        if (hiddenWords.Count == _words.Count)
        {
            Console.WriteLine("All words are hiddden.");
            return _wordsToHide;
        }
        for (int i = 0; i< _wordsToHide ; i++)
        {
            int index;         
            do{
                index = random.Next(_words.Count);
            }
            while (_words[index]._hidden);
            _words[index].Hide(); 
        }
        return _wordsToHide + 1; 
    }
    public string Render()
    {
        return $"{_reference}: {string.Join(" ", _words.Select(word => word.Render()))}";
    }

}