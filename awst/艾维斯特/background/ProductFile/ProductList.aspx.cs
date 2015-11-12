using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace 艾维斯特.background.ProductFile
{
    public partial class ProductList : System.Web.UI.Page
    {
        public string ProductColumnInfomation = string.Empty;
        StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                sb.Append("<table id=\"tableStyle\">");
                sb.Append("<tr>");
                sb.Append("<td>编号</td><td>栏目</td><td>父栏目</td><td>编号</td><td>是否隐藏</td><td>操作</td>");
                sb.Append("</tr>");
                bindInfo(0);
                sb.Append("</table>");
                ProductColumnInfomation = sb.ToString();
            }
        }
        public void bindInfo(int id)
        {            
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid="+id);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td>"+ds.Tables[0].Rows[i][0]+"</td>");
                if (id == 0)
                {
                    sb.Append("<td class=\"add\" style=\"text-align:left;text-indent:8px;background:url(../images/add.jpg) no-repeat left;\">" + ds.Tables[0].Rows[i][1] + "</td>");
                }
                else if(id>0)
                {
                    sb.Append("<td class=\"reduce " + id + "\" style=\"text-align:left;text-indent:30px;background:url(../images/reduce.jpg) no-repeat 22px 8px;\">" + ds.Tables[0].Rows[i][1] + "</td>");
                }
                if (id > 0)
                {
                    sb.Append("<td><a href=\"#\">显示子栏目</a> </td>");
                }
                else
                {
                    sb.Append("<td></td>");
                }                
                sb.Append("<td>" + ds.Tables[0].Rows[i][3] + "</td>");
                string hide=string.Empty;
                if (Convert.ToInt32(ds.Tables[0].Rows[i][4]) == 0)
                {
                     hide= "否";
                }
                else {
                    hide = "是";
                }
                sb.Append("<td>" +hide+ "</td>");
                sb.Append("<td><a href=\"#\" id=\"updateBtn\" onserverclick=\"updateBtn_ServerClick\" >修改</a>&nbsp;<a href=\"#\">删除</a></td>");
                sb.Append("</tr>");                
                bindInfo(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
            }            
        }

        protected void updateBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Write("asdf");
        }

        protected void aaa_ServerClick(object sender, EventArgs e)
        {
            Response.Write("bbbb");
        }


    }
}