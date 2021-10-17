using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.DataAccess.Core.Interfaces;

namespace TMS.DataAccess.Core.Concretes
{
   public class Repository: IRepository
    {
        DataContext _context;
        public Repository(IDbFactory dbFactory)
        {
            _context = dbFactory.GetDataContext;
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _context.Set<T>().Where<T>(filter).AsQueryable() : _context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual void Create<T>(T TObject) where T : class
        {
            var newEntry = _context.Set<T>().Add(TObject);
        }

        public virtual void Delete<T>(T TObject) where T : class
        {
            _context.Set<T>().Remove(TObject);
        }

        public virtual void Update<T>(T TObject) where T : class
        {
            try
            {
                var entry = _context.Entry(TObject);
                _context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach (var obj in objects)
                _context.Set<T>().Remove(obj);
        }
        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Count<T>(predicate) > 0;
        }
        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }
        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            object p = _context.Database.ExecuteSqlRaw(procedureCommand, sqlParams);
        }
    }
}
