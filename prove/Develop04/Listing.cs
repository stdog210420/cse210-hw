class Listing:Activity
{
    private string _activity = "Listing";
    private string _text = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public void ListingActivity()
    {
        Message(_activity, _text);
        Console.WriteLine($"List as many responses you can to the following prompt:");
        // randomly choose a prompt
        string[] _prompts = new string[]
        {
            "---Who are people that you appreciate?---",
            "---What are personal strengths of yours?---",
            "---Who are people that you have helped this week?---",
            "---When have you felt the Holy Ghost this month?---",
            "---Who are some of your personal heroes?---",  
        };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Random _random = new Random();
            string _randomPrompt = _prompts[_random.Next(_prompts.Length)];
            Console.WriteLine();  
            Console.WriteLine(_randomPrompt);
            Console.WriteLine();  
            Console.Write($"You may begin in:");
            CountDown();
            string input;
            while (DateTime.Now < endTime)
            {
                Console.WriteLine(); 
                Console.Write($"> ");
                input = Console.ReadLine();
                
                while (input !="" && DateTime.Now < endTime) 
                {
                    Console.Write($"> ");
                    input = Console.ReadLine();
                    // creat a new entry and add them to the journal
                    List<string> _inputs = new List<string>();
                    _inputs.Add(input);
                    i ++;
                }  
            }         
        Console.WriteLine($"You listed {i+1} items!");  
        }
        Done(_activity);
    
    }
}