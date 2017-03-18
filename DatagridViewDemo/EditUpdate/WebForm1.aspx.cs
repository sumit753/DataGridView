using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatagridViewDemo.EditUpdate
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if(e.AffectedRows < 1)
            {
                e.KeepInEditMode = true;
                LblMessage.Text = "Update Was not SucessFull for Employee Id = " + e.Keys[0];
                LblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LblMessage.Text = "Record Updated Successfully";
                LblMessage.ForeColor = System.Drawing.Color.Navy;
            }
        }

        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if(e.ReturnValue is int && (int) e.ReturnValue > 0)
            {
                e.AffectedRows = (int)e.ReturnValue;
            }
        }
    }
}