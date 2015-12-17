using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;

namespace 艾维斯特.ucManage
{
    public partial class Left : System.Web.UI.UserControl
    {
        public string getMenu = "";
        public string getCompanyInfo = "";
        public string img = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bindMenu();
        }
        public void bindMenu()
        { 
           //<%--<ul>
           //      <li><a href="#">公司荣誉</a></li>
           //      <li><a href="#">公司荣誉</a></li>
           //      <li><a href="#">公司荣誉</a></li>
           //  </ul>  --%>
            int num = Convert.ToInt32(Request.QueryString["id"]);
            int pid = Convert.ToInt32(Request.QueryString["pid"]);
            
            //首页 详细新闻Left的样式
            if (Request.QueryString["type"] != null)
            {
                DataSet ds4 = dbHelper.getDS("select * from tb_menu where isHide=0 and pid=1");
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    getMenu += "<ul>";
                    for (int i = 1; i <= ds4.Tables[0].Rows.Count; i++)
                    {
                        getMenu += "<li><a href=\"" + ds4.Tables[0].Rows[i - 1]["linkUrl"] + "&sort=" + i + "\">" + ds4.Tables[0].Rows[i - 1]["title"].ToString() + "</a></li>";
                    }
                    getMenu += "</ul>";
                }
            }
            switch (num){
                    //关于我们
                case 1:
                case 2:
                case 3:
                case 4:
                    img="<img src=\"../images/about_25.jpg\" />";
                    break;
                    //新闻中心
                case 5:
                case 6:
                case 7:
                case 8:
                    img = "<img src=\"../images/news_01.jpg\" />";                    
                    break;
                    //产品中心
                case 9:
                    img = "<img src=\"../images/product_05.jpg\" />";
                    break;
                    //其余的都显示为关于我们
                default:
                    img="<img src=\"../images/about_25.jpg\" />";
                    num = 1;   //将num设置为1用来在别的栏目显示关于我们的子栏目信息
                    break;
            }
            //点击新闻列表进入新闻内容页时
            if (Request.QueryString["newspid"] != null)
            {
                img = "<img src=\"../images/news_01.jpg\" />";
                DataSet dsn = dbHelper.getDS("select * from tb_menu where id=" + Convert.ToInt32(Request.QueryString["newspid"]));
                num = Convert.ToInt32(dsn.Tables[0].Rows[0]["id"]);
                pid = Convert.ToInt32(dsn.Tables[0].Rows[0]["pid"]);                
            }
            DataSet ds;            
            if (pid == 0)
            {
                //首页栏目
                 ds = dbHelper.getDS("select * from tb_menu where isHide=0 and pid=" + num);                 
            }
            else
            {
                //点击子栏目                
                 ds = dbHelper.getDS("select * from tb_menu where isHide=0 and pid=" + pid);                 
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                getMenu += "<ul>";
                for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                {
                    //关于我们左边的导航
                    if (ds.Tables[0].Rows[i - 1]["linkUrl"].ToString().Substring(13) == "id=" + num + "&pid=" + pid)
                    {
                        //点击后左边标题高亮显示
                        getMenu += "<li><a style=\"font-weight:bold;color:#006087\" href=\"" + ds.Tables[0].Rows[i - 1]["linkUrl"] + "\">" + ds.Tables[0].Rows[i - 1]["title"].ToString() + "</a></li>";                        
                    }
                    //新闻中心左边的导航
                    else if (ds.Tables[0].Rows[i - 1]["linkUrl"].ToString().Substring(10) == "id=" +num + "&pid=" + pid)
                    {
                        getMenu += "<li><a style=\"font-weight:bold;color:#006087\" href=\"" + ds.Tables[0].Rows[i - 1]["linkUrl"] + "\">" + ds.Tables[0].Rows[i - 1]["title"].ToString() + "</a></li>";                        
                    }
                    else
                    {
                        getMenu += "<li><a href=\"" + ds.Tables[0].Rows[i - 1]["linkUrl"] + "\">" + ds.Tables[0].Rows[i - 1]["title"].ToString() + "</a></li>";                        
                    }
                }
                getMenu += "</ul>";
            }
            DataSet ds2 = dbHelper.getDS("select * from tb_companyInfo");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                getCompanyInfo += "<ul>";
                getCompanyInfo += "<li>"+ds2.Tables[0].Rows[0]["name"].ToString()+"</li>";
                getCompanyInfo += "<li>电话："+ds2.Tables[0].Rows[0]["phone"].ToString()+"</li>";
                getCompanyInfo += "<li>传真："+ds2.Tables[0].Rows[0]["fax"].ToString()+"</li>";
                getCompanyInfo += "<li>手机："+ds2.Tables[0].Rows[0]["cellphone"].ToString()+"</li>";
                getCompanyInfo += "<li>公司邮箱："+ds2.Tables[0].Rows[0]["email"].ToString()+"</li>";
                getCompanyInfo += "<li>网址："+ds2.Tables[0].Rows[0]["website"].ToString()+"</li>";
                getCompanyInfo += "</ul>";
            }            
        }
    }
}