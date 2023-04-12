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
    public partial class userhome : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    string sel = "select cat_id,cat_image,cat_name,cat_desc from Cattable";
                    DataSet ds = obj.exeadapter(sel);
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
            }

        }

    

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["cat_id"] = id;
            Response.Redirect("UserPdtDisplay.aspx");
        }

    }
}
