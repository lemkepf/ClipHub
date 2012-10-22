using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClipHub.Code.Models;

namespace ClipHub.Code.DAO
{
    public interface IDataAccess : IDisposable 
    {
        void CommitChanges();
        System.Linq.IQueryable<T> Where<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        System.Linq.IQueryable<T> WhereOrderBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression, System.Linq.Expressions.Expression<Func<T, bool>> orderExpression);
        System.Linq.IQueryable<T> OrderBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> orderExpression);
        void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        void Delete<T>(T item);
        void DeleteAll<T>();
        T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        System.Linq.IQueryable<T> All<T>();
        void Save<T>(T item);

    }
}
