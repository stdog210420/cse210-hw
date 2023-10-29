class Breathing:Activity
{
    private string _activity = "Breathing";
    private string _text = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    public void BreathingActivity()
    {
        Message(_activity, _text);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"\nBreathe in..."); 
            CountDown();
            Console.Write($"\nNow breathe out..."); 
            CountDown();
            // Console.WriteLine(DateTime.Now);
            // Console.WriteLine(endTime);
            Console.WriteLine();   
        }
        Done(_activity);
    
    }
    

}