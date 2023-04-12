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
    public partial class userview : System.Web.UI.Page
    {
        connectionclass1 obj = new connectionclass1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }
        }
        public void bindgrid()
        {
            string qry = "select Usertable.User_id,Usertable.User_Name,Logintable2.Username,Logintable2.User_Status from Usertable join Logintable2 on Usertable.User_id=Logintable2.Reg_id";
            DataSet ds = obj.exeadapter(qry);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            
            GridView1.EditIndex = e.NewEditIndex;
            bindgrid();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            bindgrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int Reg_id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox ststxt = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            string strup = "update Logintable2 set User_Status='" + ststxt.Text + "' where Reg_id=" + Reg_id + "";
            int s = obj.exenonqry(strup);
            GridView1.EditIndex = -1;
            bindgrid();
        }

    

    }
}
      