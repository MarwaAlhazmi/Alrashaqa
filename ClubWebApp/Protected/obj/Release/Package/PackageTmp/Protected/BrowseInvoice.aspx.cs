using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class BrowseInvoice : System.Web.UI.Page
    {
        private static string where;
        private static bool first;
        CultureInfo cul;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    cul = new CultureInfo("en-GB");
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void rbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSelect.SelectedIndex == 0)
            {
                lblDate.Text = "تاريخ الفاتورة";
                tbDate.Text = "";
                tbDate0_CalendarExtender.Enabled = true;
                reID.Enabled = false;
            }
            else
            {
                lblDate.Text = "رقم الفاتورة";
                tbDate.Text = "";
                tbDate0_CalendarExtender.Enabled = false;
                reID.Enabled = true;
            }
        }

        protected void btnSearch0_Click(object sender, EventArgs e)
        {
            if (rbSelect.SelectedIndex == 0)
            {

                using (ClubDBEntities club = new ClubDBEntities())
                {
                    DateTime date = Convert.ToDateTime(tbDate.Text,cul);
                    var result = club.getInvoice(date);
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
                
            }
            else
            {

                var id = Convert.ToInt32(tbDate.Text); 
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = club.getInvoice(id);
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridView1.Rows[row].Cells[10].Text;
                Session["InvoiceID"] = id;
                Session["WithID"] = null;
                Response.Redirect("ShowInvoice.aspx");
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count <= 0 && !first)
            {
                lblError.Visible = true;
                lblError.Text = "لايوجد بيانات لعرضها";
            }
            else
            {
                lblError.Visible = false;
                first = false;
            }
        }
    }
}