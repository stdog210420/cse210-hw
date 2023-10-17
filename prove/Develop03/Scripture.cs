using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Formats.Asn1;

class Scripture
{
    public Reference _reference;
    private List<Word> _words;

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
    public Scripture(Reference _reference, List<Word> _words)
    {
        string text ="Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."; 
        _reference.ReferenceDisplay("Proverbs", 3, 5, 6 );  // Example: "Proverbs 3:5-6"
        _words = text.Split("").Select(w => new Word(w)).ToList(); // Store words in a List
        return $"{_reference.ReferenceDisplay} {_words}";
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
    }
    public string Render()
    {
        return $"{_reference}: {string.Join("",_words.Select(word => word.Render()))}";
    }
    

}