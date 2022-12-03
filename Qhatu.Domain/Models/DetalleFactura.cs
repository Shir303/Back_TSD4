using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("DETALLEFACTURA")]
    public class DetalleFactura
    {
        [Key]
        //[Column(Order = 1)]
        [Required]
        public int FacturaId { get; set; } // int, not null
        [Key]
        //[Column(Order = 2)]
        [Required]
        public int TiendaId { get; set; } // int, not null
        [Key]
        //[Column(Order = 3)]
        [Required]
        public int ProductoId { get; set; } // int, not null
        public int Cantidad { get; set; } // int, null
        public decimal Monto { get; set; } // decimal(18,0), null

    }
}
