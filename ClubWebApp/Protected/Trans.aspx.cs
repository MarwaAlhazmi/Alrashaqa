using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class Trans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    List<int> years = new List<int>();
                    for (int i = 2010; i < 2051; i++)
                    {
                        years.Add(i);
                    }
                    ddlYear.DataSource = years;
                    ddlYear.DataBind();
                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    dllMonth.SelectedValue = DateTime.Now.Month.ToString();
                }
            }
            else
            {
                Response.Redirect("Error");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportViewer.aspx?type=15&month=" + dllMonth.SelectedValue + "&year=" + ddlYear.SelectedValue);
        }
   
    }
}