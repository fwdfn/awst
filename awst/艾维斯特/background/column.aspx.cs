using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background
{
    public partial class column : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();                
            }
        }
        /// <summary>
        /// 绑定栏目信息
        /// </summary>
        protected void bindInfo()
        {            
            int id = Convert.ToInt32(Request.QueryString["id"]);    
            string sqlText = "select * from tb_menu where pid="+id+" order by sort";
            DataSet ds = dataHelper.dbHelper.getDS(sqlText);                                                                         
            gv.DataSource = ds;
            gv.DataBind();
        }

        /// <summary>
        /// 重新排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void sort_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            GridViewRow gvr = tb.Parent.Parent as GridViewRow;
            int id = Convert.ToInt32(gvr.Cells[0].Text);            
            SqlParameter[] paras = { 
                                   new SqlParameter("@sort", Convert.ToInt32(tb.Text)),
                                   new SqlParameter("@id",id)                                     
                                   };
            dataHelper.dbHelper.cmdExecute("update tb_menu set sort=@sort where id=@id",paras);
            dataHelper.dbHelper.pageMsg(this.Page,"修改成功","");            
        }

        /// <summary>
        /// 给gv的行添加鼠标移上去的样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.background;this.style.background='#e6f0fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.background=c");
           // e.Row.Attributes.Add("onmouseover", "c=this.style.background;this.style.background=#ccc");
           // e.Row.Attributes.Add("onmouseout", "this.style.background=c;");
        }
        /// <summary>
        /// 点击添加栏目按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("EditColumn.aspx?pid="+id);
        }

        /// <summary>
        /// linkButton删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkb_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            dataHelper.dbHelper.cmdExecute("delete tb_menu where id="+id);

            //id2为父栏目id
            int id2 = Convert.ToInt32(Request.QueryString["id"]);            
            dataHelper.dbHelper.pageMsg(this.Page, "删除成功", "column.aspx?id="+id2);            
        }
    }
}