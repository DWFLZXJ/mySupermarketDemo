using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using RL.DBUtility;

namespace Supermarket
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = tbUserName.Text;
            string pass = tbPassword.Text;
            string sql = "select Top 1 * from Users where UserName = @UserName and Password = @Password";
            SqlParameter[] pms = { 
                                    new SqlParameter("@UserName",SqlDbType.VarChar,50),
                                    new SqlParameter("@Password",SqlDbType.VarChar,50)
                                 };
            pms[0].Value = user;
            pms[1].Value = pass;
            DataSet ds = DbHelperSQL.Query(sql,pms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["UserId"] = ds.Tables[0].Rows[0]["UserId"];
                Response.Redirect("~/CommodityManage.aspx");
            }
            else 
            {
                Response.Write("<script>alert('用户名或者密码错误！');</script");
            }

        }
    }
}