using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Formats.Asn1;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture()
    {   
        // Example: "Proverbs 3:5-6"
        Reference _reference = new Reference("Proverbs", 3, 5 ,6);
        string text = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."; 
        _words = text.Split(" ").Select(text => new Word(text)).ToList();
    }
    //This code will return true if it finds any hidden word and false if none of the words are hidden.
    public bool HasHiddenWords()
    {

        foreach (Word word in _words)
        {
            if (word._hidden) // modify the Hide method to return a bool
            {
                return true; // If any word is hidden, return true.
            }         
        }
        //return false; statement should be outside the loop, so it only returns false if none of the words are hidden. 
        return false; //If no word is hidden, return false. 
        
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index;
        do
        {
            index = random.Next(_words.Count);
        }
        while (_words[index]._hidden);
        _words[index].Hide();
        Console.WriteLine($"{_words[index].Render()}");
    }    

}