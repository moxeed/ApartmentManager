using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public static class Extensions
    {
        public static T Extract<T>(this SqlDataReader datareader, string columnName, Func<T> defaultValueBuilder=null)
        {
            T result = default;
            try
            {
                if (datareader[columnName] != DBNull.Value)
                {
                    result = (T)datareader[columnName];
                }
                else if (defaultValueBuilder != null)
                {
                    result = defaultValueBuilder();
                }
            }
            catch
            {
                if (defaultValueBuilder != null)
                {
                    result = defaultValueBuilder();
                }
            }
            return result;
        }
    }
}
