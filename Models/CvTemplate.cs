using System.ComponentModel.DataAnnotations.Schema;

namespace Longheng.Models;
[Table("cvtemplates")]
public class CvTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }="";
    public string? Note { get; set; }
    [ForeignKey("creator_id")]
    public virtual int CreatorId { get; set; }
    public virtual User Creator { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public virtual List<User> Users { get; set; }=[];
}