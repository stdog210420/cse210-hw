using System;

class Program
{
    static void Main(string[] args)
    {
        //Core Requirements
        // Console.Write(" What is the magic number? ");
        // string number = Console.ReadLine();
        // int numberNew = int.Parse(number); //輸入的字元通常為文字，需要轉換成數字

        Random number = new Random();

        string guess = "0";
        int guessNew = int.Parse(guess); //輸入的字元通常為文字，需要轉換成數字
        int count = 0; // Initialize the guess counter
        string response = "Y";

        while (response == "Y")
        {
            // 生成一個從1到100之間（包括1和100）的隨機數字
            int numberNew = number.Next(1, 101);       //Next(minValue, maxValue)，minValue（包括），maxValue（不包括）
            Console.WriteLine("隨機數字: " + numberNew);

            while (guessNew != numberNew)
            {
                Console.Write(" What is your guess? ");
                guess = Console.ReadLine();
                guessNew = int.Parse(guess); //輸入的字元通常為文字，需要轉換成數字
                count ++;

                if (guessNew < numberNew)
                {
                    Console.WriteLine("Higher.");

                }
                else if (guessNew > numberNew)
                {
                    Console.WriteLine("Lower.");
                } 

                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"你總共猜了{count}次。");
                }
            } 
            Console.Write("Do you want to play again? (Y/N) ");
            response = Console.ReadLine();
            response = response.ToUpper();
            guessNew = 0;
            count = 0;
        }

        Console.WriteLine("Thank you!");         
  
    }
}