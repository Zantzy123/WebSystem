using System.ComponentModel.DataAnnotations.Schema;

namespace Longheng.Models;
[Table("fieldvalues")]
public class FieldValue
{
    public int Id { get; set; }
    [ForeignKey("field_id")]
    public virtual int FieldId { get; set; }
    public virtual CvField Field { get; set; } = null!;
    public string? Value { get; set; }
}