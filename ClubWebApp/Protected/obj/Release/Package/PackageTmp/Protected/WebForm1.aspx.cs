using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                GridView1.DataSource = club.getServices();
                GridView1.DataBind();
            }

            //ReportDocument report = new ReportDocument();
            //report.Load(Server.MapPath("DischargeCR.rpt"));
            //using (ClubDBEntities club = new ClubDBEntities())
            //{
            //    DateTime date = new DateTime(2011, 12, 29);
            //    report.SetDataSource(club.getDischargeReport(1));
            //    CrystalReportViewer1.ReportSource = report;
            //}

            
            
            //ReportDocument report = new ReportDocument();
            //report.Load(Server.MapPath("test.rpt"));
            //ClubDBEntities club = new ClubDBEntities();
            //report.SetDataSource(club.getInvoiceHeader(102));
            //CrystalReportViewer1.ReportSource = report;
            //Roles.CreateRole(ERoles.InternalS.ToString());
            //Roles.CreateRole(ERoles.Manager.ToString());
            //Roles.CreateRole(ERoles.Nutritionist.ToString());
            //Roles.CreateRole(ERoles.PhysicalS.ToString());
            //Roles.CreateRole(ERoles.Receptionist.ToString());
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Reference2.doc");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Message = " تم الحذف  ";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                   
        }

    }
}