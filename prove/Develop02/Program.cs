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
}