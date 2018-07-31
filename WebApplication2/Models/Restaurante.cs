using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Restaurante
    {
        [Key]
        public int RestauranteID { get; set; }
        public string RestauranteNome { get; set; }

        public virtual ICollection<Prato> Pratos { get; set; }
    }
}