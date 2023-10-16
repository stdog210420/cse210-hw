using System;
using System.Text.RegularExpressions;
using System.Linq;

class Scripture
{
    private Reference _reference;
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
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
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