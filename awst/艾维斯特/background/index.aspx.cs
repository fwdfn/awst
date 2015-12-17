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
    public partial class index1 : basePage
    {
        
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        string name = Request.QueryString["name"];
        //        //nameSpan.InnerText = name;
        //        if (Session["UserName"] == null)
        //        {
        //            string js = "<script>alert('请登陆');location.href='login.aspx';</script>";
        //            Response.Write(js);
        //        }            
        //        bindInfo();
        //    }
        //}
        public System.Text.StringBuilder sb = new System.Text.StringBuilder();
        public override void pageLoad()
        {
            bindInfo();
        }
        /// <summary>
        /// 绑定后台首页左边栏目
        /// </summary>
        protected void bindInfo()
        {
            #region
                    //<%--  <h4>广告位管理</h4>
                    //<div class="bg_index_left_son">
                    //   <div class="imgDiv"></div>                                                                            
                    //   <ul>
                    //       <li><a href="Advertising.aspx" target="iframe">广告位管理</a></li>
                    //       <li><a href="#"></a> 广告位管理</li>
                    //       <li>广告位管理</li>
                    //   </ul>  
                    //</div>
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
        }
        /// <summary>
        /// 显示现在时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed1_Tick(object sender, EventArgs e)
        {
            currentTime.InnerText = DateTime.Now.ToString();
        }        
    }
}