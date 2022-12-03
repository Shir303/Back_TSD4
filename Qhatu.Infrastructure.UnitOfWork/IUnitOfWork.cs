using Qhatu.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IAdministradorRepository AdministradorRepository { get; }
        public ICategoriaRepository CategoriaRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IDetalleFacturaRepository DetalleFacturaRepository { get; }
        public IFacturaRepository FacturaRepository { get; }
        public IProductoRepository ProductoRepository { get; }
        public ITiendaProductoRepository TiendaProductoRepository { get; }
        public ITiendaRepository TiendaRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IVendedorRepository VendedorRepository { get; }
        void Commit();
    }
}
