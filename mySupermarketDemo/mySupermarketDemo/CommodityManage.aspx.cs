using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RL.DBUtility;

namespace mySupermarketDemo
{
    public partial class CommodityManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrop();
            }

        }
        // 绑定下拉框
        private void BindDrop()
        {
            //获取分类ID和分类名称
            string sql = "SELECT SortID,SortName FROM dbo.CommoditySort";
            DataSet ds = DbHelperSQL.Query(sql);//将查询结果放入数据集ds中
            ddlSort.DataSource = ds;//将数据源放至下拉菜单中
            DataRow drNew = ds.Tables[0].NewRow();//方法，新建一行
            drNew["SortID"] = 0;//为新增的一行添加两个属性
            drNew["SortName"] = "全部";
            ds.Tables[0].Rows.InsertAt(drNew,0);//将新增的一行添加到ds中
            ddlSort.DataTextField = "SortName";//为下拉菜单设置初始值
            ddlSort.DataValueField = "SortID";
            ddlSort.DataBind();
        
        }
    }
}