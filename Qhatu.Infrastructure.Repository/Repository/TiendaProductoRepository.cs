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
    public class TiendaProductoRepository : GenericRepository<TiendaProducto>, ITiendaProductoRepository
    {
        public TiendaProductoRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public TiendaProducto GetTiendaProductoByIds(int tiendaId, int productoId)
        {
            return Connection.GetList<TiendaProducto>("WHERE TiendaId=@TiendaId AND ProductoId=@ProductoId", new { TiendaId = tiendaId, ProductoId = productoId }, Transaction).FirstOrDefault();
        }
        public int DeleteTiendaProductoByIds(int tiendaId, int productoId)
        {
            var aux = new TiendaProducto
            {
                TiendaId = tiendaId,
                ProductoId = productoId
            };
            return Connection.Delete(aux, Transaction);
        }

        public int UpdateStock(TiendaProducto tiendaProducto)
        {
            var tp = GetTiendaProductoByIds(tiendaProducto.TiendaId,tiendaProducto.ProductoId);
            tp.Stock = tiendaProducto.Stock;
            return Connection.Update(tp,Transaction);
        }

        public int UpdatePrecio(TiendaProducto tiendaProducto)
        {
            var tp = GetTiendaProductoByIds(tiendaProducto.TiendaId, tiendaProducto.ProductoId);
            tp.Precio = tiendaProducto.Precio;
            return Connection.Update(tp, Transaction);
        }

        public int UpdateStockPrecio(TiendaProducto tiendaProducto)
        {
            var tp = GetTiendaProductoByIds(tiendaProducto.TiendaId, tiendaProducto.ProductoId);
            tp.Stock = tiendaProducto.Stock;
            tp.Precio = tiendaProducto.Precio;
            return Connection.Update(tp, Transaction);
        }
    }
}
