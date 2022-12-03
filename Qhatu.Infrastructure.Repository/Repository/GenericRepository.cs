using Dapper;

using Qhatu.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Infrastructure.Repository.Repository
{
    public class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class
    {
        public GenericRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public virtual int Add(T entity)
        {
            return (int)Connection.Insert<T>(entity, Transaction);
        }

        public int DeleteById(int id)
        {
            return Connection.Delete<T>(id, transaction: Transaction);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Connection.GetList<T>(null, transaction: Transaction);
        }

        public virtual T GetById(int id)
        {
            return Connection.Get<T>(id, transaction: Transaction);
        }

        public int Update(T entity)
        {
            return Connection.Update<T>(entity, transaction: Transaction);
        }
    }
}
