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
    public partial class productview : System.Web.UI.Page
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

            string qry = "select * from producttable2";
            DataSet ds = obj.exeadapter(qry);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }




        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
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
            int Pdt_id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtdsec = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtdprice = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txtstatus = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            TextBox txtdstock = (TextBox)GridView1.Rows[i].Cells[8].Controls[0];
            string strup = "update producttable2 set pdt_desc='" + txtdsec.Text + "',pdt_price='" + txtdprice.Text + "',pdt_status='" + txtstatus.Text + "',pdt_stock='" + txtdstock.Text + "' where ptd_id=" + Pdt_id + "";
            int s = obj.exenonqry(strup);
            GridView1.EditIndex = -1;
            bindgrid();

        }
    }
}