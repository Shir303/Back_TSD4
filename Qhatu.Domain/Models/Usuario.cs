using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Domain.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; } // int, not null
        [MaxLength(50)]
        //[Required]
        public string Nombres { get; set; } // varchar(50), not null
        [MaxLength(50)]
        //[Required]
        public string ApePaterno { get; set; } // varchar(50), not null
        [MaxLength(50)]
        //[Required]
        public string ApeMaterno { get; set; } // varchar(50), not null
        [MaxLength(10)]
        public string Telefono { get; set; } // varchar(10), null
        [MaxLength(8)]
        //[Required]
        public string DNI { get; set; } // varchar(8), not null
        public DateTime? FechaNacim { get; set; } // date, null
        [MaxLength(20)]
        public string Rol { get; set; } // varchar(20), null
        [MaxLength(50)]
        //[Required]
        public string Email { get; set; } // varchar(50), not null
        [MaxLength(20)]
        public string Username { get; set; } // varchar(20), null
        [MaxLength(20)]
        public string Password { get; set; } // varchar(20), null
        public string Foto { get; set; } // image, null
    }
}
