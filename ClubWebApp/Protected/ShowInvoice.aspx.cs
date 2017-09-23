using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class ShowInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvoiceID"] != null)
            {
                
                int id = Convert.ToInt32(Session["InvoiceID"]);
                InvoiceCR report = new InvoiceCR();
                report.Load(Server.MapPath("InvoiceCR.rpt"));
                ClubDBEntities club = new ClubDBEntities();
                report.SetDataSource(club.getInvoiceHeader(id));
                CrystalReportViewer1.ReportSource = report;
            }
            else if (Session["WithID"] != null)
            {
                int id = Convert.ToInt32(Session["WithID"]);
                WithdrawCR report = new WithdrawCR();
                report.Load(Server.MapPath("WithdrawCR.rpt"));
                ClubDBEntities club = new ClubDBEntities();
                report.SetDataSource(club.getWithReport(id));
                CrystalReportViewer1.ReportSource = report;

            }
            else if (Session["depID"] != null)
            {
                int id = Convert.ToInt32(Session["depID"]);
                DepositCR report = new DepositCR();
                report.Load(Server.MapPath("DepositCR.rpt"));
                ClubDBEntities club = new ClubDBEntities();
                report.SetDataSource(club.getDepositReport(id));
                CrystalReportViewer1.ReportSource = report;
            }

        }
    }
}