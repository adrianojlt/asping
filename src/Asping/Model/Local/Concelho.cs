namespace Asping.Model.Locals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Concelho
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Freguesia> Freguesias { get; set; }

        [ForeignKey("Distrito")]
        public int DistritoId { get; set; }
        public Distrito Distrito { get; set; }
    }
}
