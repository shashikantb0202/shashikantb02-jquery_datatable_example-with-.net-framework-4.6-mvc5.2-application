using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpAssignment.Helper
{
    public static class DatabaseHelper
    {
        public static Decimal? getDecimalForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToDecimal(row[key]);
            }
            return null;
        }
        //Get Int64 From Data Row
        public static Int64? getInt64ForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToInt64(row[key]);
            }
            return null;
        }
        //Get Int32 From Data Row
        public static Int32? getInt32ForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToInt32(row[key]);
            }
            return null;
        }
        //Get Int16 From Data Row
        public static Int16? getInt16ForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToInt16(row[key]);
            }
            return null;
        }
        //Get String From Data Row
        public static String getStringForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToString(row[key]);
            }
            return null;
        }
        //Get Boolean From Data Row
        public static Boolean? getBooleanForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToBoolean(row[key]);
            }
            return null;

        }
        //Get Float From Data Row
        public static Double? getDoubleForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToDouble(row[key]);
            }
            return null;
        }
        //Get Float From Data Row
        public static Char? getCharForKey(this DataRow row, String key)
        {

            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                return Convert.ToChar(row[key]);
            }
            return null;
        }
        //Get Date Time From Data Row
        public static DateTime? getDateTimeForKey(this DataRow row, String key)
        {
            if (row.Table.Columns.Contains(key) && row[key] != DBNull.Value)
            {
                try
                {
                    return Convert.ToDateTime(row[key]);
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }


        public static bool isValidField(DataRow row, string v)
        {
            if (row.Table.Columns.Contains(v))
            {
                return !row.IsNull(v);
            }
            else
            {
                return false;
            }
        }
    }
}