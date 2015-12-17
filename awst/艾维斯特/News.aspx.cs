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
    public partial class News : System.Web.UI.Page
    {
        public string guide = string.Empty;
        public string difInfo = string.Empty;
        public string NewsList = string.Empty;
        public int pageSort;
        protected void Page_Load(object sender, EventArgs e)
        {
            bindInfo();
        }
        public string getTime(DateTime time)
        {
            return time.ToLongDateString().ToString();
        }

        public void bindInfo()
        {
            #region
            string firstMenu = "";
            string secondMenu = "";
            //首页 > 新闻中心 > 行业新闻的功能
            if (Request.QueryString["type"] != null)
            {
                //firstMenu = "新闻中心";
                //DataSet ds = dbHelper.getDS("select * from tb_menu where id=" + Convert.ToInt32(Request.QueryString["pid"]));
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    secondMenu = ds.Tables[0].Rows[0]["title"].ToString();
                //    DataSet ds2 = dbHelper.getDS("select * from tb_newsInfo where id=" + Convert.ToInt32(Request.QueryString["id"]));
                //    difInfo += "<div id=\"difBorder\">";
                //    difInfo += "<div id=\"difContent\">";
                //    difInfo += ds2.Tables[0].Rows[0]["content"].ToString();
                //    difInfo += "</div>";
                //    difInfo += "</div>";
                //}
            }
            else
            {                
                if (Convert.ToInt32(Request.QueryString["pid"]) != 0)
                {
                    //二级栏目时
                    DataSet ds = dbHelper.getDS("select * from tb_menu where isHide=0 and id=" + Convert.ToInt32(Request.QueryString["pid"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        firstMenu = ds.Tables[0].Rows[0]["title"].ToString();
                        DataSet ds2 = dbHelper.getDS("select * from tb_menu where isHide=0 and id=" + Convert.ToInt32(Request.QueryString["id"]));
                        secondMenu = ds2.Tables[0].Rows[0]["title"].ToString();
                        difInfo += "<div id=\"difBorder\">";
                        difInfo += "<div id=\"difContent\">";
                        difInfo += ds2.Tables[0].Rows[0]["content"].ToString();
                        difInfo += "</div>";
                        difInfo += "</div>";
                        //DataSet ds3 = dbHelper.getDS("select * from tb_newsInfo where ishide=0 and pid=" + Convert.ToInt32(Request.QueryString["id"]));
                        //if (ds3.Tables[0].Rows.Count > 0)
                        //{
                        //    repNews.DataSource = ds3;
                        //    repNews.DataBind();
                        //}
                    }
                }
                else
                {
                    //一级栏目时
                    DataSet ds = dbHelper.getDS("select * from tb_menu where isHide=0 and id=" + Convert.ToInt32(Request.QueryString["id"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        firstMenu = ds.Tables[0].Rows[0]["title"].ToString();
                        difInfo += "<div id=\"difBorder\">";
                        difInfo += "<div id=\"difContent\" >";
                        difInfo += ds.Tables[0].Rows[0]["content"].ToString();
                        difInfo += "</div>";
                        difInfo += "</div>";
                        //DataSet ds2 = dbHelper.getDS("select * from tb_menu where isHide=0 and sort=1 and pid=" + Convert.ToInt32(Request.QueryString["id"]));
                        //if (ds2.Tables[0].Rows.Count > 0)
                        //{
                        //    DataSet ds3 = dbHelper.getDS("select * from tb_newsInfo where ishide=0 and pid=" + ds2.Tables[0].Rows[0]["id"]);
                        //    if (ds3.Tables[0].Rows.Count > 0)
                        //    {
                        //        repNews.DataSource = ds3;
                        //        repNews.DataBind();
                        //    }
                        //}
                    }
                }
            }
            #endregion
            #region
            guide += "<div id=\"guide\">";
            guide += "<h3 >" + firstMenu + "</h3>";
            guide += "<span>";
            guide += "<a href=\"/index.aspx\">首页</a> > ";
            //点击主栏目：新闻中心
            if (Convert.ToInt32(Request.QueryString["id"]) == 5)
            {
                secondMenu = "行业新闻";
                guide += "<a href=\"\">" + firstMenu + "</a> > ";
                guide += "<a href=\"\">" + secondMenu + "</a>";
            }
            else
            {
                if (Convert.ToInt32(Request.QueryString["pid"]) == 0)
                {
                    //点击其它主栏目时
                    guide += "<a href=\"\">" + firstMenu + "</a>";
                }
                else
                {
                    //点击二级栏目时
                    guide += "<a href=\"\">" + firstMenu + "</a> > ";
                    guide += "<a href=\"\">" + secondMenu + "</a>";
                }
            }
            guide += "</span>";
            guide += "</div>";   
            //显示详细新闻内容

            #endregion
            string abc = "";
            string pageInfo = "";
            //获取当前页
            if(Request.QueryString["pageSort"]!=null)
            {
                //点击新闻二级栏目跳转到新闻页时
                pageSort = Convert.ToInt32(Request.QueryString["pageSort"]);
            }
            else{
                //点击导航栏跳转到新闻页时
                pageSort = 1;
            }            
            double pages = 0; //总页面数
            int pageNewsCount = 1;//每页新闻信息数
            double newsCount=0;//新闻总数
            //绑定当前页新闻    
            DataSet dsNews;
            DataSet dsNewsCount;
            if (Convert.ToInt32(Request.QueryString["pid"]) == 0)
            {
                //点击导航栏进入新闻页时绑定所有新闻信息
                dsNews = dbHelper.getDS("select top " + pageNewsCount + " * from tb_newsInfo where id not in(select top " + pageNewsCount * (pageSort - 1) + " id from tb_newsInfo)");
                dsNewsCount = dbHelper.getDS("select * from tb_newsInfo");
            }
            else {
                //点击新闻二级栏目进入新闻页时
                dsNews = dbHelper.getDS("select top " + pageNewsCount + " * from tb_newsInfo where id not in(select top " + pageNewsCount * (pageSort - 1) + " id from tb_newsInfo where pid=" + Convert.ToInt32(Request.QueryString["id"]) + ") and pid=" + Convert.ToInt32(Request.QueryString["id"]));
                dsNewsCount = dbHelper.getDS("select * from tb_newsInfo where pid=" + Convert.ToInt32(Request.QueryString["id"]));
            
            }
            //获取新闻和页面总数，并显示1，2，3...页            
            if (dsNewsCount.Tables[0].Rows.Count > 0)
            {
                //获取新闻总数
                newsCount = dsNewsCount.Tables[0].Rows.Count;
                //获取总页数
                pages = Math.Ceiling(Convert.ToDouble(newsCount) / pageNewsCount);
                //绑定数字1，2，3，4
                for (int i = 0; i < pages; i++)
                {
                    if (i == (pageSort-1))
                    {
                        pageInfo += "<a style=\"color:red;margin-left:5px;\" href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"]) + "&pageSort=" + (i + 1) + "\" style=\"margin-left:5px;\">" + (i + 1) + "</a>";
                    }
                    else {
                        pageInfo += "<a href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"]) + "&pageSort=" + (i + 1) + "\" style=\"margin-left:5px;\">" + (i + 1) + "</a>";
                    }                    
                }
            }   
            if(Request.QueryString["content"]=="content")
            {
                if (Request.QueryString["newsid"] != null)
                {
                    DataSet ds = dbHelper.getDS("select * from tb_newsInfo where id=" + Convert.ToInt32(Request.QueryString["id"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        abc += ds.Tables[0].Rows[0]["content"].ToString();
                    }                   
                }                
            }            
            if (dsNews.Tables[0].Rows.Count > 0)
            {
                abc += "<ul>";
                //绑定新闻标题
                foreach (DataRow dr in dsNews.Tables[0].Rows)
                {
                    //id="+Convert.ToInt32(Request.QueryString["id"])+"&pid="+Convert.ToInt32(Request.QueryString["pid"])+
                    abc += "<li><a href=\"/NewsDetailed.aspx?content=content&newsid=" + dr["id"] + "&newspid="+dr["pid"]+"\">" + dr["title"] + "</a><span>" + getTime(Convert.ToDateTime(dr["cdate"])) + "</span></li>";
                }
                abc += "</ul>";
            }
            abc += "<p style=\"text-align:center;margin-top:10px;\">共" + pages + "页 页次:" + pageSort + "/" + pages + "页";
            abc += "<a href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"])+"\">首页</a>";
            if (pageSort >1)
            {
                abc += "<a href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"]) + "&pageSort=" + (pageSort - 1) + "\">上一页</a>";
            }
            else {
                abc += "<a disable=\"disable\">上一页</a>";
            }
            
            abc += pageInfo;
            if (pages > pageSort)
            {
                abc += "<a href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"]) + "&pageSort=" + (pageSort + 1) + "\">下一页</a>";
            }
            else
            {
                abc += "<a disable=\"disable\">下一页</a>";
            }

            abc += "<a href=\"/News.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&pid=" + Convert.ToInt32(Request.QueryString["pid"]) + "&pageSort=" + pages + "\">尾页</a></p>";
            //共3页 页次:1/3页 首页上一页 下一页尾页
            NewsList = abc.ToString();
        }
    }
}