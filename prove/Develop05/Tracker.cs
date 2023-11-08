using System;
using System.IO;
public class Tracker
{
    public void TrackerOptions()
    {   
        Console.ForegroundColor = ConsoleColor.Blue;    
        Console.WriteLine("Menu Options:");              
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Events"); 
        Console.WriteLine("  6. Quit"); 
        Console.Write("Select a choice from the menu: "); 
    }   
    public void CreateGoal()
    {
        Console.ForegroundColor = ConsoleColor.Blue;    
        Console.WriteLine("The types of Goals are:");              
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goals");
        Console.WriteLine("  3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? ");         
    }

    //creat a list to store all entries
    private List<Goal> _Entries = new List<Goal>();
    private string _FileName;

    //set an intialized value to Filename
    private void SetGoal(string _fileName)
    {
        // creat a new entry and add them to the journal
        Goal newGoal = new Goal();

        _Entries.Add(_newEntry);
        Console.WriteLine("Entry saved successfully.");
        _FileName = _fileName;
    }
    public void ListGoal()
    {
        
    }
    public void SaveGoal()
    {

    }
    public void LoadGoal()
    {

    }
    public void RecordEvent()
    {

    }


    
        public void WriteNewEntry()
        {
            string _response = Console.ReadLine();


        }  
        public void display()
        {        
            Console.WriteLine("Display all journals：");    
            foreach (Entry entry in _Entries)
            {
                string _formatted = entry.formattedEntry();
                Console.WriteLine($"{_formatted}\n");
            }
        } 
        public void displayEntries(string _FileName)
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
                // _Entries.Add(_lines);
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

}