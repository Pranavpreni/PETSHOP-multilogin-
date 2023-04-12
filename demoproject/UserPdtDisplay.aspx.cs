using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace demoproject
{
    public partial class UserPdtDisplay : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from producttable2 where cat_id='" + Session["cat_id"] + "'";
                DataSet ds = obj.exeadapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();

            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int pid = Convert.ToInt32(e.CommandArgument);
            Session["pdt_id"] = pid;
            Response.Redirect("userproductview.aspx");


        }
    }
}