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
    public class DetalleFacturaRepository:GenericRepository<DetalleFactura>,IDetalleFacturaRepository
    {
        public DetalleFacturaRepository(IDbTransaction transaction):base(transaction)
        {

        }

        public int DeleteDetalleFacturaByIds(int facturaId, int tiendaId, int productoId)
        {
            var aux = new DetalleFactura
            {
                FacturaId=facturaId,
                TiendaId=tiendaId,
                ProductoId=productoId
            };
            return Connection.Delete(aux, Transaction);
        }

        public IEnumerable<DetalleFactura> GetDetalleFactura(int facturaId)
        {
            return Connection.GetList<DetalleFactura>("WHERE FacturaId=@FacturaId", new { FacturaId = facturaId }, Transaction);
        }

        public DetalleFactura GetDetalleFacturaByIds(int facturaId, int tiendaId, int productoId)
        {
            return Connection.GetList<DetalleFactura>("WHERE FacturaId=@FacturaId,TiendaId=@TiendaId AND ProductoId=@ProductoId",new { FacturaId=facturaId,TiendaId=tiendaId,ProductoId=productoId },Transaction).FirstOrDefault();
        }

        public IEnumerable<DetalleFactura> GetDetalleFacturaTienda(int facturaId, int tiendaId)
        {
            return Connection.GetList<DetalleFactura>("WHERE FacturaId=@FacturaId,TiendaId=@TiendaId", new { FacturaId = facturaId, TiendaId = tiendaId }, Transaction);
        }
    }
}
