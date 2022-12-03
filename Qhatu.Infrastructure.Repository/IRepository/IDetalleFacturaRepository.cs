using Qhatu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.Repository.IRepository
{
    public interface IDetalleFacturaRepository:IGenericRepository<DetalleFactura>
    {
        IEnumerable<DetalleFactura> GetDetalleFactura(int facturaId);
        IEnumerable<DetalleFactura> GetDetalleFacturaTienda(int facturaId,int tiendaId);
        DetalleFactura GetDetalleFacturaByIds(int facturaId, int tiendaId, int productoId);
        int DeleteDetalleFacturaByIds(int facturaId, int tiendaId, int productoId);
    }
}
