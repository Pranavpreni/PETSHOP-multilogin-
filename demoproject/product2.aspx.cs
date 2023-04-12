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
    public partial class product2 : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string qry1 = "select cat_id,cat_name from cattable";
            DataSet ds = obj.exeadapter(qry1);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "cat_name";
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, "-select-");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
                string d = DropDownList1.SelectedItem.Value;
                string img = "~/propic/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(img));

                string qry = "insert into producttable2 values ('" + d + "','" + TextBox1.Text + "','" + img + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "')";
                int i = obj.exenonqry(qry);
                if (i != 0)
                {
                    Label1.Text = "inserted..";
                }
                else
                {
                    Label1.Text = "not inserted...";
                }
            }
        }
   }
