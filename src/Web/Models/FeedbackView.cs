using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class FeedbackView 
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<FeedbackEntry> Entries { get; set; } 
    }

    public class FeedbackEntry
    {
        public long Id { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public DateTime EntryDate { get; set; }
    }
}