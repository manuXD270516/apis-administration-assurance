using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static activate_assurance.Utils.UtilsModel;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        internal DbSet<T> dbSet; // optional

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void add(T entity)
        {
                
            dbSet.Add(entity);
            //dbSet.FindAsync()
        }

        public async Task<T> addAsync(T entity)
        {
            EntityEntry<T> entityCreated =  await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityCreated.Entity;
        }

        public async Task<int> countAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }

        public T get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> getAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            // include properties will be comma separated
            includeProperties.ToList()
                .ForEach(prop => query = query.Include(prop));

            // aplicate filter
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
           
           
            // aplicate order by
            if (!isNull(orderBy))
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public async Task<List<T>> getAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            // include properties will be comma separated
            includeProperties.ToList()
                .ForEach(prop => query = query.Include(prop));

            // aplicate filter
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            

            // aplicate order by
            if (!isNull(orderBy))
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public T getFirstOrDefault(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            // include properties will be comma separated
            // observation: include properties : ToLower()
            // include properties will be comma separated
            includeProperties.ToList()
                .ForEach(prop => query = query.Include(prop));


            // aplicate filter
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            
            return query.FirstOrDefault();
        }

        public async Task<T> getFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            // include properties will be comma separated
            // observation: include properties : ToLower()
            // include properties will be comma separated
            includeProperties.ToList()
                .ForEach(prop => query = query.Include(prop));

            // aplicate filter
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            

            return await query.FirstOrDefaultAsync();
        }

        public void remove(int id)
        {
            T entityRemove = dbSet.Find(id);
            remove(entityRemove);
        }

        public void remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<T> removeAsync(T entity)
        {
            return null;
            //dbSet.
        }

        public async Task<T> updateAsync(int id, T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
