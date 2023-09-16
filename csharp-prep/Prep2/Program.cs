using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage, then write a series of if-elif-else statements to print out the appropriate letter grade. 
        // (At this point, you'll have a separate print statement for each grade letter in the appropriate block.)

        Console.Write("Please input your grad percent: ");
        string grade = Console.ReadLine();
        int gradeNew = int.Parse(grade); //輸入的字元通常為文字，需要轉換成數字
        string letter;
        string sign;

        //Core Requirements
        if (gradeNew >= 90)
        {
            Console.WriteLine("Your grade is A. Congratulation you pass the course.");
        }
        else if (gradeNew >= 80)
        {
            Console.WriteLine("Your grade is B. Congratulation you pass the course.");
        }        
        else if (gradeNew >= 70)
        {
            Console.WriteLine("Your grade is C. Congratulation you pass the course.");
        } 
        else if (gradeNew >= 60)
        {
            Console.WriteLine("Your grade is D. Sorry, you don't pass the course. Let's try harder next time.");
        } 

        else
        {
            Console.WriteLine("Your grade is F. Sorry, you don't pass the course. Let's try harder next time.");
        } 

        // Assume that you must have at least a 70 to pass the class. After determining the letter grade and printing it out. 
        // Add a separate if statement to determine if the user passed the course, and if so display a message to congratulate them.
        // If not, display a different message to encourage them for next time. 
        if (gradeNew >= 70)
        {
            Console.WriteLine("Congratulation you pass the course.");
        } 
        else
        {
            Console.WriteLine("You don't pass the course. Let's try harder next time.");
        } 

        //STRETCH CHALLENGE
        //取得餘數
        if (gradeNew >= 90)
        {
            letter = "A";
            if (gradeNew % 10 >= 7 || gradeNew % 10 >= 0)
            {
                sign =" ";
            }
            else
            {
                sign ="-";
            }
        }
        else if (gradeNew >= 80)
        {
            letter = "B";
            if (gradeNew % 10 >= 7)
            {
                sign ="+";
            }
            else
            {
                sign ="-";
            }
        }            
        else if (gradeNew >= 70)
        {
            letter = "C";
            if (gradeNew % 10 >= 7)
            {
            sign ="+";
            }
            else
            {
                sign ="-";
            }
        }   
        else if (gradeNew >= 60)
        {
            letter = "D";
            if (gradeNew % 10 >= 7)
            {
                sign ="+";
            }
            else
            {
                sign ="-";
            }
        } 
        else
        {
            letter = "F";    
            sign =" ";
        } 


        if (gradeNew >= 70)
        {
            Console.WriteLine($"Your grade is {letter}{sign}. Congratulation you pass the course.");
        }
        else
        {
            Console.WriteLine($"Your grade is {letter}{sign}. You don't pass the course. Let's try harder next time.");
        }

    }
}