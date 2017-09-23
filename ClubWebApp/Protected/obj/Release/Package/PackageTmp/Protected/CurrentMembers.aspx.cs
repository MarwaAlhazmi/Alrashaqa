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
    public partial class CurrentMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (ClubDBEntities club = new ClubDBEntities())
            {
                gvMembers.DataSource = club.getVisitsByDate(DateTime.Now.Date);
                gvMembers.DataBind();
            }
        }

        protected void gvMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvMembers.Rows[row].Cells[5].Text);
            if (e.CommandName == "Select")
            {
                Response.Redirect("Search.aspx?ClientID=" + id);
            }
            if (e.CommandName == "Delete")
            {
                Response.Redirect("Visit.aspx?ClientID=" + id);
            }
        }
    }
}