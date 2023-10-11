using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
                Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6,7);
    }
}
public class Fraction
{
    private int _top;
    private int _bottom;

    private float _fraction;
    public Fraction(){
        _fraction = 1/1;
    }
    public Fraction(int wholeNumber)
    {
        _bottom = 1;
        _top = wholeNumber;
        _fraction = wholeNumber / _bottom;
    }
    public Fraction(int top, int bottom)
    {
        _fraction = _top / _bottom;
    }
    public void GetTop(){

    }
    public void SetTop(int top){
        
    }
    public void bottom(){

    }
    public void Setottom(int bottom){
        
    }
    // public GetFractionString(){

    // }
    // public GetDecimalValue(){

    // }
}       
