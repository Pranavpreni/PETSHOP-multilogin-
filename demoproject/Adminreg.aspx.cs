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
    public partial class Adminreg : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Admin_id) from Admintable2 ";
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



            string qry = "insert into Admintable2 values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
            int i = obj.exenonqry(qry);
            string qry2 = "insert into Logintable2 values(" + Reg_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','Admin','Active')";
            int j = obj.exenonqry(qry2);



            if (i != 0 && j != 0)
            {
                Label1.Text = "Registered";
            }
            else
            {
                Label1.Text = "not registered";
            }
        }


    }
}


        
    
