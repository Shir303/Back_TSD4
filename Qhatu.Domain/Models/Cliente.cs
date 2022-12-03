using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        public int UsuarioId { get; set; } // int, not null
    }
}
