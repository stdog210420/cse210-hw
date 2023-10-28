using System;
using System.Text.RegularExpressions;
using System.Linq;

class Word
{
    public string _word{ get; set; }
    public bool _hidden{get; set;}

    public Word(string Text)
    {
        _word = Text;
        _hidden = false;
    }
    // modify the Hide method to return a bool
    public bool Hide()
    {
        //checks if the _hidden property of the Word object is currently false, which means the word is not hidden.
        if (!_hidden)
        {   //If the word is not hidden, this line sets the _hidden property to true, indicating that the word is now hidden.
            _hidden = true;
            //After successfully hiding the word, this line returns true to indicate that the hiding operation was successful.
            return true;
        }
        return false;
    }
    public string Render()
    { 
    //This condition checks two things: 1.whether the _hidden property of the word is set to true
    //2. If there are remaining words to hide (i.e., wordsToHide is greater than 0), the code proceeds to hide this word.
        if (_hidden)
        {
            // Console.WriteLine(_word.Length);
            //If _hidden is true, it returns a string of underscores ('_') of the same length as Text. 
            return new string ('_', _word.Length);
        }
        //If _hidden is false, it returns the original Text.
        return _word;
    }
}