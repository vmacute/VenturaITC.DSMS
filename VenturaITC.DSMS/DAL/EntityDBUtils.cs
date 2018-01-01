using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.DAL
{
    public class EntityDBUtils
    {
        /// <summary>
        /// Databases enumerations.
        /// </summary>
        public enum DBName
        {
            dsms
        }

        /// <summary>
        /// Gets the Entity Framework Database context
        /// </summary>
        /// <param name="dbName">The database type</param>
        /// <returns>The Entity Framework Database context of the given database type.</returns>
        public static DbContext GetContext(DBName dbName = DBName.dsms, bool lazyLoadingEnabled = true, List<string> navigationProperties = null)
        {
            DbContext ctx;
            try
            {
                switch (dbName)
                {
                    case DBName.dsms
:

                        ctx = new dsmsEntities();
                        break;

                    default:
                        return new dsmsEntities();
                }

                ctx.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                if (lazyLoadingEnabled) ctx.Configuration.ProxyCreationEnabled = true;
                else
                {
                    if (navigationProperties != null)
                    {
                        foreach (string item in navigationProperties)
                        {
                            ctx.Entry(item);
                        }
                    }
                }

                return ctx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}