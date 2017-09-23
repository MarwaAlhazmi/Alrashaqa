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
    public partial class EandI : System.Web.UI.Page
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

                    // dep
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var re = (from o in club.Departments
                                 select o).ToList();
                        ddlDep.DataSource = re;
                        ddlDep.DataTextField = "Name";
                        ddlDep.DataValueField = "DepID";
                        ddlDep.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("Error");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(dllMonth.SelectedValue);
            int year =  Convert.ToInt32(ddlYear.SelectedValue);
            int dep = Convert.ToInt32(ddlDep.SelectedValue);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.getEandIReport(month, year, dep);
                if (result.Count() > 0)
                {
                    EandICR report = new EandICR();
                    report.Load(Server.MapPath("EandICR.rpt"));
                    report.SetDataSource(result);
                    CrystalReportViewer1.ReportSource = report;
                    lblError.Visible = false;
                    btnPrint.Visible = true;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "لايوجد بيانات لعرضها";
                    btnPrint.Visible = false;
                }
                pnlData.Visible = true;

            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
             int month = Convert.ToInt32(dllMonth.SelectedValue);
            int year =  Convert.ToInt32(ddlYear.SelectedValue);
            int dep = Convert.ToInt32(ddlDep.SelectedValue);
            Response.Redirect("ReportViewer.aspx?type=7&id="+dep+"&month="+month+"&year="+year);
            //using (ClubDBEntities club = new ClubDBEntities())
            //{
            //    var result = club.getEandIReport(month, year, dep);
            //    if (result.Count() > 0)
            //    {
            //        EandICR report = new EandICR();
            //        report.Load(Server.MapPath("EandICR.rpt"));
            //        report.SetDataSource(result);
            //        string printer = Properties.Settings.Default.DefaultPrinter;
            //        report.PrintOptions.PrinterName = printer;
            //        report.PrintToPrinter(1, false, 0, 0);
            //    }
            //}
           
        }
    }
}