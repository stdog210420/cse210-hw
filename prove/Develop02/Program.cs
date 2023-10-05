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
        string myFileName;
        string fileName = ""; 
        string myEntryToDelete;
        
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
                    myFileName = Console.ReadLine() + ".txt";
                    // myJournal.ExistingEntries.saveToExisting();
                    myJournal.displayExistingEntries(myFileName);
                    break;
                }
                // choice 4. Save  
                // Save the text in a file
                case "4":
                {
                    myJournal.SaveJournalEntries(fileName);
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
                    myFileName = Console.ReadLine() + ".txt";
                    Console.WriteLine("What is the keyword in the line you want to delete? ");
                    myEntryToDelete =  Console.ReadLine();
                    myJournal.DeleteEntryFromFile(myFileName, myEntryToDelete);
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
        public DateTime Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string  formattedEntry()
        {
            string _formattedEntry= $"{Date.ToShortDateString()} - Prompt: {Prompt} {Response}\n";
            return _formattedEntry;
        } 
    }
    public class ExistingEntry
    {
        public List<string> existingEntries = new List<string>();
        public string FileName { get; set; }

        //set an intialized value to Filename
        public ExistingEntry(string fileName)
        {
            FileName = fileName;
        }
    }
    public class Journal
    {
        //creat a list to store all entries
        public List<Entry> Entries = new List<Entry>();
        public ExistingEntry ExistingEntries { get; } = new ExistingEntry("your_filename.txt");
        public void WriteNewEntry()
        {
            // randomly choose a prompt
            string[] prompts = new string[]
            {
                "Who was the most interesting person you interacted with today?",
                "What was the best part of your day?",
                "How did you see the hand of the Lord in your life today?",
                "What was the strongest emotion you felt today?",
                "If you could do one thing over today, what would it be?"
            };

            Random random = new Random();
            string randomPrompt = prompts[random.Next(prompts.Length)];

            // show the prompt and let the users type their response
            Console.WriteLine(randomPrompt);
            string response = Console.ReadLine();

            // creat a new entry and add them to the journal
            Entry newEntry = new Entry
            {
                Date = DateTime.Now,
                Prompt = randomPrompt,
                Response = response
            };

            Entries.Add(newEntry);
            Console.WriteLine("Entry saved successfully.");
        }  
        public void displayEntries()
        {        
            Console.WriteLine("Display all journals：");    
            foreach (Entry entry in Entries)
            {
                string formatted = entry.formattedEntry();
                Console.WriteLine($"{formatted}\n");
            }
        } 
        public void displayExistingEntries(string FileName)
        {
            
            Console.WriteLine("Display all journals from " + FileName + "：");  
            string[] lines = System.IO.File.ReadAllLines(FileName);
            foreach (string entry in lines)
            {
                string[] parts = entry.Split(",");
                foreach (string part in parts)
                {
                    Console.WriteLine(part);
                }
                // 將舊檔資料新增到 ExistingEntries 中
                ExistingEntries.existingEntries.Add(entry);
            }
        }
        public void SaveJournalEntries(string fileName)
        {
            // check if the user type a filename, if not, ask to type one.
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("What is the filename? ");
                fileName = Console.ReadLine() + ".txt";
            }

            // Open the file in append mode, create it if it doesn't exist.
            using (StreamWriter outputFile = new StreamWriter(fileName, true)) // 使用 true 參數表示追加模式
            {
                // Write new entries into the file
                foreach (Entry entry in Entries)
                {
                    string formatted = entry.formattedEntry();
                    outputFile.WriteLine(formatted);
                }
            }
            Console.WriteLine("Entries saved successfully in " + fileName);
        }
        public void DeleteEntryFromFile(string fileName, string entryToDelete)
        {
            // read file into memory
            List<string> fileContents = File.ReadAllLines(fileName).ToList();

            // seek the data we want to delete is in which line 
            int indexToDelete = -1;
            for (int i = 0; i < fileContents.Count; i++)
            {
                string line = fileContents[i];
                if (fileContents[i].Contains(entryToDelete))
                {
                    indexToDelete = i;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        // 刪除非空白行的前後空白
                        fileContents[i] = line.Trim();
                    }
                    break;                                    
                }
            }
            if (indexToDelete != -1)
            {
                // 移除找到的行
                fileContents.RemoveAt(indexToDelete);
                // update the data and rewrite to the file
                File.WriteAllLines(fileName, fileContents);
                Console.WriteLine("Entry deleted successfully.");
            }
            else
            {
                Console.WriteLine("Entry not found in the file.");
            }
        }
    }
}