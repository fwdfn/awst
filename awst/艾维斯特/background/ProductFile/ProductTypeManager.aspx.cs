using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;


namespace 艾维斯特.background.ProductFile
{
    public partial class ProductTypeManager : dataHelper.basePage
    {
        public string columnInfo = string.Empty;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        //绑定一级栏目信息
        //        DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=0");
        //        ddlType.DataSource = ds;
        //        ddlType.DataTextField = "title";
        //        ddlType.DataValueField = "id";
        //        ddlType.DataBind();
        //        ddlType.Items.Add(new ListItem("请选择一级栏目", "0"));
        //        ddlType.SelectedValue = "0";
        //        if (Request.QueryString["id"] == null)
        //        {
        //            columnInfo = "添加产品类型信息";
        //        }
        //        else
        //        {
        //            columnInfo = "修改产品类型信息";
        //            bindInfo();
        //        }
        //    }
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                //绑定一级栏目信息
                DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=0");
                ddlType.DataSource = ds;
                ddlType.DataTextField = "title";
                ddlType.DataValueField = "id";
                ddlType.DataBind();
                ddlType.Items.Add(new ListItem("请选择一级栏目", "0"));
                ddlType.SelectedValue = "0";
                if (Request.QueryString["id"] == null)
                {
                    columnInfo = "添加产品类型信息";
                }
                else
                {
                    columnInfo = "修改产品类型信息";
                    bindInfo();
                }
            }
        }
        public void bindInfo()
        {
            
            DataSet ds = dbHelper.getDS("select * from tb_productColumn where id="+Convert.ToInt32(Request.QueryString["id"]));
            name.Value = ds.Tables[0].Rows[0][1].ToString();
            //绑定一级栏目       

            ddlType.SelectedValue = ds.Tables[0].Rows[0]["pid"].ToString();
            EditColumnRightsort.Value = ds.Tables[0].Rows[0]["sort"].ToString();
            if (ds.Tables[0].Rows[0]["isHide"].ToString() == "0")
            { 
                Show.Checked=true;
            }
            else
            {
                Hide.Checked = true;
            }                 
            txtContent.Value=ds.Tables[0].Rows[0]["note"].ToString();
        }
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {            
            int num=0;
            if(Hide.Checked)
            {
             num=1;
            }
            else if(Show.Checked)
            {
             num=0;
            }
            SqlParameter[] para = { 
                                   new SqlParameter("@title",name.Value),
                                   new SqlParameter("@pid",Convert.ToInt32(ddlType.SelectedValue)),
                                   new SqlParameter("@sort",EditColumnRightsort.Value),
                                   new SqlParameter("@isHide",num),
                                   new SqlParameter("@cdate",DateTime.Now),
                                   new SqlParameter("@note",txtContent.Value),
                                   new SqlParameter("@id",Convert.ToInt32(Request.QueryString["id"]))

                                  };
            if (Request.QueryString["id"] == null)
            {
                string sqlText = "insert into tb_productColumn values(@title,@pid,@sort,@isHide,@cdate,@note)";
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this, "添加成功", "ProductType.aspx");
            }
            else
            {
                string sqlText = "update tb_productColumn set title=@title,pid=@pid,sort=@sort,isHide=@isHide,cdate=@cdate,note=@note where id=@id";
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this, "修改成功", "ProductType.aspx");
            }
            
        }
    }
}