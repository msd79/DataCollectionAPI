using System;

namespace DataCollectionAPI.Models
{
    public class Event
    {
        enum Level
        {
            Information,
            Warning,
            Error
        }

        public int Id { get; set; }
        public DateTime DateandTime { get; set; }
        public string Source { get; set; }
        public string Keyword { get; set; }
        public string Details { get; set; }

    }
}