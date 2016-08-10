using System;

namespace Data.Core.Models
{
    public class FeedbackForTalk
    {
        public long Id { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public DateTime EntryDate { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}