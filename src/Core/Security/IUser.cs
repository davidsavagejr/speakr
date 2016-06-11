namespace Core.Security
{
    public interface IUser
    {
        string UserName { get; } 
        string NameIdentifier { get; }
        string EmailAddress { get; }
        string Name { get; }
        string GivenName { get; }
        string SurName { get; }
    }
}