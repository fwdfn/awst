using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;
using System.Web.UI.HtmlControls;

namespace 艾维斯特.background.ProductFile
{
    public partial class ProductManager : dataHelper.basePage
    {
        public int controller = 0;
        public string sqlText = "select * from tb_product where 1=1 ";
        public string sqlSort = "";
        public string sqlGrandpaClass = "";
        public string sqlFatherClass = "";
        public string sqlSearch = "";
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Request.QueryString["id"] != null)
        //        {
        //            bindInfo("select * from tb_product where pid=" + Convert.ToInt32(Request.QueryString["id"]));
        //        }
        //        else {
        //            bindInfo("select * from tb_product");
        //            bindFTYPE();
        //        }
        //        bindTypeInfo();
        //    }
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    bindInfo("select * from tb_product where pid=" + Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    bindInfo("select * from tb_product");
                    bindFTYPE();
                }
                bindTypeInfo();
            }
        }
        /// <summary>
        /// 绑定产品大类
        /// </summary>
        public void bindTypeInfo()
        {
            if (Request.QueryString["id"] != null)
            {
                DataSet ds2 = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=0");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    ddlType1.DataSource = ds2;
                    ddlType1.DataTextField = "title";
                    ddlType1.DataValueField = "id";
                    ddlType1.DataBind();
                    ddlType1.Items.Add(new ListItem("产品大类", "-1"));
                    DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where id=" + Convert.ToInt32(Request.QueryString["pid"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlType1.SelectedValue = ds.Tables[0].Rows[0]["id"].ToString();

                        DataSet ds3 = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=" + Convert.ToInt32(Request.QueryString["pid"]));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlType2.DataSource = ds3;
                            ddlType2.DataTextField = "title";
                            ddlType2.DataValueField = "id";
                            ddlType2.DataBind();
                            ddlType2.Items.Add(new ListItem("产品小类", "-1"));
                        }
                        ddlType2.SelectedValue = Request.QueryString["id"].ToString();
                    }
                }                
            }
        }
        public void bindFTYPE()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=0");
            ddlType1.DataSource = ds;
            ddlType1.DataTextField = "title";
            ddlType1.DataValueField = "id";
            ddlType1.DataBind();
            ddlType1.Items.Add(new ListItem("请选择", "-1"));
            ddlType1.SelectedValue = "-1";
            ddlType1.DataSource = "";

            ddlType2.Items.Add(new ListItem("请选择", "-1"));
        }
        /// <summary>
        /// 用gv绑定表格信息
        /// </summary>
        /// <param name="sqlText"></param>
        public void bindInfo(string sqlText)
        {
            DataSet ds = dataHelper.dbHelper.getDS(sqlText);
            gv.DataSource = ds;
            gv.DataBind();
        }
        /// <summary>
        /// 绑定父级栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getParentName(int id)
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where id="+id);
            return ds.Tables[0].Rows[0]["title"].ToString();
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {            
            gv.PageIndex = e.NewPageIndex;
            if (ddlType2.SelectedValue == "-1")
            {
                bindInfo(sqlText + getGrandpaClass() + getSearch() + getSort());
            }
            else
            {
                bindInfo(sqlText + getFatherClass() + getSearch() + getSort());
            }       
        }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductManager.aspx");
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int num=0;
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hick = gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hick.Checked)
                {
                    num =Convert.ToInt32(gvr.Cells[1].Text);
                }
            }            
            Response.Redirect("ProductManager.aspx?id="+num);
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hick = gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hick.Checked)
                {
                    num = Convert.ToInt32(gvr.Cells[1].Text);
                }
            }
            dataHelper.dbHelper.cmdExecute("delete tb_product where id="+num);
            dataHelper.dbHelper.pageMsg(this, "删除成功", "Product.aspx");
        }
        /// <summary>
        /// 行绑定事件:添加鼠标移上去的样式 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.background;this.style.background='#e6f0fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.background='#ffffff'");
        }

        /// <summary>
        /// 获取排序方式
        /// </summary>
        /// <returns></returns>
        public string getSort()
        {
            switch (ddlSort.SelectedIndex)
            {
                case 0:
                    sqlSort = "";
                    break;
                case 1:
                    sqlSort = "order by id";
                    break;
                case 2:
                    sqlSort = "order by id desc";
                    break;
                case 3:
                    sqlSort = "order by cdate";
                    break;
                case 4:
                    sqlSort = "order by cdate desc";
                    break;
            }
            return sqlSort;
        }
        /// <summary>
        /// 选择按什么排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType2.SelectedValue == "-1")
            {
                bindInfo(sqlText + getGrandpaClass() + getSearch() + getSort());
            }
            else
            {
                bindInfo(sqlText + getFatherClass() + getSearch() + getSort());
            }                 
        }
        /// <summary>
        /// 产品大类点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //绑定产品小类
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_productColumn where pid=" +Convert.ToInt32(ddlType1.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlType2.DataSource = ds;
                ddlType2.DataTextField = "title";
                ddlType2.DataValueField = "id";
                ddlType2.DataBind();
            }                
            else {
                ddlType2.Items.Clear();                
            }
            ddlType2.Items.Add(new ListItem("产品小类", "-1"));
            ddlType2.SelectedValue = "-1";
            //显示大类下所有产品
            if (ddlType2.SelectedValue == "-1")
            {
                if (ddlType1.SelectedValue == "-1")
                {
                    bindInfo(sqlText + getSearch() + getSort());
                }
                else { //选了产品大类
                    bindInfo(sqlText+getGrandpaClass()+getSearch()+getSort());
                }                                
            }
            else
            {
                bindInfo(sqlText + getFatherClass() + getSearch() + getSort());
            }                       
        }
        public string getGrandpaClass()
        { 
            string nums="";
            DataSet ds=dataHelper.dbHelper.getDS("select id from tb_productColumn where pid ="+Convert.ToInt32(ddlType1.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nums += dr[0].ToString() + ",";
                }
                nums = nums.TrimEnd(',');
                sqlGrandpaClass = "and pid in(" + nums + ") ";
            }
            else {               
                sqlGrandpaClass = " ";
            }
            return sqlGrandpaClass;
        }
        /// <summary>
        /// 产品小类的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType2.SelectedValue == "-1")
            {
                bindInfo(sqlText + getGrandpaClass() + getSearch() + getSort());
            }
            else
            {
                bindInfo(sqlText + getFatherClass() + getSearch() + getSort());
            }           
        }
        public string getFatherClass()
        {
            if (ddlType2.SelectedValue == "-1")
            {
                sqlFatherClass = "";
            }
            else
            {
                sqlFatherClass = "and pid=" + Convert.ToInt32(ddlType2.SelectedValue);
                 
            }
            return sqlFatherClass;
        }
        /// <summary>
        /// 搜索框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchBtn_Click(object sender, EventArgs e)
        {            
            //当没选产品的父级时
            if (ddlType2.SelectedValue == "-1")
            {
                bindInfo(sqlText + getGrandpaClass() + getSearch() + getSort());
            }                
            else
            {
                bindInfo(sqlText + getFatherClass() + getSearch() + getSort());
            }
            searchText.Value = null;         
        }
        public string getSearch()
        {
            return sqlSearch = " and name like '%" + searchText.Value + "%' ";
        }
    }
}