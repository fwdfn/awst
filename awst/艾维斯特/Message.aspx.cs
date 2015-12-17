using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using 艾维斯特.background.dataHelper;


namespace 艾维斯特
{
    public partial class Message : System.Web.UI.Page
    {
        public string guide = string.Empty;
        public string difInfo = string.Empty;
        public int msgCount = 0;  //总留言数
        public int msgPages = 0;  //总页数
        public int pageSort = 0;  //第几页
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //自定义的首页，尾页，上一页，下一页
                DataSet ds = dbHelper.getDS("select * from tb_message");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msgCount = ds.Tables[0].Rows.Count;
                }
                //获取总页数
                if ((msgCount % 5) > 0)
                {
                    msgPages = msgCount / 5 + 1;
                }
                else
                {
                    msgPages = msgCount / 5;
                }
                //加载页面
                if (Request.QueryString["pageSort"] != null)
                {
                    pageSort = Convert.ToInt32(Request.QueryString["pageSort"]);
                    //显示首页
                    if (pageSort < 0)
                    {
                        pageSort = 0;
                    }
                    //显示最后一页
                    if (pageSort == msgPages)
                    {                        
                        pageSort = msgPages-1;
                    }
                    bindGuide(pageSort, msgCount);                    
                }
                else
                {
                    //当pageSort为null时pageSort等于初始值0，即加载首页
                    bindGuide(pageSort, msgCount);
                }
            }                       
        }
        protected void guestbook1_btnSave_Click(object sender, EventArgs e)
        { 
         
        }
        public void bindGuide(int pageSort, int msgCount)
        {
            difInfo+="<div id=\"job\">";            
            difInfo+="<div class=\"job\" style=\"height:66px;\">";
            
            difInfo += "<p style=\"text-align:right;\"> <a href=\"#\" style=\"color:black;\">查看留言</a> | <a href=\"/AboutUS.aspx?id=12&pid=0\" style=\"color:black;\" >填写留言</a></p>";
            difInfo+="<p style=\"text-align:center;\">欢迎访问，请留下您宝贵的意见，我们真诚的为您服务</p>";
            difInfo+="</div>";
            DataSet ds = dbHelper.getDS("select top 5 * from tb_message where id>" + 5 * pageSort + " and id<=" + 5 * (pageSort + 1));           
            if(ds.Tables[0].Rows.Count>0)
            {
              difInfo += "<ul>";
              for(int i=0;i<ds.Tables[0].Rows.Count;i++)
              {
                  difInfo+="<li>";
                  difInfo+="<p class=\"msg_name\"  style=\"font-size:small;\" >[留言主题]："+ds.Tables[0].Rows[i]["title"]+"</p>";
                  difInfo+="<div class=\"msg_text\">";
                  difInfo += "[留言内容]：" + ds.Tables[0].Rows[i]["content"] + "";
                  difInfo+="</div>";
                  difInfo+="<p class=\"msg_name\" style=\"font-size:small;\">";
                  difInfo += "[留言人]：" + ds.Tables[0].Rows[i]["username"] + "&nbsp;&nbsp;[留言时间]：" + Convert.ToDateTime(ds.Tables[0].Rows[i]["cdate"]).ToShortDateString() + "</p>";                                                                                                                
                  difInfo+="<div class=\"msg_text\">";
                  difInfo += "[回复内容]：" + ds.Tables[0].Rows[i]["replycontent"] + "";                                                                                                                    
                  difInfo+="</div>";
                  difInfo+="</li>";               
              }
              difInfo += "</ul>";
              difInfo += "共" + msgPages + "页 页次:" + (pageSort + 1) + "/" + msgPages + "页 <a href=\"/Message.aspx?pageSort=0\">首页</a><a href=\"/Message.aspx?pageSort=" + (pageSort - 1) + "\" >上一页</a> <a href=\"/Message.aspx?pageSort=" + (pageSort + 1) + "\" >下一页</a><a href=\"/Message.aspx?pageSort=" + (msgPages - 1) + "\">尾页</a>";   
                //<%--                    <ul>
                //        <li>
                //            <p class="msg_name"  style="font-size:small;" >[留言主题]：PCR板离心机</p>
                //            <div class="msg_text">
                //                [留言内容]：PCR板离心机价格，想购买一台。
                //            </div>
                //            <p class="msg_name" style="font-size:small;">
                //                [留言人]：周先生&nbsp;&nbsp;[留言时间]：2013-03-07</p>
                //            <div class="msg_text">
                //                [回复内容]：请联系13707128722，专人解答。
                //            </div>
                //        </li>
                //    </ul>--%>
            }                        
        }
    }
}