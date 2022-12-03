using Dapper;
using Qhatu.Domain.Models;
using Qhatu.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.Repository.Repository
{
    public class UsuarioRepository:GenericRepository<Usuario>,IUsuarioRepository
    {
        public UsuarioRepository(IDbTransaction transaction):base(transaction)
        {

        }

        public Usuario InicioSesion(string username, string password)
        {
            var result = Connection.GetList<Usuario>("WHERE Username=@Username AND Password=@Password", new { Username = username, Password = password }, Transaction).FirstOrDefault() ?? (new Usuario());
            //result.Password = null;
            return result;
        }
    }
}