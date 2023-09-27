using System;

class Program
{
    static void Main(string[] args)
    {
        // You program should contain two classes one for a Job and one for the Resume itself, as follows:

        Job job1 = new Job();
        Job job2 = new Job();

        Resume myResume = new Resume();
        myResume._name = "Allison Rose"; 

        job1._jobTitle = "Software Engineer";
        job1._company = "(Microsoft)";
        job1._startYear = "2019";        
        job1._endYear = "2022";

        job2._jobTitle = "Manager";
        job2._company = "(Apple)";
        job2._startYear = "2022";        
        job2._endYear = "2023";

        myResume._Jobs.Add(job1);
        myResume._Jobs.Add(job2);

        myResume.ShowInformation();
        
    }
        public class Job
        {
            // Keeps track of the company, job title, start year, and end year.
            public string _company;
            public string _jobTitle;
            public string _startYear;
            public string _endYear;

            // Displays the job information in the format "Job Title (Company) StartYear-EndYear", for example: "Software Engineer (Microsoft) 2019-2022".
            public void ShowJobInformation()
            {
                Console.WriteLine($"{_jobTitle} { _company} {_startYear}-{_endYear}");
            }
        }
        public class Resume
        {
            // Keeps track of the person's name and a list of their jobs.
            public string _name;
            public List<Job> _Jobs = new List<Job>();
            public void ShowInformation()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Jobs:");
                foreach (var job in _Jobs)
                {                
                    job.ShowJobInformation();
                }
            }            
        }

}