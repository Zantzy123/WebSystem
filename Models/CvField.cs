using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace Longheng.Models;
[Table("cvfields")]
public class CvField
{
    public int Id { get; set; }
    public FieldType Type { get; set; } = FieldType.Personal;
    public string Name { get; set; }=null!;
    public string? Note { get; set; }
    public string Values { get; set; }="[]";//string array
}
public enum FieldType
{
    Personal, Education, Experiences, References, Languages
}