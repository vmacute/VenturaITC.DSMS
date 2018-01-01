using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using VenturaITC.DB.Repository.Class;

namespace VenturaITC.DSMS.DAL
{
   public class UWork<T> : IDisposable where T : class
    {
        private T _entity;
        private List<T> _entityList;
        private Repository<T> _repository;

        public T Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public List<T> EntityList
        {
            get { return _entityList; }
        }

        public UWork(EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms
)
        {
            _repository = new Repository<T>(EntityDBUtils.GetContext(dbName));
            _entity = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile().Invoke();
            _entityList = new List<T>();
        }

        public void Save()
        {
            try
            {
                _repository.Add(_entity);
                _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveList()
        {
            try
            {
                foreach (T entity in _entityList)
                {
                    _repository.Add(entity);
                    _repository.Submit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                _repository.Edit(_entity);
                _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateList()
        {
            try
            {
                foreach (T entity in _entityList)
                {
                    _repository.Edit(entity);
                    _repository.Submit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                _repository.Remove(_entity);
                _repository.Submit();
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
        public void DeleteBy(Expression<Func<T, bool>> predicate)
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
        /// <param name="dbName">DB type</param>
        public static void DeleteBy(Expression<Func<T, bool>> predicate, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms)
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
        public static List<T> GetAll(EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms
)
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
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public static T FindByKey(Object key, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms)
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
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <param name="dbName">DB Type</param>
        /// <returns></returns>
        public static List<T> FindBy(Expression<Func<T, bool>> predicate, EntityDBUtils.DBName dbName = EntityDBUtils.DBName.dsms)
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
            _entity = null;
        }
    }
}