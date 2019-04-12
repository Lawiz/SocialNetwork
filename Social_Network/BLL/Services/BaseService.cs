using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IBaseService<T>
    {

    }


    public class BaseService<T> : IBaseService<T> where T : class
    {
        private DbContext DbContext { get; set; }
        public BaseService(DbContext context)
        {
            DbContext = context;
            this.Repository = context.Set<T>();
        }

        protected DbSet<T> Repository;

        public virtual List<T> Get(Expression<Func<T, bool>> expression)
        {
            return Repository.Where(expression).ToList();
        }


    }
}
