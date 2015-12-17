using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background
{
    public partial class CopyRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binfInfo();
            }
        }
        /// <summary>
        /// 网站基本信息
        /// </summary>
        public void binfInfo()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_companyInfo");
            if(ds.Tables[0].Rows.Count>0)
            {
                //优化
                titleOP.Value = ds.Tables[0].Rows[0]["title"].ToString();
                keywordsOP.Value = ds.Tables[0].Rows[0]["keywords"].ToString();
                descriptionOP.Value=ds.Tables[0].Rows[0]["webdescription"].ToString();

                //公司基本信息
                name.Value=ds.Tables[0].Rows[0]["name"].ToString();
                address.Value=ds.Tables[0].Rows[0]["address"].ToString();
                website.Value = ds.Tables[0].Rows[0]["website"].ToString();
                cellphone.Value = ds.Tables[0].Rows[0]["cellphone"].ToString();
                phone.Value = ds.Tables[0].Rows[0]["phone"].ToString();
                fax.Value = ds.Tables[0].Rows[0]["fax"].ToString();
                qq.Value = ds.Tables[0].Rows[0]["qq"].ToString();
                email.Value = ds.Tables[0].Rows[0]["email"].ToString();
                support.Value = ds.Tables[0].Rows[0]["support"].ToString();
                copyright.Value = ds.Tables[0].Rows[0]["copyright"].ToString();
            }
            
        }
        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            string sqlText = "update tb_companyInfo set name=@name,title=@title,website=@website,address=@address,cellphone=@cellphone,phone=@phone,fax=@fax,qq=@qq,email=@email,support=@support,copyright=@copyright,keywords=@keywords,webdescription=@webdescription where id=@id";
            SqlParameter[] para ={
                                new SqlParameter("@name",name.Value),
                                new SqlParameter("@title",titleOP.Value),
                                new SqlParameter("@website",website.Value),
                                new SqlParameter("@address",address.Value),
                                new SqlParameter("@cellphone",cellphone.Value),
                                new SqlParameter("@phone",phone.Value),
                                new SqlParameter("@fax",fax.Value),
                                new SqlParameter("@qq",qq.Value),
                                new SqlParameter("@email",email.Value),
                                new SqlParameter("@support",support.Value),
                                new SqlParameter("@copyright",copyright.Value),
                                new SqlParameter("@keywords",keywordsOP.Value),
                                new SqlParameter("@webdescription",descriptionOP.Value),
                                new SqlParameter("@id",1) 
                                };
            dataHelper.dbHelper.cmdExecute(sqlText, para);
            dataHelper.dbHelper.pageMsg(this, "修改成功", "CopyRight.aspx");
        }
    }
}