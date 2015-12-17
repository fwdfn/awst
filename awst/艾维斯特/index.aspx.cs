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
    public partial class index : System.Web.UI.Page
    {
        public string companyInfo = string.Empty;//公司信息
        public string imgs = "";//绑定幻灯片
        public string webTitle = "";
        public string webDescription = "";
        public string webKeywords = "";
        public string bindMenu = "";
        public string productType="";//产品类别
        public string productType2 = "";//产品类别2
        public string newsList = "";//绑定新闻列表
        public string companyIntroduce = "";//公司简介
        protected void Page_Load(object sender, EventArgs e)
        {                     
            bind();
            bindMainMenu();
            bindProductType();          
        }
        /// <summary>
        /// 导航栏
        /// </summary>
        public void bindMainMenu()
        {
            DataSet ds = dbHelper.getDS("select * from tb_menu where pid=0 order by sort");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bindMenu += "<li><a href=\""+dr["linkUrl"].ToString() +"\">"+dr[1].ToString() +"</a></li>";                 
                }
            }           
        }
        /// <summary>
        /// 产品大小类信息
        /// </summary>
        public void bindProductType()
        {
            productType += "<div id=\"productTypeTxt\">";
            DataSet ds = dbHelper.getDS("select * from tb_productColumn where pid=0 and ishide=0 order by sort");
            if (ds.Tables[0].Rows.Count > 0)
            {
                productType += "<ul>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds2 = dbHelper.getDS("select * from tb_productColumn where pid=" + ds.Tables[0].Rows[i]["id"] + "and ishide=0 order by sort");
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        productType2 += "<ul>";
                        for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                        {
                            productType2 += "<li><a href=\"Product.aspx?pid="+ds2.Tables[0].Rows[0]["id"]+"\">" + ds2.Tables[0].Rows[j]["title"] + "</a></li>";
                        }
                        productType2 += "</ul>";
                    }
                    productType += "<li><a href=\"#\">" + ds.Tables[0].Rows[i]["title"]+"</a>" + productType2 + "</li>";
                    productType2 = "";
                }
                productType += "</ul>";
            }
            productType += "</div>";
        }

        /// <summary>
        /// 绑定网站基本信息
        /// </summary>
        public void bind()
        {
            //网站标题，关键字，描述
            DataSet ds2 = dbHelper.getDS("select * from tb_companyInfo");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                webTitle = ds2.Tables[0].Rows[0]["title"].ToString();
                webKeywords = ds2.Tables[0].Rows[0]["keywords"].ToString();
                webDescription = ds2.Tables[0].Rows[0]["webdescription"].ToString();
            }
            //绑定幻灯片图片
            DataSet ds3 = dbHelper.getDS("select * from tb_img where pid=0 and ishide=0");
            if (ds3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    imgs += "<img src=\"" + ds3.Tables[0].Rows[i]["title"].ToString() + "\">";
                }
            }
            //绑定公司简介信息。此处id为死的
            DataSet ds4 = dbHelper.getDS("select * from tb_menu where id=3");
            if (ds4.Tables[0].Rows.Count > 0)
            {
                string abc = "<div style=\"margin:0 10px 0 0;\">" + (ds4.Tables[0].Rows[0]["content"].ToString()).Substring(0, 350) + "...</div>";                
                companyIntroduce = abc;                
            }
            //绑定新闻列表
            DataSet ds5 = dbHelper.getDS("select top 6 * from tb_newsInfo order by sort");
            if (ds5.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds5.Tables[0].Rows)
                {
                    newsList += "<li><a href=\"/NewsDetailed.aspx?content=content&newsid=" + dr["id"] + "&newspid=" + dr["pid"] + "\">" + dr["title"].ToString() + "</a></li>";
                }                
            }
            //<%--公司电话：027－87166527 公司传真：027-87530722 公司QQ：1740864522 公司地址：武汉市洪山区雄楚大街450号
            //         <br />
            //         公司邮箱：avist_wh@163.com 技术支持：<a href="#">仙桃赵斌</a> <a href="#">[网站管理]</a> 
            //         <br />
            //         武汉艾维斯特科技有限公司 版权所有 ©--%>

            //绑定公司基本信息
            DataSet ds = 艾维斯特.background.dataHelper.dbHelper.getDS("select * from tb_companyInfo");
            companyInfo = "公司电话:"+ds.Tables[0].Rows[0][2]+"&nbsp;公司传真:"+ds.Tables[0].Rows[0][3]+"&nbsp;公司QQ:"+ds.Tables[0].Rows[0][4]+"&nbsp;公司地址:"+ds.Tables[0].Rows[0][1];
            companyInfo += "<br>公司邮箱:"+ds.Tables[0].Rows[0][5]+"&nbsp;技术支持:"+ds.Tables[0].Rows[0][6];
            companyInfo += "<br>" + ds.Tables[0].Rows[0][7] + "&nbsp;版权所有©";
        }
        //首页产品搜索功能
        protected void searchBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Product.aspx?id=9&pid=0&txt="+searchTxt.Value);
        }
    }
}