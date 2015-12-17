using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;

namespace 艾维斯特
{
    public partial class Product : System.Web.UI.Page
    {
        public string guide = "";
        public string difInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bindInfo();
        }
        public void bindInfo()
        {
            guide += "<div id=\"guide\">";
            guide += "<h3 >产品中心</h3>";
            guide += "<span>";
            guide += "<a href=\"/index.aspx\">首页</a> >";
            guide += "<a href=\"\">产品中心</a>";
            guide += "</span>";
            guide += "</div>";   
            //点击产品二级栏目列表时
            if (Request.QueryString["pid"] != null)
            {
                DataSet ds = dbHelper.getDS("select * from tb_product where pid=" + Convert.ToInt32(Request.QueryString["pid"]) + " order by sort");
                difInfo += "<div id=\"difBorder\" style=\"margin:0;padding:0;\">";
                difInfo += "<div id=\"difContent\" >";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    difInfo += "<ul id=\"productUL\">";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {                        
                        difInfo += "<li>";
                        difInfo += "<a href=\"#\">";
                        difInfo += "<div>";
                        difInfo += "<img src=\""+dr["picpath"]+"\" style=\"border: 13px solid rgb(234, 234, 234);\"><p>"+dr["name"]+"</p>";
                        difInfo += "</div>";
                        difInfo += "</a>";
                        difInfo += "<p>";
                        difInfo += "<a href=\"#\"><img src=\"images/p_btn.gif\"></a>";                         
                        difInfo += "</p>";
                        difInfo += "</li>";                                                      
                    //                       <ul id="productUL">
                    //    <li>
                    //        <div>
                    //            <img src="images/carousel1.jpg" style="border: 13px solid rgb(234, 234, 234);"><p>全自动酶标分析仪AMR-100</p>
                    //        </div>
                    //        <p>
                    //            <a href="#">
                    //                <img src="images/p_btn.gif"></a>
                    //        </p>
                    //    </li>
                    //</ul>                                                
                    }
                    difInfo += "</ul>";
                }
                else
                {                    
                    difInfo += "没有内容";                                
                }          
                //搜索功能和点击导航栏进入产品页面      
                if (Request.QueryString["id"] != null)
                {
                    //搜索框功能
                    if (Request.QueryString["txt"] != null)
                    {
                        DataSet ds3 = dbHelper.getDS("select * from tb_product where name like '%" + Request.QueryString["txt"].ToString().Trim() + "%'");
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            difInfo = "";
                            difInfo += "<div id=\"difBorder\" style=\"margin:0;padding:0;\">";
                            difInfo += "<div id=\"difContent\" >";
                            difInfo += "<ul id=\"productUL\">";
                            foreach (DataRow dr in ds3.Tables[0].Rows)
                            {
                                difInfo += "<li>";
                                difInfo += "<a href=\"#\">";
                                difInfo += "<div>";
                                difInfo += "<img src=\"" + dr["picpath"] + "\" style=\"border: 13px solid rgb(234, 234, 234);\"><p>" + dr["name"] + "</p>";
                                difInfo += "</div>";
                                difInfo += "</a>";
                                difInfo += "<p>";
                                difInfo += "<a href=\"#\"><img src=\"images/p_btn.gif\"></a>";
                                difInfo += "</p>";
                                difInfo += "</li>";
                                //difInfo += "<ul>";
                                //difInfo += "<li>";
                                //difInfo += "<div><img src=" + dr["picpath"].ToString() + " /><p>" + dr["name"].ToString() + "</p></div>";
                                //difInfo += "<p><a href=\"#\"><img src=\"images/p_btn.gif\" /></a></p>";
                                //difInfo += "</li>";
                                //difInfo += "</ul>";
                            }
                            difInfo += "<ul id=\"productUL\">";
                        }
                    }
                    else
                    {
                        //点击导航的产品中心
                        DataSet ds2 = dbHelper.getDS("select * from tb_product order by sort ");
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            difInfo = "";
                            difInfo += "<div id=\"difBorder\" style=\"margin:0;padding:0;\">";
                            difInfo += "<div id=\"difContent\" >";
                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                difInfo += "<ul id=\"productUL\">";
                                difInfo += "<li>";
                                difInfo += "<div><img src=" + dr["picpath"].ToString() + " /><p >" + dr["name"].ToString() + "</p></div>";
                                difInfo += "<p><a href=\"#\"><img src=\"images/p_btn.gif\" /></a></p>";
                                difInfo += "</li>";
                                difInfo += "</ul>";
                            }
                        }
                    }
                }
                difInfo += "</div>";
                difInfo += "</div>";                
            }
        }
    }
}