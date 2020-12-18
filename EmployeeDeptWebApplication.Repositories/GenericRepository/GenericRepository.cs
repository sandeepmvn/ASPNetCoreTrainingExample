using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EmployeeDeptWebApplication.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeDeptWebApplication.Repositories
{

    public interface IGenericRepository<Entity>
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<Entity> GetAll();
        /// <summary>
        /// GetAllBy
        /// </summary>
        /// <param name="predicate">Search by</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<Entity> GetAllBy(Expression<Func<Entity, bool>> predicate);
        /// <summary>
        /// GetBy
        /// </summary>
        /// <param name="predicate">Search by</param>
        /// <returns>typeof(Entity)</returns>
        Entity GetBy(Expression<Func<Entity, bool>> predicate);
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        Entity Add(Entity entity);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(Entity entity);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Primary key id</param>
        void Delete(int id);
    }


    public class GenericRepository<Entity> : IGenericRepository<Entity>,IDisposable where Entity : class
    {
        #region ProtectedMembers
        protected readonly EmpDeptWebAppDBContext _context;
        protected readonly ILogger _logger;
        #endregion

        #region Constructor
        public GenericRepository(EmpDeptWebAppDBContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion


        #region Interface Members

        public virtual IEnumerable<Entity> GetAll()
        {
            try
            {
                return _context.Set<Entity>().ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(GetAll));
                throw;
            }
        }

        public virtual IEnumerable<Entity> GetAllBy(Expression<Func<Entity, bool>> predicate)
        {
            try
            {
                return _context.Set<Entity>().Where(predicate).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(GetAllBy));
                throw;
            }
        }

        public virtual Entity GetBy(Expression<Func<Entity, bool>> predicate)
        {
            try
            {
                return _context.Set<Entity>().FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetBy));
                throw;
            }
        }
        public virtual Entity Add(Entity entity)
        {
            try
            {
                _context.Set<Entity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Add));
                throw;
            }
        }

        public virtual void Update(Entity entity)
        {
            try
            {
                _context.Set<Entity>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Update));
                throw;
            }
        }
        public virtual void Delete(int id)
        {
            try
            {
                _context.Set<Entity>().Remove(_context.Set<Entity>().Find(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
