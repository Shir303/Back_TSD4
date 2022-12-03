using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; } // int, not null
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } // varchar(50), not null
        [MaxLength(255)]
        public string Descripcion { get; set; } // varchar(255), null
        [Required]
        public int CategoriaId { get; set; } // int, not null
        public string Foto { get; set; } // image, null
        [MaxLength(10)]
        public string Medida { get; set; } // varchar(10), null
        [MaxLength(20)]
        public string Marca { get; set; } // varchar(20), null

    }
}
