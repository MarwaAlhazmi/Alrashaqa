using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class EvaluationSheet : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-GB");
        private static int EID;
        private static bool saved;
        private static bool show;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.PhysicalS.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    if (Request["ID"] != null)
                    {
                        show = true;
                        lblInfo.Visible = false;
                        int id = Convert.ToInt32(Request["ID"]);
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            var result= club.getEvaluationreport(id).First();
                            tbID.Text = result.FileID;
                            tbDate.Text = result.Date;
                            tbDOB.Text = result.DOB.ToString();
                            tbName.Text = result.PatientName;
                            tbNation.Text = result.Nation;
                            tbPhone.Text = result.Phone;
                            tbObjective.Text = result.Objective;
                            tbHistory.Text = result.History;
                            tbAssess.Text = result.Assessment;
                            tbGoals.Text = result.Goals;
                            tbTreat.Text = result.Treatment;
                            tbDia.Text = result.Diagnosis;
                            
                            readOnly();
                            EID = id;
                            
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

                Evaluation eval = new Evaluation();
                eval.ClientID = id;
                eval.EmployeeID = empID;
                eval.Assessment = tbAssess.Text;
                eval.Date = date;
                eval.Diagnosis = tbDia.Text;
                eval.Goals = tbGoals.Text;
                eval.History = tbHistory.Text;
                eval.Objective = tbObjective.Text;
                eval.Treatment = tbTreat.Text;
                club.Evaluations.AddObject(eval);
                club.SaveChanges();
                EID = eval.ID;
                saved = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                Save();
            }
            Response.Redirect("ReportViewer.aspx?type=5&id="+EID);
            //EvaluationCR report = new EvaluationCR();
            //report.Load(Server.MapPath("EvaluationCR.rpt"));
            //using (ClubDBEntities club = new ClubDBEntities())
            //{
            //    report.SetDataSource(club.getEvaluationreport(EID));
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
            tbAssess.ReadOnly = true;
            tbObjective.ReadOnly = true;
            tbHistory.ReadOnly = true;
            tbGoals.ReadOnly = true;
            tbTreat.ReadOnly = true;
            pnlClient.Visible = true;
            pnlInfo.Visible = true;
            btnSave.Visible = false;
            saved = true;
        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbID.Text) && show)
            //{
            //    DateTime date = Convert.ToDateTime(tbDate.Text, cul);
            //    int id = Convert.ToInt32(tbID.Text);
            //    using (ClubDBEntities club = new ClubDBEntities())
            //    {
            //        var re = (from o in club.Evaluations
            //                  where o.ClientID == id && o.Date == date
            //                  select o).FirstOrDefault();
            //        if (re == null)
            //        {
            //            lblError.Visible = true;
            //            lblError.Text = "No Data Found. Try another Date";
            //            pnlInfo.Visible = false;
            //        }
            //        else
            //        {
            //            lblError.Visible = false;
            //            tbObjective.Text = re.Objective;
            //            tbHistory.Text = re.History;
            //            tbAssess.Text = re.Assessment;
            //            tbGoals.Text = re.Goals;
            //            tbTreat.Text = re.Treatment;
            //            tbDia.Text = re.Diagnosis;
            //            readOnly();
            //        }
            //    }
            //}
        }
    }
}