using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatagridViewDemo.DeletingUsingSqlDataSource
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[4].Controls[0];
                //applying javascript
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you sure you want to delete this..?')";
                }
            }
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.AffectedRows > 0)
            {
                lblMessage.Text = "Record With Employee Id\"" + e.Keys[0] + "\"is Sucessfully Deleted ";
                lblMessage.ForeColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                lblMessage.Text = "Record With Employee Id\"" + e.Keys[0] + "\"is not Deleted ,due to data Confilcts ";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}