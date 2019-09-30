using Otel_Otomasyon.Helper;
using Otel_Otomasyon.Helper.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
    public abstract class Repository<T> : IRepository<T>  where T : class
    {
        protected string _connectionString;
        protected string _dbProviderName;
        protected DbProviderFactory _dbProviderFactory;
        protected int _rowsAffected, _errorCode;
        protected bool _bDisposed;

        public abstract bool DeletedById(object id);



        public abstract bool Insert(T entity);

        public abstract List<T> SelectAll();

        public abstract T SelectedById(object id);

        public abstract bool Update(T entity);
    }
}
