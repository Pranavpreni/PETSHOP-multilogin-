using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoproject
{
    public partial class categary2 : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string img = "~/pic/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(img));

            string qry = "insert into cattable values('" + TextBox1.Text + "','" + img + "','" + TextBox2.Text + "','" + RadioButtonList1.SelectedItem.Text + "')";
            int i = obj.exenonqry(qry);
            if (i != 0)
            {
                Label1.Text = "Inserted...";
            }
            else
            {
                Label1.Text = "not inserted..";
            }
        }
    }
}
