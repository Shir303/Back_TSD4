using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; } // int, not null
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } // varchar(50), not null
    }
}
