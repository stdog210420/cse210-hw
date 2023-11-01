using System;
using System.Text.RegularExpressions;
using System.Linq;

class Word
{
    public string _word;
    public bool _hidden;

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

    public bool Reveal()
    {
        //checks if the _hidden property of the Word object is currently true, which means the word is hidden.
        if (_hidden)
        {   //If the word is hidden, this line sets the _hidden property to false, indicating that the word is now unhidden.
            _hidden = false;
            //After successfully revealing the word, this line returns true to indicate that the revealing operation was successful.
            return false;
        }
        return false;
    }
    public string revealRender()
    { 
    //This condition checks two things: 1.whether the _hidden property of the word is set to true
    //2. If there are remaining words to hide (i.e., wordsToHide is greater than 0), the code proceeds to hide this word.
        if (_hidden == false)
        {
            //If _hidden is false, it returns the original Text.
            return _word;
        }
        return new string ('_', _word.Length);
        
    }

}