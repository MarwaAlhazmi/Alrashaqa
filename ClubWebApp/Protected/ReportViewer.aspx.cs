using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ClubWebApp.Protected
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(Request["type"]);
            int inv = String.IsNullOrEmpty(Request["id"])? 0: Convert.ToInt32(Request["id"]);
            DateTime date = string.IsNullOrEmpty(Request["date"]) ? DateTime.Now : Convert.ToDateTime(Request["date"]);
            int month = String.IsNullOrEmpty(Request["month"]) ? 0 : Convert.ToInt32(Request["month"]);
            int year = string.IsNullOrEmpty(Request["year"]) ? 0 : Convert.ToInt32(Request["year"]);
            DateTime from = string.IsNullOrEmpty(Request["from"]) ? DateTime.Now : Convert.ToDateTime(Request["from"]);
            DateTime to = string.IsNullOrEmpty(Request["to"]) ? DateTime.Now : Convert.ToDateTime(Request["to"]);
            using (ClubDBEntities club = new ClubDBEntities())
                 {
                    switch(type)
                    {
                        case 0:
                        
                            InvoiceCR report = new InvoiceCR();
                            report.Load(Server.MapPath("InvoiceCR.rpt"));
                        
                                var result = club.getInvoiceHeader(inv);
                                report.SetDataSource(result);
                                CrystalReportViewer1.ReportSource = report;
                                //CrystalReportViewer1.RefreshReport();
                       
                            break;
                        case 1:
                            var deposit = club.getDepositReport(inv);
                            DepositCR reportD = new DepositCR();
                            reportD.Load(Server.MapPath("DepositCR.rpt"));
                            reportD.SetDataSource(deposit);
                            CrystalReportViewer1.ReportSource = reportD;
                            break;
                        case 2:
                            var with = club.getWithReport(inv);
                            WithdrawCR reportW = new WithdrawCR();
                            reportW.Load(Server.MapPath("WithdrawCR.rpt"));
                            reportW.SetDataSource(with);
                            CrystalReportViewer1.ReportSource = reportW;
                            break;
                        case 3:
                             BuffetMovCR reportb = new BuffetMovCR();
                            reportb.Load(Server.MapPath("BuffetMovCR.rpt"));
                            reportb.SetDataSource(club.getBuffetExpenseReport(date));
                            CrystalReportViewer1.ReportSource = reportb;
                            break;
                        case 4:
                            DischargeCR reportd = new DischargeCR();
                            reportd.Load(Server.MapPath("DischargeCR.rpt"));
                            reportd.SetDataSource(club.getDischargeReport(inv));
                            CrystalReportViewer1.ReportSource = reportd;
                            break;
                        case 5:
                            EvaluationCR reporte = new EvaluationCR();
                            reporte.Load(Server.MapPath("EvaluationCR.rpt"));
                            reporte.SetDataSource(club.getEvaluationreport(inv));
                            CrystalReportViewer1.ReportSource = reporte;
                            break;
                        case 6:
                            TRequestCR reportt = new TRequestCR();
                            reportt.Load(Server.MapPath("TRequestCR.rpt"));
                            reportt.SetDataSource(club.getTRequestReport(inv));
                            CrystalReportViewer1.ReportSource = reportt;
                            break;
                        case 7:
                            var eand = club.getEandIReport(month, year, inv);
                            if (eand.Count() > 0)
                            {
                                EandICR reporti = new EandICR();
                                reporti.Load(Server.MapPath("EandICR.rpt"));
                                reporti.SetDataSource(eand);
                                CrystalReportViewer1.ReportSource = reporti;
                            }
                            else
                            {
                                lblError.Text = "لايوجد بيانات لعرضها";
                                lblError.Visible = true;
                            }
                            break;
                        case 8:
                            ExpenseCR reportx = new ExpenseCR();
                            reportx.Load(Server.MapPath("ExpenseCR.rpt"));
                            reportx.SetDataSource(club.getExpenseReport(date));
                            CrystalReportViewer1.ReportSource = reportx;
                            break;
                        case 9:
                            IncomeCR reportm = new IncomeCR();
                            reportm.Load(Server.MapPath("IncomeCR.rpt"));
                            reportm.SetDataSource(club.getIncomeReport(date));
                            CrystalReportViewer1.ReportSource = reportm;
                            break;
                        case 10:
                            MovCashCR reportv = new MovCashCR();
                            reportv.Load(Server.MapPath("MovCashCR.rpt"));
                            reportv.SetDataSource(club.getMovReportWithCash(date));
                            CrystalReportViewer1.ReportSource = reportv;
                            break;
                        case 11:
                            MovCR reportv1 = new MovCR();
                            reportv1.Load(Server.MapPath("MovCR.rpt"));
                            reportv1.SetDataSource(club.getMovReport(date, inv));
                            CrystalReportViewer1.ReportSource = reportv1; 
                            break;
                        case 12:
                             VisitCR report12 = new VisitCR();
                            report12.Load(Server.MapPath("VisitCR.rpt"));
                            report12.SetDataSource(club.getVisitReport(inv));
                            CrystalReportViewer1.ReportSource = report12;
                            break;
                        case 13:
                            BalanceMovCR reportb2 = new BalanceMovCR();
                            reportb2.Load(Server.MapPath("BuffetMovCR.rpt"));
                            reportb2.SetDataSource(club.getBuffetExpenseReport(date));
                            CrystalReportViewer1.ReportSource = reportb2;
                            break;
                        case 14:
                            BankCR bank = new BankCR();
                            bank.Load(Server.MapPath("BankCR.rpt"));
                            bank.SetDataSource(club.getBankStatemnet(from,to));
                            CrystalReportViewer1.ReportSource = bank;
                            break;
                        case 15:
                            TransCR tran = new TransCR();
                            tran.Load(Server.MapPath("TransCR.rpt"));
                            tran.SetDataSource(club.getTransReport(month,year));
                            CrystalReportViewer1.ReportSource = tran;
                            break;
                    }
                 }
        
        }
    }
}