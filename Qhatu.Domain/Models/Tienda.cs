using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("TIENDA")]
    public class Tienda
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TiendaId { get; set; } // int, not null
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } // varchar(50), not null
        [MaxLength(50)]
        [Required]
        public string Direccion { get; set; } // varchar(50), not null
        [MaxLength(50)]
        [Required]
        public string RazonSocial { get; set; } // varchar(50), not null
        [MaxLength(20)]
        [Required]
        public string RUC { get; set; } // varchar(20), not null
        public int? UsuarioId { get; set; } // int, null

    }
}
