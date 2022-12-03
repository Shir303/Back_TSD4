using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("TIENDAPRODUCTO")]
    public class TiendaProducto
    {
        [Key]
        //[Column(Order = 1)]
        [Required]
        public int TiendaId { get; set; } // int, not null
        [Key]
        //[Column(Order = 2)]
        [Required]
        public int ProductoId { get; set; } // int, not null
        [Required]
        public int Stock { get; set; } // int, not null
        [Required]
        public decimal Precio { get; set; } // decimal(18,0), not null

    }
}
