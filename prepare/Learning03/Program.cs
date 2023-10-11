using System;
using System.Diagnostics;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3,4);
        Fraction f4 = new Fraction(3,4);
        f4.SetTop(1);
        f4.Setbottom(3);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()}");
        Console.WriteLine($"{f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()}");
        Console.WriteLine($"{f3.GetDecimalValue()}");
        Console.WriteLine($"{f4.GetFractionString()}");
        Console.WriteLine($"{f4.GetDecimalValue()}");
    }
}
public class Fraction
{
    private int _top;
    private int _bottom;
    public Fraction()
    {    
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber ;
        _bottom = 1 ;
    }
    public Fraction(int top, int bottom)
    {
        _top = top ;
        _bottom = bottom ;
    }
    public int GetTop(){
        return _top;
    }
    public int GetBottom(){
        return _bottom;
    }
    public void SetTop(int top){
        _top = top;        
    }
    public void Setbottom(int bottom){
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine($"Cannot divide by zero. Please enter a number except zero.");
        }
    }
    public string GetFractionString(){
            string _fraction = $"{_top} / {_bottom}";
            return _fraction;
    }
    public double GetDecimalValue(){
            return (double) _top / (double)_bottom;

    }
}       
