    //get the journal entry
    public class Entry
    {
        public DateTime _Date;
        public string _Prompt;
        public string _Response;
        public string  formattedEntry()
        {
            string _formattedEntry= $"{_Date.ToShortDateString()} - Prompt: {_Prompt} {_Response}\n";
            return _formattedEntry;
        } 
    }