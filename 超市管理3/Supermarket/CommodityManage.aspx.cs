using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RL.DBUtility;
using System.Text;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class CommodityManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                BindData();
            }

        }
        //为商品分类下拉绑定数据
        private void BindDropDownList()
        { 
           //获取id和名称
            string sql = "select SortID,SortName from CommoditySort";
            DataSet ds = DbHelperSQL.Query(sql);
            //自己创建一行，存放"全部"的id和name
            DataRow drAll = ds.Tables[0].NewRow();//使用NewRow()这个方法，新建一行，并为这行添加属性
            drAll["SortID"] = 0;
            drAll["SortName"] = "全部";
            //将添加的一行加入到ds中
            ds.Tables[0].Rows.InsertAt(drAll,0);
            //ddl设置，绑定数据
            ddlCommoditySort.DataSource = ds;
            ddlCommoditySort.DataTextField = "SortName";
            ddlCommoditySort.DataValueField = "SortID";
            ddlCommoditySort.DataBind();

        }
        private void BindData()
        {
            //获取选定的ID
            int typeId = int.Parse(ddlCommoditySort.SelectedValue);
            string goodName = tbCommodityName.Text;
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendLine("SELECT c.CommodityID,c.CommodityName,t.SortName,");
            sbSql.AppendLine("c.CommodityPrice,c.IsDiscount,c.ReducedPrice");
            sbSql.AppendLine("FROM Commodity AS c");
            sbSql.AppendLine("INNER JOIN CommoditySort AS t");
            sbSql.AppendLine("ON c.SortID = t.SortID");
            sbSql.AppendLine("WHERE 1=1");
            if (typeId != 0)
            {
                sbSql.AppendLine("AND c.SortID = @SortID");
            }
            if (!string.IsNullOrEmpty(goodName))
            {
                sbSql.AppendLine("AND c.CommodityName LIKE @GoodName");
            }
            SqlParameter[] pms = {
                                     new SqlParameter("@SortID",SqlDbType.Int,4),
                                     new SqlParameter("@GoodName",SqlDbType.VarChar,50)
                                 };
            pms[0].Value = typeId;
            pms[1].Value = "%" + goodName + "%";
            DataSet ds = DbHelperSQL.Query(sbSql.ToString(), pms);
            gvCommodity.DataSource = ds;
            gvCommodity.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommodityAdd.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringBuilder sbIds = new StringBuilder();
            //获取gridview里的checkbox是否被选中
            foreach (GridViewRow gvr in gvCommodity.Rows)
            {
                CheckBox cbSelection = gvr.FindControl("cbSelection") as CheckBox;
                if (cbSelection.Checked)
                {
                    sbIds.Append(gvCommodity.DataKeys[gvr.RowIndex]["CommodityID"] + ",");
                }
            }
            //todo Delete From Table Where ID IN (1,2,3,4..)
            sbIds.Remove(sbIds.Length - 1, 1);//移除最后一个逗号
            //判断选中了一个，还是选中了多个进行删除
            if (sbIds.Length - 1 > 1)
            {
                sbIds.Insert(0, "DELETE FROM dbo.Commodity WHERE CommodityID in (");
                sbIds.Insert(sbIds.Length, ")");
            }
            else
            {
                sbIds.Insert(0, "DELETE FROM dbo.Commodity WHERE CommodityID = ");
            }
            DbHelperSQL.ExecuteSql(sbIds.ToString());
            Response.Write("<script>alert('删除成功');</script>");
            Response.Redirect("CommodityManage.aspx");
        }
    }
}