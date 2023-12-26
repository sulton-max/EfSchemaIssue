namespace EfSchemaProblem.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public Guid ProfilePictureId { get; set; }
    
    public StorageFile ProfilePicture { get; set; } = null!;
}