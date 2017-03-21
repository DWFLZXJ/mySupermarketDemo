using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 测试
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gv.Rows.Count; i++)
            {
                string id = this.gv.Rows[i].Cells[1].Text;
                CheckBox cb = this.gv.Rows[i].FindControl("cb") as CheckBox;
                if (cb.Checked)
                {
                    //操作    
                }
            }

        }
    }
}