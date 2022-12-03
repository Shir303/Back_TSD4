using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("VENDEDOR")]
    public class Vendedor
    {
        [Key]
        public int UsuarioId { get; set; } // int, not null

    }
}
