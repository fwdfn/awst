using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background.MessageBoardFile
{
    public partial class MessageBoardManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();
            }
        }
        //绑定留言信息
        public void bindInfo()
        {
            int id=Convert.ToInt32(Request.QueryString["id"]);
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_message where id=" + id);            
            if (ds.Tables[0].Rows.Count > 0)
            {
                msgTitle.Value = ds.Tables[0].Rows[0]["title"].ToString();
                username.Value = ds.Tables[0].Rows[0]["username"].ToString();
                companyName.Value = ds.Tables[0].Rows[0]["companyName"].ToString();
                phone.Value = ds.Tables[0].Rows[0]["phone"].ToString();
                email.Value = ds.Tables[0].Rows[0]["email"].ToString();
                message.Value = ds.Tables[0].Rows[0]["content"].ToString();
                txtContent.Value = ds.Tables[0].Rows[0]["replycontent"].ToString();
            }            
        }
        //回复留言
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            SqlParameter[] paras ={
                                  new SqlParameter("@id",+Convert.ToInt32(Request.QueryString["id"])),
                                  new SqlParameter("@replycontent",txtContent.Value)
                                 };
            string sqlText = "update tb_message set replycontent=@replycontent where id=@id";            
            dataHelper.dbHelper.cmdExecute(sqlText,paras);
            dataHelper.dbHelper.pageMsg(this, "回复成功", "MessageBoard.aspx");
        }
        //取消按钮
        protected void cancelBtn_ServerClick(object sender, EventArgs e)
        {
            dataHelper.dbHelper.pageMsg(this, "已取消", "MessageBoard.aspx");
        }
    }
}