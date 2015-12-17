using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;


namespace 艾维斯特.background.dataHelper
{
    public class dbHelper
    {
        public static SqlConnection getConn()
        {
           //return new SqlConnection("data source=AEOD3-505040938;initial catalog=AAA;integrated security=sspi");
           //获取连接字符串 
           string connTxt= ConfigurationManager.ConnectionStrings["connString"].ToString();            
           return new SqlConnection(connTxt);            
        }
        
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
        /// <summary>
        /// 为什么返回值为void时sqlCommand打不出来
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static int cmdExecute(string sqlText,params SqlParameter[] paras)
        {
            SqlConnection conn = getConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            return cmd.ExecuteNonQuery();                        
        }
        //public static SqlDataReader getDataReader(string sqlText)
        //{
        //    SqlConnection conn = getConn();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(sqlText, conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
           
        //    while (dr.Read())
        //    { 
                 
        //    }
        //    conn.Close();
            
        //}
        /// <summary>
        /// 输出信息并跳转页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="location"></param>
        public static void pageMsg(Page page,string msg,params string[] location)
        {
           page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + msg + "');location.href='" + location[0] + "'</script>");            
        }
        /// <summary>
        /// 输出信息，但不跳转页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void pageMsg2(Page page,string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + msg + "');</script>");
        }
        
    }
}