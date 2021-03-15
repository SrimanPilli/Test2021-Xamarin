using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test2021Library.Helper
{
    public interface ISqliteDataService
    {
        void CreateTables();
        List<T> ReadList<T>() where T : new();
        int Insert(object value, Type type);
        int Update(object value, Type type);
        int InsertOrUpdate(object value, Type type);
        int Count<T>() where T : new();
        T ReadFirst<T>(Expression<Func<T, bool>> predicate) where T : new();
    }
}
