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
    public partial class Bank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                
            }
            else
            {
                Response.Redirect("Error");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
            DateTime from = Convert.ToDateTime(tbFrom.Text);
            DateTime to = Convert.ToDateTime(tbTo.Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.getBankStatemnet(from,to);
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
            //DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
            DateTime from = Convert.ToDateTime(tbFrom.Text);
            DateTime to = Convert.ToDateTime(tbTo.Text);
            Response.Redirect("ReportViewer.aspx?type=14&from="+from+"&to="+to);
            //IncomeCR report = new IncomeCR();
            //report.Load(Server.MapPath("IncomeCR.rpt"));
            //ClubDBEntities club = new ClubDBEntities();
            //report.SetDataSource(club.getIncomeReport(date));
            //string printer = Properties.Settings.Default.DefaultPrinter;
            //report.PrintOptions.PrinterName = printer;
            //report.PrintToPrinter(1, false, 0, 0);
        }

    
    }
}