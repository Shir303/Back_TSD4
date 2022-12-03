using Qhatu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.Repository.IRepository
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        public Usuario InicioSesion(string username, string password);
    }
}
