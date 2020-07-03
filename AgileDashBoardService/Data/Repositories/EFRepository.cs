
using AgileDashBoardService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.Repositories
{
    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public EFRepository() { }
        public EFRepository(DbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adds a new entity to the existing Entitites 
        /// </summary>
        /// <param name="entity">entity to be added</param>
        public virtual void Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Add a new entity to the existing entities Asynchronously
        /// </summary>
        /// <param name="entity">entity to be added</param>
        public virtual async void AddAsync(TEntity entity)
        {
            await this._context.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// Adds a range of entities to the existing list 
        /// </summary>
        /// <param name="entities">List of entites to be added</param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            this._context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Adds a range of entities to the existing list Asynchronously
        /// </summary>
        /// <param name="entities">List of entities to be added</param>
        public virtual async void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this._context.Set<TEntity>().AddRangeAsync(entities);
        }

        /// <summary>
        /// Finds an entity and returns it Based on the Predicate conditions
        /// </summary>
        /// <param name="predicate">The condiftion to be applied on the entities</param>
        /// <returns>TEntity</returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate).AsQueryable().SingleOrDefault();
        }

        /// <summary>
        /// Returns an IEnumerable list of entitites based on the Predicate conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable<TEntity></returns>
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().AsQueryable().Where(predicate).ToList();
        }


        /// <summary>
        /// Finds an entity based on the key supplies
        /// </summary>
        /// <typeparam name="KeyType">Primary key type of the entity</typeparam>
        /// <param name="id">Primary key of the table</param>
        /// <returns>Specific entity</returns>
        public virtual TEntity FindByKey<KeyType>(KeyType id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Finds an entity based on the key supplies Asychronously
        /// </summary>
        /// <typeparam name="KeyType">Primary key type of the entity</typeparam>
        /// <param name="id">Primary key of the table</param>
        /// <returns>Specific entity</returns>
        public virtual async Task<TEntity> FindByKeyAsync<KeyType>(KeyType id)
        {
            return await this._context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Find all the entities
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual IEnumerable<TEntity> FindAll()
        {
            return this._context.Set<TEntity>().ToList();
        }


        /// <summary>
        /// Removes an entity from the entity list
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        public virtual void Remove(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Removes a range of  entities from the entity list
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        public virtual void RemoveRange(IEnumerable<TEntity> entites)
        {
            this._context.Set<TEntity>().RemoveRange(entites);
        }
    }
}

