using System;
using System.Text.RegularExpressions;
using System.Linq;

class Reference
{
    public  String ReferenceDisplay(string _book, int _chapter, int _verseStart, int _verseEnd)
    {
        // Parse the reference value and initialize _book, _chapter, _verseStart, and _verseEnd
        // Example: "Proverbs 3:5-6"
        // _book = "Proverbs";
        // _chapter = 3;
        // _verseStart = 5;
        // _verseEnd = 6;
        return  $"{_book } {_chapter}:{_verseStart}-{_verseEnd}";
    
    }

}