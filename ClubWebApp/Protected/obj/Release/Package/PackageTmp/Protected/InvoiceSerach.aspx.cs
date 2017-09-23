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
    public partial class InvoiceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (Page.IsPostBack)
                {
                }
                else
                {
                    tbDateFrom.Text = DateTime.Now.ToShortDateString();
                    tbDateTo.Text = DateTime.Now.ToShortDateString();
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        // departments
                        var deps = from o in club.Departments
                                   select o;
                        ddlDep.DataSource = deps;
                        ddlDep.DataTextField = "Name";
                        ddlDep.DataValueField = "DepID";
                        ddlDep.DataBind();

                        // doctors

                        var docs = from o in club.Employees
                                   where o.Type == "Trainer"
                                   select o;
                        ddlDoc.DataSource = docs;
                        ddlDoc.DataTextField = "Name";
                        ddlDoc.DataValueField = "EmpID";
                        ddlDoc.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void cbDep_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDep.Checked)
            {
                ddlDep.Enabled = true;
            }
            else
            {
                ddlDep.Enabled = false;
            }
        }

        protected void cbDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDoc.Checked)
            {
                ddlDoc.Enabled = true;
            }
            else
            {
                ddlDoc.Enabled = false;
            }

        }

        protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDep.SelectedIndex != 0)
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    int dep = Convert.ToInt32(ddlDep.SelectedValue);
                    var result = (from o in club.Departments
                                  where o.DepID == dep
                                  select o).First().Employees.AsEnumerable();
                    ddlDoc.DataSource = result;
                    ddlDoc.DataTextField = "Name";
                    ddlDoc.DataValueField = "EmpID";
                    ddlDoc.DataBind();

                }
            }
        }
    }
}