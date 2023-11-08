using System;

public abstract class Goal
{   int i = 0;
    string _name;
    string _description;
    int _score = 0;
    int _grade = 0;
    string _check = "";
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

    public string  FormattedGoal()
    {
        string _formattedGoal= $"{i}. [{_check}] {_name} ({_description})";
        return _formattedGoal;
    } 
    
    public abstract int GetGrade();


}