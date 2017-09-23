using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class IncompleteInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvInvoices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int invID = Convert.ToInt32(gvInvoices.Rows[row].Cells[5].Text);

            Response.Redirect("Invoice.aspx?Incomplete=" + invID);
        }
    }
}