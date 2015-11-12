using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using 艾维斯特.background.dataHelper;
using System.Data;
using System.Data.SqlClient;



namespace 艾维斯特.background
{
    public partial class index1 : System.Web.UI.Page
    {
        public System.Text.StringBuilder sb = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string name = Request.QueryString["name"];
                //nameSpan.InnerText = name;
                //if (Session["UserName"] == null)
                //{
                //    string js = "<script>alert('请登陆');location.href='login.aspx';</script>";
                //    Response.Write(js);
                //}            
                bindInfo();
            }
        }
        protected void bindInfo()
        {
            #region
            //          <%--  <h4>广告位管理</h4>
                    //<div class="bg_index_left_son">
                    //   <div class="imgDiv"></div>                                                                            
                    //   <ul>
                    //       <li><a href="Advertising.aspx" target="iframe">广告位管理</a></li>
                    //       <li><a href="#"></a> 广告位管理</li>
                    //       <li>广告位管理</li>
                    //   </ul>  
                    //</div>
                    //<h4>系统管理</h4>
                    //<div class="bg_index_left_son">
                    //   <div class="imgDiv"></div>                                                                            
                    //   <ul>
                    //       <li>站内公告</li>
                    //       <li>首页图片切换</li>
                    //       <li>网站配置</li>
                    //       <li>管理员管理</li>
                    //   </ul>  
                    //</div>
                    //<h4>新闻中心</h4>
                    //<div class="bg_index_left_son">
                    //   <div class="imgDiv"></div>                                                                            
                    //   <ul>
                    //       <li><a href="column.aspx" target="iframe">类别管理</a></li>
                    //       <li><a href="News.aspx" target="iframe">信息管理</a></li>                           
                    //   </ul>  
                    // </div>
                    //<h4>员工之家</h4>
                    //<div class="bg_index_left_son">
                    //   <div class="imgDiv"></div>                                                                            
                    //   <ul>
                    //       <li>类别管理</li>
                    //       <li>信息管理</li>
                    //   </ul>  
            //</div>     --%>    
            #endregion
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_backgroundMenu where pid=0");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.Append("<h4>" + dr["title"] + "</h4>");
                DataSet ds2 = dbHelper.getDS("select * from tb_backgroundMenu where pid="+dr["id"]+"order by sort");
                if (ds2.Tables!= null)
                {                    
                    sb.Append("<div class=\"bg_index_left_son\">");
                    sb.Append("<div class=\"imgDiv\"></div>");
                    sb.Append("<ul>");
                    //sb.Append("<li><a href=\"column.aspx?id="+dr["id"]+"\" target=\"iframe\" >类别管理</a></li>");                    
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {                                            
                        sb.Append("<li><a href=\""+dr2["linkurl"]+"\" target=\"iframe\">"+dr2["title"]+"</a></li>");
                    }                   
                    sb.Append("</ul>");
                    sb.Append("</div>");
                }
            }
            #region
            //<h4>广告位管理</h4>
             //       <div class="bg_index_left_son">
             //          <div class="imgDiv"></div>                                                                            
             //          <ul>
             //              <li><a href="Advertising.aspx" target="iframe">广告位管理</a></li>
             //              <li><a href="#"></a> 广告位管理</li>
             //              <li>广告位管理</li>
             //          </ul>  
            //       </div>
            #endregion
        }
        protected void Unnamed1_Tick(object sender, EventArgs e)
        {
            currentTime.InnerText = DateTime.Now.ToString();
        }        
    }
}