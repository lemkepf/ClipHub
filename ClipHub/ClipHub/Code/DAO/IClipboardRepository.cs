using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClipHub.Code.Models;

namespace ClipHub.Code.DAO
{
    public interface IClipboardRepository
    {

        List<ClipboardEntry> getAllClipboardentryList();
        List<ClipboardEntry> getAllClipboardentryListFilter(String filterText);
        //System.Linq.IQueryable<T> WhereOrderBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression, System.Linq.Expressions.Expression<Func<T, bool>> orderExpression);
        void Save(ClipboardEntry item);
        void Insert(ClipboardEntry item);
        void Delete(ClipboardEntry item);


    }
}
