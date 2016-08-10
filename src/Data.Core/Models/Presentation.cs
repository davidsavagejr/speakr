using System;

namespace Data.Core.Models
{
    public class Presentation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public DateTime DateCreated { get; set; }
    }
}