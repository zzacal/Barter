namespace Barter.Models
{
    public interface IUser
    {
        string Email { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}