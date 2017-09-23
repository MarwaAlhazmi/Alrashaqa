using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using System.Web.Security;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class PhysicalRequest : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-GB");
        private static int EID;
        private static bool saved;
        private static bool show;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.InternalS.ToString()) || Roles.IsUserInRole(ERoles.Nutritionist.ToString()) || Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.PhysicalS.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    // if in 
                    
                    if (Roles.IsUserInRole(ERoles.InternalS.ToString()) || Roles.IsUserInRole(ERoles.Manager.ToString()))
                    {
                        if (Request["show"] != null)
                        {
                            show = true;
                            lblInfo.Visible = true;
                        }
                    }

                    if (Roles.IsUserInRole(ERoles.PhysicalS.ToString()) || Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.InternalS.ToString()) || Roles.IsUserInRole(ERoles.Manager.ToString()))
                    {
                        if (Request["ID"] != null)
                        {
                            int id = Convert.ToInt32(Request["ID"]);
                            EID = id;
                            using (ClubDBEntities club = new ClubDBEntities())
                            {
                                var result = club.getTRequestReport(id).FirstOrDefault();
                                tbDia.Text = result.Diagnosis;
                                tbGoals.Text = result.Goals;
                                tbPrecaution.Text = result.Precaution;
                                tbName.Text = result.PatientName;
                                tbPhone.Text = result.Phone;
                                tbNation.Text = result.Nation;
                                tbDOB.Text = result.DOB;
                                tbID.Text = result.FileID;
                                tbDate.Text = result.Date;
                                readOnly();
                            }
                        }
                    }
                    

                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void tbID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbID.Text))
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    int id = Convert.ToInt32(tbID.Text);
                    var result = (from o in club.Clients
                                  where o.ClientID == id
                                  select o).FirstOrDefault();
                    if (result != null)
                    {
                        tbDOB.Text = result.DOB.ToString();
                        tbName.Text = result.FullName();
                        tbNation.Text = result.Nationality;
                        tbPhone.Text = result.Phone.ToString();
                        lblError.Visible = false;
                        pnlClient.Visible = true;
                        if (!show)
                        {
                            pnlInfo.Visible = true;
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "File ID does not exist";
                        pnlClient.Visible = false;
                        pnlInfo.Visible = false;
                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            string Message = " Information have been saved  ";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
        }

        private void Save()
        {
            DateTime date = Convert.ToDateTime(tbDate.Text, cul);
            int id = Convert.ToInt32(tbID.Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                // get employee
                string name = User.Identity.Name;
                int empID = (from o in club.Employees
                             where o.UserName == name
                             select o.EmpID).First();

                TReaquest re = new TReaquest();
                re.ClientID = id;
                re.EmployeeID = empID;
                re.Diagnosis = tbDia.Text;
                re.Goals = tbGoals.Text;
                re.Precautions = tbPrecaution.Text;
                re.Date = date;
                club.TReaquests.AddObject(re);
                club.SaveChanges();
                EID = re.ID;
                saved = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                Save();
            }
            // 6
            Response.Redirect("ReportViewer.aspx?type=6&id="+EID);
            //TRequestCR report = new TRequestCR();
            //report.Load(Server.MapPath("TRequestCR.rpt"));
            //using (ClubDBEntities club = new ClubDBEntities())
            //{
            //    report.SetDataSource(club.getTRequestReport(EID));
            //    string printer = ClubWebApp.Properties.Settings.Default.DefaultPrinter;
            //    report.PrintOptions.PrinterName = printer;
            //    report.PrintToPrinter(1, false, 0, 0);
            //}
        }

        private void readOnly()
        {
            tbID.ReadOnly = true;
            //tbDate.ReadOnly = true;
            tbName.ReadOnly = true;
            tbPhone.ReadOnly = true;
            tbDOB.ReadOnly = true;
            tbNation.ReadOnly = true;
            tbDia.ReadOnly = true;
            tbGoals.ReadOnly = true;
            pnlClient.Visible = true;
            pnlInfo.Visible = true;
            btnSave.Visible = false;
            saved = true;
        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbID.Text) && show)
            {
                DateTime date = Convert.ToDateTime(tbDate.Text, cul);
                int id = Convert.ToInt32(tbID.Text);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var re = (from o in club.TReaquests
                              where o.ClientID == id && o.Date == date
                              select o).FirstOrDefault();
                    if (re == null)
                    {
                        lblError.Visible = true;
                        lblError.Text = "No Data Found. Try another Date";
                        pnlInfo.Visible = false;
                    }
                    else
                    {
                        lblError.Visible = false;
                        tbGoals.Text = re.Goals;
                        tbDia.Text = re.Diagnosis;
                        tbPrecaution.Text = re.Precautions;
                        EID = id;
                        readOnly();
                    }
                }
            }
        }
    }
}