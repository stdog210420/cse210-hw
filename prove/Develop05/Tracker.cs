using System;
using System.IO;
public class Tracker
{ 
    public void TrackerOptions()
    {   
        Console.ForegroundColor = ConsoleColor.Blue;    
        Console.WriteLine("\nMenu Options:");              
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
        Console.Write("What is name of your goal? ");
        string _name = Console.ReadLine();        
        Console.Write("What is a short description of it? ");
        string _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int _score = int.Parse(Console.ReadLine());                     
    }


}