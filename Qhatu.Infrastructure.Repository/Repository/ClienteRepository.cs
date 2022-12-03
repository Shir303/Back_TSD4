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
    public class ClienteRepository:GenericRepository<Cliente>,IClienteRepository
    {
        public ClienteRepository(IDbTransaction transaction):base(transaction)
        {

        }
        public override int Add(Cliente cliente)
        {
            return Connection.Query<int>("INSERT INTO CLIENTE VALUES (@UsuarioId)",new {@UsuarioId= cliente.UsuarioId },Transaction).FirstOrDefault();
        }
    }
}
