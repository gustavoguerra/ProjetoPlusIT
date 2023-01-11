using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Sorvete.Domain;
using Sorvete.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Sorvete.Repository.Concrete
{
    public class Repository<TEntiy> : IRepository<TEntiy> where TEntiy : Entity
    {
        private readonly IConfiguration _config;
        protected IDbConnection Conn => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public virtual IEnumerable<TEntiy> GetAll()
        {
            return Conn.GetAll<TEntiy>();
        }

        public virtual TEntiy GetById(int id)
        {
            return Conn.Get<TEntiy>(id);
        }

        public virtual bool Insert(TEntiy obj)
        {
            Conn.Insert(obj);
            return true;
        }

        public virtual bool Remove(TEntiy obj)
        {
            Conn.Delete(obj);
            return true;
        }

        public virtual bool Update(TEntiy obj)
        {
            Conn.Update(obj);
            return true;
        }
    }
}
