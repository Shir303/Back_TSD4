using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("FACTURA")]
    public class Factura
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; } // int, not null
        [Required]
        public int UsuarioId { get; set; } // int, not null
        [Required]
        public DateTime FechaFact { get; set; } // datetime, not null

    }
}
