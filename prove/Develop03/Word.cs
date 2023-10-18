using System;
using System.Text.RegularExpressions;
using System.Linq;

class Word
{
    private string _word;
    public bool _hidden;

    public Word(string Text)
    {
        _word = Text;
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
            //If _hidden is true, it returns a string of underscores ('_') of the same length as Text. 
            return new string ('_', _word.Length);
        }
        //If _hidden is false, it returns the original Text.
        return _word;
    }
}