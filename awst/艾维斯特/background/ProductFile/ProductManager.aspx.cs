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
    public partial class ProductInfoManager : dataHelper.basePage
    {
        public string columnInfo = string.Empty;        
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        //绑定第一级产品类型
        //        bindProductFTYPE();
        //        if (Request.QueryString["id"] != null)
        //        {
        //            Session["operation"] = "修改产品信息";
        //            //columnInfo = "修改产品信息";               dropdownlist触发点击事件时columnInfo为什么会失效
        //            bindProductInfo();
        //        }
        //        else
        //        {
        //            Session["operation"] = "添加产品信息";
        //          //  bindProductFTYPE();
        //        }
        //    }            
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                //绑定第一级产品类型
                bindProductFTYPE();
                if (Request.QueryString["id"] != null)
                {
                    Session["operation"] = "修改产品信息";
                    //columnInfo = "修改产品信息";               dropdownlist触发点击事件时columnInfo为什么会失效
                    bindProductInfo();
                }
                else
                {
                    Session["operation"] = "添加产品信息";
                    //  bindProductFTYPE();
                }
            }      
        }
        /// <summary>
        /// 绑定要修改的产品信息
        /// </summary>
        public void bindProductInfo()
        {
            //传过来的产品id
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_product where id="+id);            
            if (ds.Tables[0].Rows.Count > 0)
            {
                name.Value = ds.Tables[0].Rows[0]["name"].ToString();
                //产品的pid
                int pid = Convert.ToInt32(ds.Tables[0].Rows[0]["pid"]);
                DataSet ds2 = dataHelper.dbHelper.getDS("select * from tb_productColumn where id=" + pid);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    //产品类型的pid
                    int pid2 = Convert.ToInt32(ds2.Tables[0].Rows[0]["pid"]);
                    DataSet ds3 = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=" + pid2);
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        //选择产品的产品类型
                        ddlType2.DataSource = ds3;
                        ddlType2.DataTextField = "title";
                        ddlType2.DataValueField = "id";
                        ddlType2.DataBind();
                        ddlType2.Items.Add(new ListItem("请选择", "-1"));
                        ddlType2.SelectedValue = ds3.Tables[0].Rows[0]["id"].ToString();
                        //选择产品类型的类型(大类)
                        ddlType.SelectedValue = ds3.Tables[0].Rows[0]["pid"].ToString();                    
                    }                    
                }
                EditColumnRightsort.Value = ds.Tables[0].Rows[0]["sort"].ToString();
                hots.Value = ds.Tables[0].Rows[0]["hots"].ToString();
                txtContent.Value = ds.Tables[0].Rows[0]["remark"].ToString();
            }              
        }
        public void bindProductFTYPE()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=0");
            ddlType.DataSource = ds;
            ddlType.DataTextField = "title";
            ddlType.DataValueField = "id";
            ddlType.DataBind();
            ddlType.Items.Add(new ListItem("请选择", "-1"));
            ddlType.SelectedValue = "-1";
            ddlType.DataSource = "";
        }
        /// <summary>
        /// 二级联动效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid="+Convert.ToInt32(ddlType.SelectedValue));
            ddlType2.DataSource = ds;
            ddlType2.DataTextField = "title";
            ddlType2.DataValueField = "id";
            ddlType2.DataBind();
            ddlType2.Items.Add(new ListItem("请选择", "-1"));
            ddlType2.SelectedValue = "-1";
            
        }
        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            //判断是否选择了产品的父级栏目
            if(Convert.ToInt32(ddlType2.SelectedValue)>0)
            {
                SqlParameter[] param ={
                                      new SqlParameter("@name",name.Value),
                                      new SqlParameter("@pid",Convert.ToInt32(ddlType2.SelectedValue)),
                                      new SqlParameter("@sort",EditColumnRightsort.Value),
                                      new SqlParameter("@hots",hots.Value),
                                      new SqlParameter("@picpath",""),//暂时设置为空
                                      new SqlParameter("@cdate",DateTime.Now),
                                      new SqlParameter("@remark",txtContent.Value),
                                      new SqlParameter("@id",Convert.ToInt32(Request.QueryString["id"])) //当没有id时会出错？没有问题
                                     };
                string sqlText;
               //修改产品信息
                if (Convert.ToInt32(Request.QueryString["id"]) > 0)
               {
                   sqlText = "update tb_product set name=@name,pid=@pid,sort=@sort,hots=@hots,picpath=@picpath,remark=@remark where id=@id";
                   dataHelper.dbHelper.cmdExecute(sqlText, param);
                   dataHelper.dbHelper.pageMsg(this, "修改成功", "Product.aspx");     
               }
               //添加产品信息
                else
              {
                sqlText = "insert into tb_product values(@name,@pid,@sort,@hots,@picpath,@cdate,@remark)";
                dataHelper.dbHelper.cmdExecute(sqlText, param);
                dataHelper.dbHelper.pageMsg(this, "添加成功", "Product.aspx");     
              }            
            }
            else
            {
              dataHelper.dbHelper.pageMsg2(this,"请选择产品所属栏目");               
            }
            
        }
        /// <summary>
        /// 上传图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void upLoadBtn_Click(object sender, EventArgs e)
        {
            string fileName = upLoad.PostedFile.FileName;
            int fileLength = upLoad.PostedFile.ContentLength;
            string ext=System.IO.Path.GetExtension(fileName);
            if (ext == ".jpg" || ext == ".png" || ext == ".gif")
            {
                upLoad.SaveAs(Server.MapPath("../UploadImg/") + fileName);
                upLoadImg.Src = "../UploadImg/" + fileName;
            }
            else {
                dataHelper.dbHelper.pageMsg2(this,"请上传图片");
            }                        
        }
    }
}