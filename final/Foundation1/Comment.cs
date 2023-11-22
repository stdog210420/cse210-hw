
using System;
using System.Diagnostics.Contracts;
class Comment
{
    private string _name;
    private string _text;
    // public void SetName(string name)
    // {
    //     _name = name;
    // }
    public string GetName()
    {   
        return _name;
    }
    // public void SetText(string text)
    // {
    //     _text = text;
    // }

    public string GeText()
    {   
        return _text;
    }
    public Comment(string _Name, string _Text)
    {
        _name = _Name;
        _text = _Text;
    }

}