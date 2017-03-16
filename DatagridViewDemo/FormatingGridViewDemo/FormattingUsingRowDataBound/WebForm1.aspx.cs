using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatagridViewDemo.FormatingGridViewDemo.FormattingUsingRowDataBound
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {       
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text == "IT")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString() + "( " + e.Row.Cells[6].Text + ")";

                }
                else if (e.Row.Cells[6].Text == "HR")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString() + "( " + e.Row.Cells[6].Text + ")";

                }
                else if (e.Row.Cells[6].Text == "Payroll")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString() + "( " + e.Row.Cells[6].Text + ")";

                }

                // if the salary is greater than 70000 then change the row color

                int salary = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AnnualSalary"));
                if (salary >= 70000)
                {
                    e.Row.BackColor = System.Drawing.Color.Cyan;
                    
                }
            }
        }
    }
}