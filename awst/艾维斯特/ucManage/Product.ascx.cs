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
    public partial class Product : System.Web.UI.UserControl
    {
        public string getCompanyInfo = "";
        public string productType = "";//产品大类
        public string productType2 = "";//产品小类
        protected void Page_Load(object sender, EventArgs e)
        {
            bindInfo();
            bindProductType();
        }
        //绑定产品类型
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
                            productType2 += "<li><a href=\"/Product.aspx?pid=" + ds2.Tables[0].Rows[j]["id"] +"\">" + ds2.Tables[0].Rows[j]["title"] + "</a></li>";
                        }
                        productType2 += "</ul>";
                    }
                    productType += "<li>" + ds.Tables[0].Rows[i]["title"] + productType2 + "</li>";
                    productType2 = "";
                }
                productType += "</ul>";
            }
            productType += "</div>";
        }
        //绑定公司信息
        public void bindInfo()
        {
            DataSet ds2 = dbHelper.getDS("select * from tb_companyInfo");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                getCompanyInfo += "<ul>";
                getCompanyInfo += "<li>" + ds2.Tables[0].Rows[0]["name"].ToString() + "</li>";
                getCompanyInfo += "<li>电话：" + ds2.Tables[0].Rows[0]["phone"].ToString() + "</li>";
                getCompanyInfo += "<li>传真：" + ds2.Tables[0].Rows[0]["fax"].ToString() + "</li>";
                getCompanyInfo += "<li>手机：" + ds2.Tables[0].Rows[0]["cellphone"].ToString() + "</li>";
                getCompanyInfo += "<li>公司邮箱：" + ds2.Tables[0].Rows[0]["email"].ToString() + "</li>";
                getCompanyInfo += "<li>网址：" + ds2.Tables[0].Rows[0]["website"].ToString() + "</li>";
                getCompanyInfo += "</ul>";
            }   
        }
    }
}