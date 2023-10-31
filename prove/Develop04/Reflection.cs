class Reflection:Activity
{
    private string _activity = "Reflection";
    private string _text = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    public int _sumDuration =0; 
    public void ReflectionActivity()
    {
        Message(_activity, _text);
        Console.WriteLine($"Consider the following prompt:");
        // randomly choose a prompt
        string[] _prompts = new string[]
        {
            "---Think of a time when you stood up for someone else.---",
            "---Think of a time when you did something really difficult.---",
            "---Think of a time when you helped someone in need.---",
            "---Think of a time when you did something truly selfless.---",
        };
        string[] _questions = new string[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };
        Random _random = new Random();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_Duration);
        while (DateTime.Now < endTime)
        {
            string _randomPrompt = _prompts[_random.Next(_prompts.Length)];
            Console.WriteLine();  
            Console.WriteLine(_randomPrompt);
            Console.WriteLine();  
            Console.WriteLine($"When you have something in mind, press enter to continue."); 
            string input = Console.ReadLine();
            int i = 0;
            while ( input =="" && DateTime.Now < endTime)
            {
                string _randomQuestion = _questions[_random.Next(_questions.Length)];
                Console.WriteLine($">{_randomQuestion}");
                foreach (string s in animationStrings)
                {
                    Console.Write(s);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }
                i++ ;
                if (i >= _questions.Length || i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        Console.WriteLine();  
        }

        Done(_activity);
        _sumDuration += _Duration;    
    }
}