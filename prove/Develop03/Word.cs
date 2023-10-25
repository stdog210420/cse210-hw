using System;
using System.Text.RegularExpressions;
using System.Linq;

class Word
{
    public string _word{get; set;}
    public bool _hidden{get; set;}

    public Word(string Text)
    {
        _word = Text;
        _hidden = false;
    }
    // modify the Hide method to return a bool
    public bool Hide()
    {
        if (!_hidden)
        {
            _hidden = true;
            return true;
        }
        return false;
    }
    public string Render()
    {   //checks if _hidden is true
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