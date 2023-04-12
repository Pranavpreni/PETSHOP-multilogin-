using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoproject
{
  
    public partial class LOGIN : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string qry = "select count(Log_id) from Logintable2 where username='" + TextBox1.Text + "'and password ='" + TextBox2.Text + "'";
            string cid = obj.exescalar(qry);

            if (cid == "1")
            {
                string qry2 = "select Log_id from Logintable2  where username='" + TextBox1.Text + "'and password ='" + TextBox2.Text + "'";
                string logid = obj.exescalar(qry2);
                Session["logid"] = logid;

                string qry3 = "select Log_type from Logintable2 where   Log_id=" + Session["logid"] + " ";
                string logtype = obj.exescalar(qry3);

                if (logtype == "Admin")
                {
                    Response.Redirect("administration.aspx");
                }
                else if (logtype == "User")
                {
                    Response.Redirect("userhome.aspx");
                }
            }
            else
            {
                Label1.Text = "invalid pin or id";
            }
        }
    }
}
