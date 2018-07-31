using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Prato
    {
        [Key]
        public int PratoID { get; set; }
        public string PratoNome { get; set; }
        public decimal PratoPreco { get; set; }

        [ForeignKey("Rest")]
        public int RestID { get; set; }

        public virtual Restaurante Rest { get; set; }
    }
}