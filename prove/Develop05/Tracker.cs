using System;
using System.IO;
public class Tracker
{ 
    Goal myGoals = new Goal();
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

    public void ListGoal()
    {
        Console.WriteLine("Display all goals:");
        for (int j = 0; j < myGoals.GoalList().Count; j++)
        {
            Console.WriteLine($"{myGoals.GoalList()[j]}");
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
            foreach (string goal in GoalList())
            {
                outputFile.WriteLine(goal);
            }
        }
        Console.WriteLine("Goals saved successfully in " + FileName);

    }

  //creat a list to store all entries
    //set an intialized value to Filename

    // public void LoadGoal()
    // {

    // }
    // public void RecordEvent()
    // {

}