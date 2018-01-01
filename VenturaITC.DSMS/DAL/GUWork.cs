using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using VenturaITC.DB.Repository.Class;

namespace VenturaITC.DSMS.DAL
{
 public class GUWork : IDisposable
    {
        private GRepository _repository;
        private dynamic _entity;
        public dynamic Entity
        {
            get { return _entity; }

            set { _entity = value; }
        }

        public void SetEntityType<T>()
        {
            _entity = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile().Invoke();
        }

        public GUWork(EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms)
        {
            _repository = new GRepository(EntityDBUtils.GetContext(dbName));
        }

        public void Save(bool submit = true)
        {
            try
            {
                _repository.Add(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(bool submit = true)
        {
            try
            {
                _repository.Edit(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(bool submit = true)
        {
            try
            {
                _repository.Remove(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        public void DeleteBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                _repository.RemoveBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        public static void DeleteBy<T>(Expression<Func<T, bool>> predicate, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms) where T : class
        {
            try
            {
                new Repository<T>(EntityDBUtils.GetContext(dbName)).RemoveBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all data from DB
        /// </summary>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public static List<T> GetAll<T>(EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbName)).GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all data from DB
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : class
        {
            try
            {
                return _repository.GetAll<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public static T FindByKey<T>(long key, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbName)).FindByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public T FindByKey<T>(long key) where T : class
        {
            try
            {
                return _repository.FindByKey<T>(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns></returns>
        public List<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return _repository.FindBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public static List<T> FindBy<T>(Expression<Func<T, bool>> predicate, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbName)).FindBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _repository.Dispose();
            Entity = null;
        }
    }
}