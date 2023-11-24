using System;
class Video
{
    private string _title;
    private string _author;
    private float _length;
    private List<Comment> _commentList;
    public string GetTitle()
    {   
        return _title;
    }
    public string GetAuthor()
    {   
        return _author;
    }
    public float GetLength()
    {   
        return _length;
    }
    public List<Comment> GetComments()
    {
        return _commentList;
    }

    public Video(string title, string author, float length)
    {
        _title = title;
        _author = author;
        _length = length;
        _commentList = new List<Comment>();
    }
    public void AddComment(string author, string text)
    {
        Comment comment = new Comment(author, text);
        _commentList.Add(comment);

    }
    public int NumberComment()
    {
        return _commentList.Count;
    }


}