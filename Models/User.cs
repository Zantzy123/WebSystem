using System.ComponentModel.DataAnnotations.Schema;

namespace Longheng.Models;
[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }="";
    public string Email { get; set; }="";
    public string PasswordHash { get; set; }="";
    public virtual List<CvTemplate> OwnedTemplates { get; set; }=[];
    public virtual List<CvTemplate> UsedTemplates { get; set; }=[];
}