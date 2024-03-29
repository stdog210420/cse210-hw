using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Stretch Challenge
        //Have the user enter both positive and negative numbers, 
        //then find the smallest positive number (the positive number that is closest to zero).
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        double sum = 0;
        int n =0;
        double average = 0;
        int largest_number = 0;
        int smallest_number = 99;   
        List<int> numbers = new List<int>();

        while (number != 0)
        {
            Console.Write("Enter number: ");            
            number = int.Parse(Console.ReadLine()); //輸入的字元通常為文字，需要轉換成數字
            sum += number;
            n++;
            numbers.Add(number);
            if (number > 0)
            {
                if(number< smallest_number)
                {
                    smallest_number = number;
                }
                else if(number> largest_number)
                {
                    largest_number = number;
                }
            } 
        } 
        average = sum / (n-1);
        Console.WriteLine($"The sum is: {sum}"); 
        //使用格式化字符串中的 "N0"，其中 "N" 表示數值，而 "0" 表示小數點後的位數。
        //這將強制顯示浮點數後的所有位數，不進行四捨五入。
        Console.WriteLine($"The average is: {average}"); 
        // Console.WriteLine($"The number is: {n-1}"); 
        Console.WriteLine($"The largest number is: {largest_number}");
        Console.WriteLine($"The smallest positive number is: {smallest_number}");
        Console.WriteLine($"The sorted list is: ");
        numbers.Sort();
        foreach (int numberi in numbers)
        {
            Console.WriteLine(numberi);
        }
    }
}