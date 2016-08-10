namespace Web.Core.Models
{
    public class PresentationCreated
    {
        public PresentationCreated(long newId)
        {
            NewId = newId;
        }

        public long NewId { get; set; } 
    }
}