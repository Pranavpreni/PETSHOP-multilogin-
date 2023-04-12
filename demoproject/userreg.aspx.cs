using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoproject
{
    public partial class userreg : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(User_id) from Usertable";
            string regid = obj.exescalar(sel);

            int Reg_id = 0;
            if (regid == "")
            {
                Reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                Reg_id = newregid + 1;
            }

            string img = "~/phs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(img));

            string qry = "insert into Usertable values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "',+'" + TextBox3.Text + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "',+'" + TextBox6.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + img + "')";
            int i = obj.exenonqry(qry);
            string qry2 = " insert into Logintable2 values(" + Reg_id + ",'" + TextBox7.Text + "','" + TextBox8.Text + "','User','Active')";
            int j = obj.exenonqry(qry2);

            if (i != 0 && j != 0)
            {
                Label1.Text = "registered";
            }
            else
            {
                Label1.Text = "not registered";
            }
        }


    }

}

   