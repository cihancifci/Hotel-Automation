using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon.Helper.Repository.Abstractions
{
    public interface IRepository<T> where T : class
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool DeletedById(object id);
        T SelectedById(object id);
        List<T> SelectAll();
    }
}
