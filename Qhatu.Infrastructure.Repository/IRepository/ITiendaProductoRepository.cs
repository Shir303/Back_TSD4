using Qhatu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.Repository.IRepository
{
    public interface ITiendaProductoRepository:IGenericRepository<TiendaProducto>
    {
        TiendaProducto GetTiendaProductoByIds(int tiendaId, int productoId);
        int DeleteTiendaProductoByIds(int tiendaId, int productoId);
        int UpdateStock(TiendaProducto tiendaProducto);
        int UpdatePrecio(TiendaProducto tiendaProducto);
        int UpdateStockPrecio(TiendaProducto tiendaProducto);
    }
}
