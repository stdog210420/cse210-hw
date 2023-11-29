using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

    //get the journal entry
    class Entry
    {
        private string _date;
        private string _prompt;
        private string _response;
        public string Date()
        {           
            return _date;
        }
        public string Prompt()
        {
            return _prompt;
        }
        public string Response()
        {
            return _response;
        }
        public Entry(DateTime date, string prompt, string response)
        {
            _date = date.ToShortDateString();
            _prompt = prompt;
            _response = response;
        }
        public string  formattedEntry()
        {
            string _formattedEntry= $"{Date()} - Prompt: {Prompt()} {Response()}\n";
            return _formattedEntry;
        } 
    }