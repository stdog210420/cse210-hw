using System;
using System.Text.RegularExpressions;
using System.Linq;
class Reference
{
    private string _book { get; }
    private int _chapter { get;}
    private int _verseStart { get;}
    private int _verseEnd { get;}
    public  Reference(string Book, int Chapter, int VerseStart, int VerseEnd)
    {
        // Parse the reference value and initialize _book, _chapter, _verseStart, and _verseEnd
        // Example: "Proverbs 3:5-6"

        _book = Book;
        _chapter = Chapter;
        _verseStart = VerseStart;
        _verseEnd = VerseEnd;
    }
    public override string ToString()
    {
        if (_verseStart == _verseEnd)
        {
            return  $"{_book} {_chapter}:{_verseStart}";
        }
        else
        {
            return  $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    } 
}