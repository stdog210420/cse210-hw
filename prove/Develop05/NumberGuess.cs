using System;
public class NumberGuess
{  
    private int _playerBet;
    private int _playerNumber;
    private int  _randomNumber;
    public NumberGuess()
    {
        _playerBet = 0;
        _playerNumber = 0;
        _randomNumber = 0;        
    }
    public void StartGame()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Place your bet and guess a number between 0~100.");
        GetPlayerBet();
        GetPlayerNumber();
        CreatRandomNumber();
    }
    private int GetPlayerBet()
    {
        Console.WriteLine("Enter your bet amount(points): ");
        _playerBet = int.Parse(Console.ReadLine());
        return _playerBet;
    }
    private int GetPlayerNumber()
    {
        Console.Write("Guess a number between 0 and 100: ");
        _playerNumber = int.Parse(Console.ReadLine());
        return _playerNumber;
    }
    private int CreatRandomNumber()
    {
        Random random = new Random();
        _randomNumber = random.Next(0,101);
        return _randomNumber;
    }
    public int PlayerBet()
    {
        return _playerBet;
    }
    public int PlayerNumber()
    {
        return _playerNumber;
    }
    public int RandomNumber()
    {
        return _randomNumber;
    }

} 

