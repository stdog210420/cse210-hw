using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Design Requirements
        Choice choice = new Choice();
        Record myRecord = new Record();
        string _choice = "0";
        string myFileName;
        string fileName = ""; 

        while (_choice != "5")
        {
            choice.ShowOptions();
            _choice = Console.ReadLine();

            switch(_choice)
            {
                // choice 1. Write
                case "1":
                {
                    myRecord.getRecord();
                    break;
                }
                // choice 2. Display
                case "2":
                {                
                    myRecord.display();
                    break;
                }
                // choice 3. Load  
                // open the text file and read the all lines
                case "3":
                {
                    Console.WriteLine("What is the filename? ");
                    myFileName = Console.ReadLine() + ".txt";
                    string[] lines = System.IO.File.ReadAllLines(myFileName);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(",");
                        foreach (string part in parts)
                        {
                            Console.WriteLine(part);
                        }
                    }
                    break;
                }
                // choice 4. Save  
                // Save the text in a file
                case "4":
                {
                    myRecord.SaveJournalEntries(fileName);
                    break;
                }
                // choice 5. Quit 
                case "5":
                {
                    Console.WriteLine("Already Quit!");
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
            Console.Write("What would you like to do? ");    
        } 
        
    }
    public class Record
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText;
        int prompt_index = 0;
        public List<string> journalEntries = new List<string>();
        public string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today? ",
            "What was the best part of my day? ",
            "How did I see the hand of the Lord in my life today? ",
            "What was the strongest emotion I felt today? ",
            "If I had one thing I could do over today, what would it be? "
        };  
        public void getRecord()
        {
            //The index will run from 0 to 4, when the index is over or equal to 5, make it return to zero
            if (prompt_index >= prompts.Length)  
            {
                prompt_index = 0;
            }     
            //save the text of each prompt
            string prompt = prompts[prompt_index];
            Console.WriteLine(prompt);
            //save the answer
            string answer = Console.ReadLine();
            //get the current datetime and swith it to string
            dateText  = theCurrentTime.ToShortDateString();
            
            // save the record
            string journal = $"{dateText}- Prompt: {prompt} {answer} "; 
            journalEntries.Add(journal);
            prompt_index ++;    
        }

        public void display()
        {
            Console.WriteLine("Display all journals：");    
            for (int i = 0; i < journalEntries.Count; i++)
            {
                Console.WriteLine($"{journalEntries[i]}\n"); // \n換行
            }
        }
        public void SaveJournalEntries(string fileName)
        {
            Console.WriteLine("What is the filename? ");
            fileName = Console.ReadLine() + ".txt";
            using (StreamWriter outputFile = new StreamWriter(fileName))               
            // You can use the $ and include variables just like with Console.WriteLine
            for (int i = 0; i < journalEntries.Count; i++)
            {
                outputFile.WriteLine($"{journalEntries[i]}");
            }
        }

    }
}