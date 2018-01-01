using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.DAL
{
    public class DBConnectionManager
    {
        public static string GetWindowArtistEntitiesConnection()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["dsmsEntities"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
