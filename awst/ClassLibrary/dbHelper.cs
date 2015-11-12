using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace ClassLibrary
{
    public class dbHelper
    {

        
        /// <summary>
        /// 获取SqlConnection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection getConn()
        {
            return new SqlConnection("data source=AEOD3-505040938;initial catalog=AAA;integrated security=sspi");
        }
        /// <summary>
        /// 通过查询字符串获取 DataSet
        /// </summary>
        /// <returns></returns>
        public static DataSet getDS(string sqlText)
        {
            SqlConnection conn = getConn();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlText,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;                        
        }
        
        //public void SqlCommand cmdExecute(string sqlText)
        //{
        //    SqlConnection conn = getConn();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = sqlText;
        //    cmd.Connection = conn;
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //}
    }
}
