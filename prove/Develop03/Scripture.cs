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

    public Scripture(Reference reference, string text)
    {   
        // initialized _reference
        _reference = reference;
        _words = text.Split(" ").Select(wordtext => new Word(wordtext)).ToList();
    }
    //This code will return true if it finds any unhidden word and false if the words are hidden.

    public bool HasHiddenWords()
    {
        // Check if there is at least one word in the _words collection (a list of words) for which the _hidden property is true.
        return _words.Any(word => !word._hidden);
    }

    public void HideRandomWord()
    {   
        //creates a Random object for generating random numbers
        Random random = new Random(); 
        //creates a list "unhiddenWords" that contains words from the _words list that havn't been hidden. 
        //It is used to determine if all words are already hidden.
        List<Word> unhiddenWords = _words.Where(word => !word._hidden).ToList();

        //creates a variable index to store the index of the word not hidden.    
        //It randomly selects an index from the _words list until it finds an unhidden word.   
        int index;
        //keep generating a random index until an unhidden word is found. 
        do{   
            index = random.Next(unhiddenWords.Count);
        }
        
        // If an unhidden word is found, the Hide method is called to hide it, 
        // update the _words list of unhiddenWords's properity
        while (unhiddenWords[index]._hidden);
        unhiddenWords[index].Hide();
        
    }
    public string Render()
    {
        //This allows the Scripture object to keep track of how many words should be hidden based on the user's input.
        //string.Join(" ", ...) is used to join the words together into a single string with spaces between them.
        //_words.Select(word => word.Render(wordsToHide)) It allows the Render method in the Word class to decide whether to display the word or hide it based on the value of wordsToHide.
        return $"{_reference}: {string.Join(" ", _words.Select(word => word.Render()))}";
    }
}

