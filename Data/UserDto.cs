// {
//   "name": "string",
//   "email": "string",
//   "passwordHash": "string"
// }
using Longheng.Models;

namespace Longheng.Data;
public class UserDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public User ToUser()
    {
        // const string SECRET = "Itis@2025MySecret";
        return new()
        {
            Name = Name,
            Email = Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordHash),
        };
    }
}