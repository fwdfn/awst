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
    public partial class AboutUS : System.Web.UI.Page
    {
        public string guide = string.Empty;//导航栏目
        public string difInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGuide();
            }            
        }
        public void bindGuide()
        {           
            string firstMenu = "";
            string secondMenu = "";
            string firstMenuLink = "";
            string secondMenuLink = "";
            if (Convert.ToInt32(Request.QueryString["pid"]) != 0)
            {
                //二级栏目时
                DataSet ds = dbHelper.getDS("select * from tb_menu where isHide=0 and id=" + Convert.ToInt32(Request.QueryString["pid"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    firstMenu = ds.Tables[0].Rows[0]["title"].ToString();                    
                    DataSet ds2=dbHelper.getDS("select * from tb_menu where isHide=0 and id="+Convert.ToInt32(Request.QueryString["id"]));
                    secondMenu = ds2.Tables[0].Rows[0]["title"].ToString();
                    difInfo += "<div id=\"difBorder\">";
                    difInfo += "<div id=\"difContent\">";
                    difInfo += ds2.Tables[0].Rows[0]["content"].ToString();
                    firstMenuLink = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                    secondMenuLink = ds2.Tables[0].Rows[0]["linkUrl"].ToString();
                    difInfo += "</div>";
                    difInfo += "</div>";
                }
            }
            else
            {
                //一级栏目时
                DataSet ds = dbHelper.getDS("select * from tb_menu where isHide=0 and id="+Convert.ToInt32(Request.QueryString["id"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    firstMenu = ds.Tables[0].Rows[0]["title"].ToString();
                    difInfo += "<div id=\"difBorder\">";
                    difInfo += "<div id=\"difContent\" >";
                    difInfo += ds.Tables[0].Rows[0]["content"].ToString();
                    firstMenuLink = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                    difInfo += "</div>";
                    difInfo += "</div>";                    
                }
            }
            guide += "<div id=\"guide\">";
            guide += "<h3 >" + firstMenu + "</h3>";
            guide += "<span>";
            guide += "<a href=\"/index.aspx\">首页</a> > ";
            //点击主栏目：关于我们
            if (Convert.ToInt32(Request.QueryString["id"]) == 1)
            {
                secondMenu = "公司荣誉";
                guide += "<a href=\""+firstMenuLink+"\">" + firstMenu + "</a> > ";
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
                    guide += "<a href=\"/"+firstMenuLink+"\">" + firstMenu + "</a> > ";
                    guide += "<a href=\"\">" + secondMenu + "</a>";                                        
                }                
            }            
            guide += "</span>";
            guide += "</div>";
            if (Convert.ToInt32(Request.QueryString["id"]) == 12)
            {
                //填写留言
                hideDiv.Style.Add("display", "block");
                difInfo = "";
            }
            else if(Convert.ToInt32(Request.QueryString["pid"])==10)
            {
                //在线报修
                if (Convert.ToInt32(Request.QueryString["id"]) == 15)
                {
                    hideDiv2.Style.Add("display", "block");
                    difInfo = "";
                }                                
            }
        }
        protected void publishBtn1_Click(object sender, EventArgs e)
        {
            string sqlText = "insert into tb_message(title,username,companyName,phone,email,content) values(@title,@username,@companyName,@phone,@email,@content)";
            SqlParameter[] paras ={
                                new SqlParameter("@title",guestbook1_ctlTitle.Value),
                                new SqlParameter("@username",guestbook1_ctlName.Value),
                                new SqlParameter("@companyName",guestbook1_ctlUnitName.Value),
                                new SqlParameter("@phone",guestbook1_ctlPhone.Value),
                                new SqlParameter("@email",guestbook1_ctlEmail.Value),
                                new SqlParameter("@content",guestbook1_ctlContent.Value)
                               };
            dbHelper.cmdExecute(sqlText, paras);
            dbHelper.pageMsg(this, "添加成功", "/AboutUS?id=12&pid=0");
        }
        //在线报修
        protected void publishBtn2_Click(object sender, EventArgs e)
        {
            
            SqlParameter[] paras ={
                                  new SqlParameter("@machine",guestbook1_ctlTitle2.Value),
                                  new SqlParameter("@description",guestbook1_ctldescription2.Value),
                                  new SqlParameter("@iswarranty",guestbook1_ctlwarranty1.Checked?1:0),//asdfasd
                                  new SqlParameter("@companyname",guestbook1_ctlcompanyName2.Value),
                                  new SqlParameter("@username",guestbook1_ctluserName2.Value),
                                  new SqlParameter("@phone",guestbook1_ctlphone2.Value),
                                  new SqlParameter("@email",guestbook1_ctlemail2.Value),
                                  new SqlParameter("@remark",guestbook1_ctlremarks2.Value),                                                                      
                                  new SqlParameter("@cdate",DateTime.Now)
                                 };                                
            string sqlText = "insert into tb_maintenance values(@machine,@description,@iswarranty,@companyname,@username,@phone,@email,@remark,'',@cdate)";
            dbHelper.cmdExecute(sqlText, paras);
            dbHelper.pageMsg(this, "问题提交成功", "/AboutUS.aspx?id=15&pid=10");
        }
    }
}