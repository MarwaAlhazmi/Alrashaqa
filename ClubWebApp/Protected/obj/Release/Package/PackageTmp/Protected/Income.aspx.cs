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
    public partial class Income : System.Web.UI.Page
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
            DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.getIncomeReport(date);
                gvIncome.DataSource = result;
                gvIncome.DataBind();
                pnlData.Visible = true;
            }
        }

        protected void gvIncome_DataBound(object sender, EventArgs e)
        {
            if (gvIncome.Rows.Count <= 0)
            {
                lblError.Visible = true;
                btnPrint.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                btnPrint.Visible = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("IncomeCR.rpt"));
            ClubDBEntities club = new ClubDBEntities();
            DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
            report.SetDataSource(club.getIncomeReport(date));
            string printer = Properties.Settings.Default.DefaultPrinter;
            report.PrintOptions.PrinterName = printer;
            report.PrintToPrinter(1, false, 0, 0);
        }
    }
}