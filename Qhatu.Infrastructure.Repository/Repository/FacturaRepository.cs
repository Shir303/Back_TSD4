using Qhatu.Domain.Models;
using Qhatu.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Qhatu.Infrastructure.Repository.Repository
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
        public FacturaRepository(IDbTransaction transaction):base(transaction)
        {

        }

        public IEnumerable<Factura> GetFacturasById(int usuarioId)
        {
            return Connection.GetList<Factura>("WHERE UsuarioId=@UsuarioId",new { usuarioId=usuarioId},Transaction);
        }
    }
}
