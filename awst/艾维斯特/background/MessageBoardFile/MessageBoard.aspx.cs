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
    public partial class MessageBoard : System.Web.UI.Page
    {
        public string bindMsgBoard = "";
        public System.Text.StringBuilder sb = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();
            }
        }
        //绑定信息
        protected void bindInfo()
        {
            string sqlText = "select * from tb_message";
            DataSet ds = dataHelper.dbHelper.getDS(sqlText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
            else {
                dataHelper.dbHelper.pageMsg2(this,"asdfasd");
            }
        }
        //行绑定事件
        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.background;this.style.background='#e6f0fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.background='#ffffff'");
        }
        //分页事件
        protected void gv_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            bindInfo();
        }

        //删除留言
        protected void lkb_Command(object sender, CommandEventArgs e)
        {
            int id =Convert.ToInt32(e.CommandArgument);
            string sqlText = "delete tb_message where id="+id;
            dataHelper.dbHelper.cmdExecute(sqlText);
            dataHelper.dbHelper.pageMsg(this, "删除成功", "MessageBoard.aspx");
        }
    }
}