using System;

namespace Data.Core.Models
{
    public class Feedback
    {
        public long Id { get; set; }
        public long TalkId { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public DateTime EntryDate { get; set; }
    }
}