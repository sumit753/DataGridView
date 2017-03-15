using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DatagridViewDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //binding xmlfile throught dataset
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));

            GridView4.DataSource = ds;
            GridView4.DataBind();
        }
    }
}