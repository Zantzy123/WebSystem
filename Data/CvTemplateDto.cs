//   "name": "string",
//   "note": "string",
//   "creatorId": 0,
//   "filePath": "string"
// }
using System.ComponentModel.DataAnnotations;
using Longheng.Models;

///{
namespace Longheng.Data;
public class CvTemplateDto
{
    public string Name { get; set;}=null!;
    public string? Note { get; set;}
    public int CreatorId { get; set; }
    // [Required]
    public IFormFile FilePath { get; set; }=null!;
    public CvTemplate ToCvTemplate(IWebHostEnvironment environment)
    {
        // string path = Path.Combine(environment.WebRootPath,"uploads",FilePath.FileName);
        // using var stream = File.Create(path);
        // FilePath.CopyTo(stream);
        return new()
        {
            Name = Name,
            Note = Note,
            CreatorId = CreatorId,
            // FilePath = path,
        };
    }
}