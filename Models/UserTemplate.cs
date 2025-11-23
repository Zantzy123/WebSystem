using System.ComponentModel.DataAnnotations.Schema;

namespace Longheng.Models;
[Table("usertemplates")]
public class UserTemplate
{
    public int Id { get; set; }
    public virtual int UserId { get; set; }
    public virtual User User { get; set; }=null!;

    public virtual int TemplateId { get; set; }
    public virtual CvTemplate Template { get; set; }=null!;
    public virtual List<FieldValue> FieldValues { get; set; }=[];
}