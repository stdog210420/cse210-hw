using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
    public class Journal
    {
        //creat a list to store all entries
        private List<Entry> _entries = new List<Entry>();
        public void WriteEntry()
        {
            // randomly choose a prompt
            List<string> _prompts = new List<string>
            {
                "Who was the most interesting person you interacted with today?",
                "What was the best part of your day?",
                "How did you see the hand of the Lord in your life today?",
                "What was the strongest emotion you felt today?",
                "If you could do one thing over today, what would it be?"
            };

            Random _random = new Random();
            string _randomPrompt = _prompts[_random.Next(_prompts.Count)];

            // show the prompt and let the users type their response
            Console.WriteLine(_randomPrompt);
            string _response = Console.ReadLine();

            // creat a new entry and add them to the journal
            Entry _newEntry = new Entry(DateTime.Now, _randomPrompt, _response)
            {
            };

            _entries.Add(_newEntry);
            Console.WriteLine("Entry saved successfully.");
        }  
        public void displayEntries()
        {        
            Console.WriteLine("Display all journals：");    
            foreach (Entry entry in _entries)
            {
                string _formatted = entry.formattedEntry();
                Console.WriteLine($"{_formatted}\n");
            }
        } 
        public void LoadEntries(string fileName)
        {
            
            Console.WriteLine("Display all journals from " + fileName + "：");  
            string[] _lines = File.ReadAllLines(fileName);
            foreach (string line in _lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                }
                else
                {
                    string[] parts = line.Split(" - Prompt: ");
                    string entryDate = parts[0].Trim();
                    string entryData = parts[1].Trim();
                    //先將char轉換成string，再從string轉換到DateTime格式
                    if (DateTime.TryParse(entryDate, out DateTime _date))
                    {
                        // 轉換成功，現在 _date 包含有效的日期和時間
                        // 将字符串分割成子字符串数组
                        string[] subparts = entryData.ToString().Split('?');
                        // 移除各个部分的前后空格
                        for (int i = 0; i < subparts.Length; i++)
                        {
                            subparts[i] = subparts[i].Trim();
                        }
                        // 确保我们有足够的部分
                        if (subparts.Length == 2)
                        {
                            string _prompt = subparts[0].ToString() + "?";
                            string _response = subparts[1].ToString();
                            Entry createEntry = new Entry(_date, _prompt, _response);
                            if (createEntry != null)
                            {
                                _entries.Add(createEntry);
                            }
                        }
                    }
                    else
                    {
                        // 轉換失敗，日期格式無效
                        Console.WriteLine("Invalid date format");
                    }        
                }
        

            }
        }

        public void SaveEntries(string _fileName)
        {
            // check if the user type a filename, if not, ask to type one.
            if (string.IsNullOrEmpty(_fileName))
            {
                Console.WriteLine("What is the filename? ");
                _fileName = Console.ReadLine() + ".txt";
            }

            // Open the file in append mode, create it if it doesn't exist.
            using (StreamWriter outputFile = new StreamWriter(_fileName, true)) // 使用 true 參數表示追加模式
            {
                // Write new entries into the file
                foreach (Entry entry in _entries)
                {
                    string _formatted = entry.formattedEntry();
                    outputFile.WriteLine(_formatted);
                }
            }
            Console.WriteLine("Entries saved successfully in " + _fileName);
        }
        public void DeleteEntryFromFile(string _fileName, string _entryToDelete)
        {
            // read file into memory
            List<string> _fileContents = File.ReadAllLines(_fileName).ToList();

            // seek the data we want to delete is in which line 
            int indexToDelete = -1;
            for (int i = 0; i < _fileContents.Count; i++)
            {
                string line = _fileContents[i];
                if (_fileContents[i].Contains(_entryToDelete))
                {
                    indexToDelete = i;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        // 刪除非空白行的前後空白
                        _fileContents[i] = line.Trim();
                    }
                    break;                                    
                }
            }
            if (indexToDelete != -1)
            {
                // 移除找到的行
                _fileContents.RemoveAt(indexToDelete);
                // update the data and rewrite to the file
                File.WriteAllLines(_fileName, _fileContents);
                Console.WriteLine("Entry deleted successfully.");
            }
            else
            {
                Console.WriteLine("Entry not found in the file.");
            }
        }
    }
