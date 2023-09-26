using System;

class Program
{
    static void Main(string[] args)
    {
        // You program should contain two classes one for a Job and one for the Resume itself, as follows:

        Job job1 = new Job();

        job1._jobTitle = "Software Engineer";
        job1._companyName = "Microsoft";
        job1._startYear = "2019";        
        job1._endYear = "2022";
        job1.ShowJobInformation();
    }
        public class Job
        {
            // Keeps track of the company, job title, start year, and end year.
            public string _companyName;
            public string _jobTitle;
            public string _startYear;
            public string _endYear;

            // Displays the job information in the format "Job Title (Company) StartYear-EndYear", for example: "Software Engineer (Microsoft) 2019-2022".
            public void ShowJobInformation()
            {
                Console.WriteLine($"{_jobTitle} { _companyName} {_startYear}-{_endYear}");
            }
        }
        public class Resume
        {
            // Keeps track of the person's name and a list of their jobs.
            public string _personName;
            public List<Job> _Jobs = new List<Job>();
        }

}