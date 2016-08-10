namespace Web.Core.Models
{
    public class DeletePresentation
    {
        public DeletePresentation()
        {
        }

        public DeletePresentation(long id, string userId)
        {
            Id = id;
            UserId = userId;
            Confirmed = false;
        }

        public long Id { get; set; } 

        public bool Confirmed { get; set; }

        public string UserId { get; set; }
    }
}