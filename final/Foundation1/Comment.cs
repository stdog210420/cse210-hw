
using System;
using System.Diagnostics.Contracts;
class Comment
{
    private string _name;
    private string _text;

    public string GetName()
    {   
        return _name;
    }

    public string GetText()
    {   
        return _text;
    }
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

}