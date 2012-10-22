using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Linq;
using ClipHub.Code.Models;

namespace ClipHub.Code.DAO
{
    public class Db4oDataAccess : IDataAccess, IDisposable
    {
        public IObjectContainer db;

        public Db4oDataAccess(String dbName)
        {
            db = Db4oEmbedded.OpenFile(dbName);
        }

        public IQueryable<T> All<T>()
        {
            return (from T items in db 
                    select items).AsQueryable();
        }

        /// <summary>
        /// Finds a subset of items using a passed-in expression lambda
        /// </summary>
        public IQueryable<T> Where<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All<T>().Where(expression);
        }

        /// <summary>
        /// Finds a subset of items using a passed-in expression lambda
        /// </summary>
        public IQueryable<T> WhereOrderBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression, System.Linq.Expressions.Expression<Func<T, bool>> orderExpression)
        {
            return All<T>().Where(whereExpression).OrderBy(orderExpression);
        }

        public IQueryable<T> OrderBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> orderExpression)
        {
            return All<T>().OrderBy(orderExpression);
        }

        /// <summary>
        /// Finds an item using a passed-in expression lambda
        /// </summary>
        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All<T>().SingleOrDefault(expression);
        }

        /// <summary>
        /// Saves an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void Save<T>(T item)
        {
            db.Store(item);
            db.Commit();
        }

        /// <summary>
        /// Deletes an item from the database
        /// </summary>
        /// <param name="item"></param>
        public void Delete<T>(T item)
        {
            db.Delete(item);
            db.Commit();
        }

        /// <summary>
        /// Deletes subset of objects
        /// </summary>
        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            var items = All<T>().Where(expression).ToList();
            items.ForEach(x => db.Delete(x));
            db.Commit();
        }

        /// <summary>
        /// Deletes all T objects
        /// </summary>
        public void DeleteAll<T>()
        {
            var items = All<T>().ToList();
            items.ForEach(x => db.Delete(x));
            db.Commit();
        }

        /// <summary>
        /// Commits changes to disk
        /// </summary>
        public void CommitChanges()
        {
            //commit the changes
            db.Commit();

        }

        void IDisposable.Dispose()
        {
            db.Close();
            db.Dispose();
        }

    }
}
