using System;
using System.Text.RegularExpressions;
using System.Linq;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference (string value)
    {
        // Parse the reference value and initialize _book, _chapter, _verseStart, and _verseEnd
        // Example: "Proverbs 3:5-6"
        _book = "Proverbs";
        _chapter = 3;
        _verseStart = 5;
        _verseEnd = 6;
    }
    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}