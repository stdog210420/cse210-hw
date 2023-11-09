using System;
using System.IO;

public abstract class Goal
{   int i = 0;
    string _name;
    string _description;
    int _score = 0;
    int _grade = 0;
    int _time = 0;
    int _bonus= 0;

    public void CreateNewGoal()
    {
        Console.Write("What is name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _score = int.Parse(Console.ReadLine());
        Console.WriteLine($"You have {_grade} points.");

        Console.WriteLine($"Goal: {_name}  Description: {_description}  Grade: {_score}");
    }
    public void CreateBonus()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus ? ");
        _time = int.Parse(Console.ReadLine());
        Console.Write("What is bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
        Console.WriteLine($"You have {_grade} points.");

        Console.WriteLine($"Goal: {_name}  Description: {_description}  Grade: {_score}");
    }


    public abstract int GetGrade();
  //creat a list to store all entries
    //set an intialized value to Filename

    // public void LoadGoal()
    // {

    // }
    // public void RecordEvent()
    // {

    

}