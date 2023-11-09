using System;
using System.IO;
public class Tracker
{   int i = 0;
    private List<string> _goals = new List<string>();
    string goal;
    string  _choice = "0";
    string _check = "";
    string _name;
    string _description;
    int _score = 0;

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
    public string  FormattedGoal()
    {
        string _formattedGoal= $"{i}. [{_check}] {_name} ({_description})";
        return _formattedGoal;
    } 
    
    public void SetGoal()
    {
        // creat a new entry and add them to the journal
        goal = FormattedGoal();

        _goals.Add(goal);
        Console.WriteLine("You have set a new goal.");
    }
    public void ListGoal()
    {
        Console.WriteLine("Display all goals：");    
        foreach (string goal in _goals)
        {
            Console.WriteLine($"{goal}\n");
        }        
        
    }
    public void SaveGoal(string FileName)
    {
        // check if the user type a filename, if not, ask to type one.
        if (string.IsNullOrEmpty(FileName))
        {
            Console.WriteLine("What is the filename? ");
            FileName = Console.ReadLine();
        }

        // Open the file in append mode, create it if it doesn't exist.
        using (StreamWriter outputFile = new StreamWriter(FileName, true)) // 使用 true 參數表示追加模式
        {
            // Write new entries into the file
            foreach (string goal in _goals)
            {
                outputFile.WriteLine(goal);
            }
        }
        Console.WriteLine("Goals saved successfully in " + FileName);

    }

}