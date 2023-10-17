using System;
using System.Text.RegularExpressions;
using System.Linq;

class Word
{
    public string _word;
    public bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }
    // modify the Hide method to return a bool
    public void Hide()
    {
        _hidden = true;
    }
    public string Render()
    {   //checks if _hidden is true
        if (_hidden)
        {
            //If _hidden is true, it returns a string of underscores ('_') of the same length as _word. 
            return new string ('_', _word.Length);
        }
        //If _hidden is false, it returns the original _word.
        return _word;
    }
}