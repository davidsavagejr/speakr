using System;

namespace Data.Models
{
    public class MyFeedback
    {
        public long Id { get; set; } 
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long FeedbackCount { get; set; }
    }
}