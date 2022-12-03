using Qhatu.Helpers;
using Qhatu.Infrastructure.Repository.IRepository;
using Qhatu.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction transaction;
        private IDbConnection connection;

        private IAdministradorRepository administradorRepository;
        private ICategoriaRepository categoriaRepository;
        private IClienteRepository clienteRepository;
        private IDetalleFacturaRepository detalleFacturaRepository;
        private IFacturaRepository facturaRepository;
        private IProductoRepository productoRepository;
        private ITiendaProductoRepository tiendaProductoRepository;
        private ITiendaRepository tiendaRepository;
        private IUsuarioRepository usuarioRepository;
        private IVendedorRepository vendedorRepository;
        public UnitOfWork()
        {
            connection = new SqlConnection(new Settings().connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public IAdministradorRepository AdministradorRepository
        {
            get
            {
                return administradorRepository ?? (administradorRepository = new AdministradorRepository(transaction));
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return categoriaRepository ?? (categoriaRepository = new CategoriaRepository(transaction));
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return clienteRepository ?? (clienteRepository = new ClienteRepository(transaction));
            }
        }

        public IDetalleFacturaRepository DetalleFacturaRepository
        {
            get
            {
                return detalleFacturaRepository ?? (detalleFacturaRepository = new DetalleFacturaRepository(transaction));
            }
        }

        public IFacturaRepository FacturaRepository
        {
            get
            {
                return facturaRepository ?? (facturaRepository = new FacturaRepository(transaction));
            }
        }
        public IProductoRepository ProductoRepository
        {
            get
            {
                return productoRepository ?? (productoRepository = new ProductoRepository(transaction));
            }
        }
        public ITiendaProductoRepository TiendaProductoRepository
        {
            get
            {
                return tiendaProductoRepository ?? (tiendaProductoRepository = new TiendaProductoRepository(transaction));
            }
        }

        public ITiendaRepository TiendaRepository
        {
            get
            {
                return tiendaRepository ?? (tiendaRepository = new TiendaRepository(transaction));
            }
        }



    public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return usuarioRepository ?? (usuarioRepository = new UsuarioRepository(transaction));
            }
        }

    public IVendedorRepository VendedorRepository
        {
            get
            {
                return vendedorRepository ?? (vendedorRepository = new VendedorRepository(transaction));
            }
        }

    public void Commit()
    {
        try
        {
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
        }
        finally
        {
            transaction.Dispose();
            transaction = connection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
}
