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
        private static IEnumerable<InvoiceReport> result;
        CultureInfo cul = new CultureInfo("en-GB");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (!Page.IsPostBack)
                {
                   
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
            else if (rbSelect.SelectedIndex == 1)
            {
                lblDate.Text = "رقم الفاتورة";
                tbDate.Text = "";
                tbDate0_CalendarExtender.Enabled = false;
                reID.Enabled = true;
            }
            else
            {
                lblDate.Text = "رقم الملف";
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
                    result = club.getInvoice(date);
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
                
            }
            else
            {
                if (rbSelect.SelectedIndex == 1)
                {
                    var id = Convert.ToInt32(tbDate.Text);
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        result = club.getInvoice(id);
                        GridView1.DataSource = result;
                        GridView1.DataBind();
                    }
                }
                if (rbSelect.SelectedIndex == 2)
                {
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        result = club.getInvoice(tbDate.Text);
                        GridView1.DataSource = result;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridView1.Rows[row].Cells[11].Text;
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = result;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int inv = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[11].Text);
            Response.Redirect("Invoice.aspx?Inv="+inv.ToString());

        }

      


    }
}