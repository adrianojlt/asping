namespace Infrastructure.Model.Locals;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Freguesia
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int codSF { get; set; }

    public ICollection<Predio>? Predios { get; set; }

    [ForeignKey("Concelho")]
    public int ConcelhoId { get; set; }
    public Concelho? Concelho { get; set; }
}
