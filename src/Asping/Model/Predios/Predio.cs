namespace Asping.Model.Locals
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Predio
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Freguesia")]
        public int FreguesiaId { get; set; }
        public Freguesia Freguesia { get; set; }
    }
}
