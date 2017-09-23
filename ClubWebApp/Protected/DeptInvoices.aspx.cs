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
    public partial class DeptInvoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var result = club.getIncompleteInvoices();
                        if (result.Count() == 0)
                        {
                            lblError.Visible = true;
                            lblError.Text = "لايوجد بيانات لعرضها";
                        }
                        else
                        {
                            lblError.Visible = false;
                            gvInvoices.DataSource = result;
                            gvInvoices.DataBind();
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvInvoices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int invID = Convert.ToInt32(gvInvoices.Rows[row].Cells[7].Text);

            Response.Redirect("Deposit.aspx?Inv=" + invID);
        }

        protected void gvInvoices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvInvoices.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "لايوجد بيانات لعرضها";
            }
            else
            {
                lblError.Visible = false;
            }
        }
    }
}