﻿using ControleEstoque.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data
{

    // Existe o TEntity declarado, assim como quem é, ou seja, nesse caso, TEntity é uma class
    public abstract class GlobalRepository<TEntity> : IGlobalRepository<TEntity> where TEntity : class
    {//essa classe ja faz todos os CRUD
        //ela é bem generica mas todas as entidase  entrara no lugar da TEntity e ja entra os metodos crud pronto
       
        
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GlobalRepository(DbContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<TEntity>();
        }

        //pega todos
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
            
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();

        }

        //pega por Id
        public virtual TEntity GetByID(object id)
        {
           var entity= dbSet.Find(id);
           return entity;
        }


        //inserir
        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            Save();
            return entity;            
        }

        //deletar
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }



        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        //atualizar
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //salvar
        public virtual void Save()
        {
            context.SaveChanges();
        }

    }
}
