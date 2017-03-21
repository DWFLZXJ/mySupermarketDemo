using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using RL.DBUtility;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class CommoditySortManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sbSql = new StringBuilder();//构造字符串，string会引入一些垃圾
                //sbSql.AppendLine("SELECT SortID,SortName FROM CommoditySort");//提前写好sql语句
                sbSql.AppendLine("SELECT MySelect,SortName FROM CommoditySort");

                DataSet ds = DbHelperSQL.Query(sbSql.ToString());
                gvSortName.DataSource = ds;
                gvSortName.DataBind();
            }

        }
        /// <summary>
        /// 按钮删除键点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvSortName.Rows.Count; i++)
            {
                string id = gvSortName.Rows[i].Cells[1].Text;
                CheckBox cb = gvSortName.Rows[i].FindControl("CheckBoxSel") as CheckBox;
                if (cb.Checked)
                {
                    string cName1 = gvSortName.Rows[i].Cells[1].Text;
                    string sql2 = "DELETE FROM dbo.CommoditySort WHERE SortName = @SortName";
                    SqlParameter[] pms2 ={
                                         new SqlParameter("@SortName",SqlDbType.NVarChar,50)
                                      };
                    pms2[0].Value = cName1;
                    DbHelperSQL.ExecuteSql(sql2, pms2);
                    Response.Write("<script>alert('删除成功');</script>");
                    Response.Redirect("CommoditySortManage.aspx");
                }
            }


            //法一
            //for (int i = 0; i < this.gvSortName.Rows.Count; i++)
            //{
            //    string id = this.gvSortName.Rows[i].Cells[1].Text;
            //    CheckBox cb = this.gvSortName.Rows[i].FindControl("CheckBoxSel") as CheckBox;
            //    if (cb.Checked)
            //    {
            //        //操作 
            //        Response.Write("<script>alert('选中了!')</script>");
            //    }
            //}

        }
    }
}