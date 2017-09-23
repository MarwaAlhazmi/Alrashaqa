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
            DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
            Response.Redirect("ReportViewer.aspx?type=9&date="+date);
            //IncomeCR report = new IncomeCR();
            //report.Load(Server.MapPath("IncomeCR.rpt"));
            //ClubDBEntities club = new ClubDBEntities();
            //report.SetDataSource(club.getIncomeReport(date));
            //string printer = Properties.Settings.Default.DefaultPrinter;
            //report.PrintOptions.PrinterName = printer;
            //report.PrintToPrinter(1, false, 0, 0);
        }

        protected void gvIncome_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    DateTime date = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(dllMonth.SelectedValue), 1);
                    var re = club.Deposits.Where(a => a.Date.Month == date.Month && a.Date.Year == date.Year).Sum(a=>(decimal?)a.Amount);
                    var with = club.Withdraws.Where(a => a.Date.Month == date.Month && a.Date.Year == date.Year && a.BankID == null).Sum(a => (decimal?)a.Amount);

                    e.Row.Cells[3].Text = "المجموع";
                    e.Row.Cells[2].Text = Convert.ToDecimal(re).ToString("0.00");
                    e.Row.Cells[1].Text = Convert.ToDecimal(with).ToString("0.00");
                    e.Row.Cells[0].Text = Convert.ToDecimal(re - with).ToString("0.00");
                }
            }
        }
    }
}