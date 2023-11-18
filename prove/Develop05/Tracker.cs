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
        Console.ForegroundColor = ConsoleColor.Blue;    
        Console.WriteLine("\nThe types of Goals are:");              
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goals");
        Console.WriteLine("  3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? ");                          
    }


}