using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Design Requirements
        Choice choice = new Choice();
        Journal myJournal = new Journal();
        string _choice = "0";
        string _myFileName;
        string _fileName = ""; 
        string _myEntryToDelete;
        
        while (_choice != "5")
        {
            choice.ShowOptions();
            _choice = Console.ReadLine();

            switch(_choice)
            {
                // choice 1. Write
                case "1":
                {
                    myJournal.WriteNewEntry();
                    Console.WriteLine("Do you want to keep this entry? If yes, plese choose 4 to save.\n");
                    break;
                }
                // choice 2. Display
                case "2":
                {                
                    myJournal.displayEntries();
                    break;
                }
                // choice 3. Load  
                // open the text file and read the all lines
                case "3":
                {
                    Console.WriteLine("What is the filename? ");
                    _myFileName = Console.ReadLine() + ".txt";
                    // myJournal.ExistingEntries.saveToExisting();
                    myJournal.displayExistingEntries(_myFileName);
                    break;
                }
                // choice 4. Save  
                // Save the text in a file
                case "4":
                {
                    myJournal.SaveJournalEntries(_fileName);
                    break;
                }
                // choice 5. Quit 
                case "5":
                {
                    Console.WriteLine("Already Quit!");
                    break;
                }
                // choice 6. delete 
                case "6":
                {
                    Console.WriteLine("What is the filename that you want to modify? ");
                    _myFileName = Console.ReadLine() + ".txt";
                    Console.WriteLine("What is the keyword in the line you want to delete? ");
                    _myEntryToDelete =  Console.ReadLine();
                    myJournal.DeleteEntryFromFile(_myFileName, _myEntryToDelete);
                    break;
                }
        
            }
        
        }

    }
    public class Choice
    {
        public void ShowOptions()
        {
            Console.WriteLine("Please select one of the following choices:");              
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Delete");
            Console.Write("What would you like to do? ");    
        } 
        
    }
    //get the journal entry
    public class Entry
    {
        public DateTime _Date { get; set; }
        public string _Prompt { get; set; }
        public string _Response { get; set; }
        public string  formattedEntry()
        {
            string _formattedEntry= $"{_Date.ToShortDateString()} - Prompt: {_Prompt} {_Response}\n";
            return _formattedEntry;
        } 
    }
    public class ExistingEntry
    {
        public List<string> _existingEntries = new List<string>();
        public string _FileName { get; set; }

        //set an intialized value to Filename
        public ExistingEntry(string _fileName)
        {
            _FileName = _fileName;
        }
    }
    public class Journal
    {
        //creat a list to store all entries
        public List<Entry> _Entries = new List<Entry>();
        public ExistingEntry _ExistingEntries { get; } = new ExistingEntry("your_filename.txt");
        public void WriteNewEntry()
        {
            // randomly choose a prompt
            string[] _prompts = new string[]
            {
                "Who was the most interesting person you interacted with today?",
                "What was the best part of your day?",
                "How did you see the hand of the Lord in your life today?",
                "What was the strongest emotion you felt today?",
                "If you could do one thing over today, what would it be?"
            };

            Random _random = new Random();
            string _randomPrompt = _prompts[_random.Next(_prompts.Length)];

            // show the prompt and let the users type their response
            Console.WriteLine(_randomPrompt);
            string _response = Console.ReadLine();

            // creat a new entry and add them to the journal
            Entry _newEntry = new Entry
            {
                _Date = DateTime.Now,
                _Prompt = _randomPrompt,
                _Response = _response
            };

            _Entries.Add(_newEntry);
            Console.WriteLine("Entry saved successfully.");
        }  
        public void displayEntries()
        {        
            Console.WriteLine("Display all journals：");    
            foreach (Entry entry in _Entries)
            {
                string _formatted = entry.formattedEntry();
                Console.WriteLine($"{_formatted}\n");
            }
        } 
        public void displayExistingEntries(string _FileName)
        {
            
            Console.WriteLine("Display all journals from " + _FileName + "：");  
            string[] _lines = System.IO.File.ReadAllLines(_FileName);
            foreach (string entry in _lines)
            {
                string[] _parts = entry.Split(",");
                foreach (string part in _parts)
                {
                    Console.WriteLine(part);
                }
                // 將舊檔資料新增到 ExistingEntries 中
                _ExistingEntries._existingEntries.Add(entry);
            }
        }
        public void SaveJournalEntries(string _fileName)
        {
            // check if the user type a filename, if not, ask to type one.
            if (string.IsNullOrEmpty(_fileName))
            {
                Console.WriteLine("What is the filename? ");
                _fileName = Console.ReadLine() + ".txt";
            }

            // Open the file in append mode, create it if it doesn't exist.
            using (StreamWriter outputFile = new StreamWriter(_fileName, true)) // 使用 true 參數表示追加模式
            {
                // Write new entries into the file
                foreach (Entry entry in _Entries)
                {
                    string _formatted = entry.formattedEntry();
                    outputFile.WriteLine(_formatted);
                }
            }
            Console.WriteLine("Entries saved successfully in " + _fileName);
        }
        public void DeleteEntryFromFile(string _fileName, string _entryToDelete)
        {
            // read file into memory
            List<string> _fileContents = File.ReadAllLines(_fileName).ToList();

            // seek the data we want to delete is in which line 
            int indexToDelete = -1;
            for (int i = 0; i < _fileContents.Count; i++)
            {
                string line = _fileContents[i];
                if (_fileContents[i].Contains(_entryToDelete))
                {
                    indexToDelete = i;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        // 刪除非空白行的前後空白
                        _fileContents[i] = line.Trim();
                    }
                    break;                                    
                }
            }
            if (indexToDelete != -1)
            {
                // 移除找到的行
                _fileContents.RemoveAt(indexToDelete);
                // update the data and rewrite to the file
                File.WriteAllLines(_fileName, _fileContents);
                Console.WriteLine("Entry deleted successfully.");
            }
            else
            {
                Console.WriteLine("Entry not found in the file.");
            }
        }
    }
}