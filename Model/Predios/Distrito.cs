namespace Asping.Model.Predios
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Distrito
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Concelho> Concelhos { get; set; }
    }
}
