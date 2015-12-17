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
    public partial class ProductList : dataHelper.basePage
    {
        public string ProductColumnInfomation = string.Empty;
        StringBuilder sb = new StringBuilder();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {                
        //        sb.Append("<table id=\"tableStyle\">");
        //        sb.Append("<tr>");
        //        sb.Append("<td>编号</td><td>栏目</td><td>父栏目</td><td>编号</td><td>是否隐藏</td><td>操作</td>");
        //        sb.Append("</tr>");
        //        bindInfo(0);
        //        sb.Append("</table>");
        //        ProductColumnInfomation = sb.ToString();
        //        if (Request.QueryString["id"]!= null)
        //        {
        //            //判断是否是一级栏目
        //            if (Request.QueryString["pid"] == "0")
        //            {
        //                //一级栏目
        //                dataHelper.dbHelper.cmdExecute("delete tb_product where pid in(" + getTypeID() + ")"); //删除产品信息
        //                dataHelper.dbHelper.cmdExecute("delete tb_productColumn where pid=" + Convert.ToInt32(Request.QueryString["id"]));//删除二级
        //                dataHelper.dbHelper.cmdExecute("delete tb_productColumn where id=" + Convert.ToInt32(Request.QueryString["id"]));//删除一级                                                
        //                dataHelper.dbHelper.pageMsg(this.Page, "删除成功", "ProductType.aspx");
        //            }
        //            else { 
        //                //二级栏目
        //                dataHelper.dbHelper.cmdExecute("delete tb_product where pid in(" + Convert.ToInt32(Request.QueryString["id"]) + ")"); //删除产品信息
        //                dataHelper.dbHelper.cmdExecute("delete tb_productColumn where id=" + Convert.ToInt32(Request.QueryString["id"]));                        
        //                dataHelper.dbHelper.pageMsg(this.Page, "删除成功", "ProductType.aspx");
        //            }
                    
        //        }
        //    }
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                sb.Append("<table id=\"tableStyle\">");
                sb.Append("<tr>");
                sb.Append("<td>编号</td><td>栏目</td><td>父栏目</td><td>编号</td><td>是否隐藏</td><td>操作</td>");
                sb.Append("</tr>");
                bindInfo(0);
                sb.Append("</table>");
                ProductColumnInfomation = sb.ToString();
                if (Request.QueryString["id"] != null)
                {
                    //判断是否是一级栏目
                    if (Request.QueryString["pid"] == "0")
                    {
                        //一级栏目
                        dataHelper.dbHelper.cmdExecute("delete tb_product where pid in(" + getTypeID() + ")"); //删除产品信息
                        dataHelper.dbHelper.cmdExecute("delete tb_productColumn where pid=" + Convert.ToInt32(Request.QueryString["id"]));//删除二级
                        dataHelper.dbHelper.cmdExecute("delete tb_productColumn where id=" + Convert.ToInt32(Request.QueryString["id"]));//删除一级                                                
                        dataHelper.dbHelper.pageMsg(this.Page, "删除成功", "ProductType.aspx");
                    }
                    else
                    {
                        //二级栏目
                        dataHelper.dbHelper.cmdExecute("delete tb_product where pid in(" + Convert.ToInt32(Request.QueryString["id"]) + ")"); //删除产品信息
                        dataHelper.dbHelper.cmdExecute("delete tb_productColumn where id=" + Convert.ToInt32(Request.QueryString["id"]));
                        dataHelper.dbHelper.pageMsg(this.Page, "删除成功", "ProductType.aspx");
                    }

                }
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
                    //一级栏目
                    sb.Append("<td class=\"add\" style=\"text-align:left;text-indent:8px;background:url(../images/add.jpg) no-repeat left;\">" + ds.Tables[0].Rows[i][1] + "</td>");
                }
                else if(id>0)
                {
                    //二级栏目
                    sb.Append("<td class=\"reduce " + id + "\" style=\"text-align:left;text-indent:30px;background:url(../images/reduce.jpg) no-repeat 22px 8px;\">" + ds.Tables[0].Rows[i][1] + "</td>");
                }
                if (id > 0)
                {
                    sb.Append("<td><a href=\"Product.aspx?id="+ds.Tables[0].Rows[i][0]+"&pid="+ds.Tables[0].Rows[0]["pid"]+"\">显示子栏目</a> </td>");
                }
                else
                {
                    sb.Append("<td></td>");
                }                
                sb.Append("<td>" + ds.Tables[0].Rows[i][3] + "</td>");
                string hide=string.Empty;
                //是否隐藏
                if (Convert.ToInt32(ds.Tables[0].Rows[i][4]) == 0)
                {
                     hide= "否";
                }
                else {
                    hide = "是";
                }
                sb.Append("<td>" +hide+ "</td>");
                sb.Append("<td><a href=\"ProductTypeManager.aspx?id="+Convert.ToInt32(ds.Tables[0].Rows[i][0])+"\"  id=\"updateBtn\">修改</a>&nbsp;<a onclick='return confirm(\"是否确定删除\")' href=\"ProductType.aspx?id=" + Convert.ToInt32(ds.Tables[0].Rows[i][0]) + "&pid="+Convert.ToInt32(ds.Tables[0].Rows[i]["pid"])+"\">删除</a></td>");
                sb.Append("</tr>");                
                bindInfo(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
            }            
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductTypeManager.aspx");
        }
        /// <summary>
        /// 删除一级栏目时，获取二级栏目的id
        /// </summary>
        /// <returns></returns>
        public string getTypeID()
        {
            string nums = "0";
            DataSet ds = dataHelper.dbHelper.getDS("select id from tb_productColumn where pid="+Convert.ToInt32(Request.QueryString["id"]));
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nums += dr[0].ToString();
                }
                nums = nums.TrimEnd();
            }
            return nums;            
        }
    }
}