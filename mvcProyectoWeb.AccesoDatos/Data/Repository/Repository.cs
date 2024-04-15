using Microsoft.EntityFrameworkCore;
using mvcProyectoWeb.AccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace mvcProyectoWeb.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }



        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>>? ordenBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            
            if (filter != null) 
            {
            query = query.Where(filter);
            }
            if (includeProperties != null )
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },

                    StringSplitOptions.RemoveEmptyEntries
                    )) 
                {
                    query = query.Include(includeProperty);
                }



            }
            if (ordenBy != null) 
            {
                return ordenBy(query).ToList();
            
            }
            return query.ToList();


        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null) 
            {
            query = query.Where(filter);
            }
            if (includeProperties != null) 
            {

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();


        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);



        }

        public void Remove(T entity)
        {
            T entityToRemove = (entity);

        }
    }
}
