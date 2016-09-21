using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LacysMobile.Data.Interfaces;
using LacysMobile.Models;
using System.Data;

namespace LacysMobile.Data
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _DbSet { get; set; }
        protected DbContext _Context { get; set; }

        public BaseRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An Instance of DbContext is required.", "context");
            }

            this._Context = context;
            this._DbSet = this._Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this._DbSet;
        }

        public T GetById(int id)
        {
            return this._DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this._Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this._DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this._Context.Entry(entity);
            var pkey = _DbSet.Create().GetType().GetProperty("Id").GetValue(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = _Context.Set<T>();
                T attachedEntity = set.Find(pkey);
                if (attachedEntity != null)
                {
                    var attachedEntry = _Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

        }

        public void UpdateWithId(T entity, int id)
        {
            DbEntityEntry entry = this._Context.Entry(entity);
            var pkey = id;

            if (entry.State == EntityState.Detached)
            {
                var set = _Context.Set<T>();
                T attachedEntity = set.Find(pkey);
                if (attachedEntity != null)
                {
                    var attachedEntry = _Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this._Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this._DbSet.Attach(entity);
                this._DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Detach(T entity)
        {
            DbEntityEntry entry = this._Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
