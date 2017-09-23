using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class AddSub : System.Web.UI.Page
    {
        private static bool edit;
        private static Subscribtion sub;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEnumerable<Department> dep;
                using (ClubDBEntities club = new ClubDBEntities())
                {
                     dep = (from i in club.Departments
                           select i).ToList();
                }
                ddlDep.DataSource = dep;
                ddlDep.DataTextField = "Name";
                ddlDep.DataValueField = "DepID";
                ddlDep.DataBind();
                //if (Request["new"] != null)
                //{
                //    tbFile.Text = Request["new"].ToString();
                //    getName();

                //}
                if (Request["SubID"] != null)
                {
                    edit = true;
                    int subid = Convert.ToInt32(Request["SubID"]);
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var result = (from i in club.Subscribtions
                                  where i.SubID == subid
                                  select i).First();
                        sub = result;
                        tbFile.Text = result.ClientID.ToString();
                        getName();
                        ddlDep.SelectedValue = result.Service.DepID.ToString();
                        getDocSer();
                        ddlServices.SelectedValue = result.ServiceID.ToString();
                        //lblDoc.Visible = false;
                        //ddlDoc.Visible = false;
                        pnlMember.Enabled = false;
                        pnlService.Enabled = false;


                    }
                }
            }

        }

        protected void tbFile_TextChanged(object sender, EventArgs e)
        {
            getName();
        }
        private void getName()
        {
            if (!string.IsNullOrEmpty(tbFile.Text))
            {
                int id = Convert.ToInt32(tbFile.Text);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = (from c in club.Clients
                                  where c.ClientID == id
                                  select c.FirstName + " " + c.SecondName + " " + c.FamilyName).FirstOrDefault();
                    if (string.IsNullOrEmpty(result))
                    {
                        lblError.Visible = true;
                        pnlService.Visible = false;
                        lblError.Text = "خطأ في رقم الملف";
                        lblNameValue.Text = "";
                    }
                    else
                    {
                        lblError.Visible = false;
                        lblNameValue.Text = result;
                        pnlService.Visible = true;
                    }
                }
            }
        }

        protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDocSer();

        }
        
        private void getDocSer()
        {
            if (ddlDep.SelectedIndex != 0)
            {
                // employees + services
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    int depID = Convert.ToInt32(ddlDep.SelectedValue);
                    var emp = club.Employees.Where(a => a.Departments.Any(b => b.DepID == depID));
                    //ddlDoc.DataSource = emp;
                    //ddlDoc.DataTextField = "Name";
                    //ddlDoc.DataValueField = "EmpID";
                    //ddlDoc.DataBind();


                    // services
                    var service = (from n in club.Services
                                   where n.DepID == depID && n.Sub == true && n.Deleted == false
                                   select n).ToList();
                    ddlServices.DataSource = service;
                    ddlServices.DataTextField = "Name";
                    ddlServices.DataValueField = "ServiceID";
                    ddlServices.DataBind();
                    switch (ddlDep.SelectedValue)
                    {
                        case "1":
                            pnlDetails.Visible = true;
                            pnlInt.Visible = false;
                            pnlNut.Visible = true;
                            if (edit)
                            {
                                tbMeasurements.Text = sub.Measurements;
                                tbDiagnosis.Text = sub.Diagnosis;
                                tbHistory.Text = sub.History;
                                var nut = (from i in club.NutSubs
                                          where i.SubID == sub.SubID
                                          select i).First();
                                tbFat.Text = nut.Fat;
                                tbHieght.Text = nut.Hight;
                                tbWeight.Text = nut.Weight;
                            }
                            break;
                        case "2":
                            pnlDetails.Visible = true;
                            pnlInt.Visible = true;
                            pnlNut.Visible = false;
                            if (edit)
                            {
                                tbMeasurements.Text = sub.Measurements;
                                tbDiagnosis.Text = sub.Diagnosis;
                                tbHistory.Text = sub.History;
                                var Int = (from i in club.IntSubs
                                          where i.SubID == sub.SubID
                                          select i).First();
                                tbBPressure.Text = Int.BloodPressure;
                                tbBSugar.Text = Int.BloodSugar;
                            }
                            break;
                        case "3":
                            pnlDetails.Visible = true;
                            pnlInt.Visible = false;
                            pnlNut.Visible = false;
                            if (edit)
                            {
                                tbMeasurements.Text = sub.Measurements;
                                tbDiagnosis.Text = sub.Diagnosis;
                                tbHistory.Text = sub.History;
                            }
                            break;
                        default:
                            pnlDetails.Visible = false;
                            pnlInt.Visible = false;
                            pnlNut.Visible = false;
                            break;
                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = (from o in club.Subscribtions
                                  where o.SubID == sub.SubID
                                  select o).First();
                    result.Measurements = tbMeasurements.Text;
                    result.Diagnosis = tbDiagnosis.Text;
                    result.History = tbHistory.Text;
                    club.SaveChanges();
                    switch (sub.Service.DepID)
                    {
                        case 1:
                            var nut = (from o in club.NutSubs
                                      where o.SubID == sub.SubID
                                      select o).First();
                            nut.Weight = tbWeight.Text;
                            nut.Hight = tbHieght.Text;
                            nut.Fat = tbFat.Text;
                            club.SaveChanges();
                            break;
                        case 2:
                            var iint = (from o in club.IntSubs
                                        where o.SubID == sub.SubID
                                        select o).First();
                            iint.BloodSugar = tbBSugar.Text;
                            iint.BloodPressure = tbBPressure.Text;
                            club.SaveChanges();
                            break;
                        case 5:
                            club.SaveChanges();
                            break;
                    }

                }
                string Message = "تم حفظ التعديلات";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true); 
            }
            else
            {
                lblError.Visible = false;
                int id = Convert.ToInt32(tbFile.Text);
                //int empID = Convert.ToInt32(ddlDoc.SelectedValue);
                int service = Convert.ToInt32(ddlServices.SelectedValue);
                if (ddlDep.SelectedIndex != 0)
                {
                    int subId;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var serviceDays = (from o in club.Services
                                           where o.ServiceID == service
                                           select o.TotalDays).First();
                        Subscribtion sub = new Subscribtion();
                        sub.ClientID = id;
                        sub.Date = DateTime.Now.Date;
                        sub.LeftDays = serviceDays;
                        sub.ServiceID = service;
                        sub.AttDays = 0;
                        sub.SubDays = serviceDays;
                        club.Subscribtions.AddObject(sub);
                        club.SaveChanges();
                        subId = sub.SubID;
                        switch (ddlDep.SelectedValue)
                        {
                            case "1":
                                sub.Diagnosis = tbDiagnosis.Text;
                                sub.Measurements = tbMeasurements.Text;
                                sub.History = tbHistory.Text;
                                NutSub nut = new NutSub();
                                nut.Fat = tbFat.Text;
                                nut.Weight = tbWeight.Text;
                                nut.Hight = tbHieght.Text;
                                nut.SubID = subId;
                                club.NutSubs.AddObject(nut);
                                club.SaveChanges();
                                break;
                            case "2":
                                sub.Diagnosis = tbDiagnosis.Text;
                                sub.Measurements = tbMeasurements.Text;
                                sub.History = tbHistory.Text;
                                IntSub Int = new IntSub();
                                Int.BloodPressure = tbBPressure.Text;
                                Int.BloodSugar = tbBSugar.Text;
                                Int.SubID = subId;
                                club.IntSubs.AddObject(Int);
                                club.SaveChanges();
                                break;
                            case "5":
                                sub.Diagnosis = tbDiagnosis.Text;
                                sub.Measurements = tbMeasurements.Text;
                                sub.History = tbHistory.Text;
                                club.SaveChanges();
                                break;
                        }
                    }
                    // redirect to the invoice
                    //Response.Redirect("Invoice.aspx?subID=" + subId + "&empID=" + empID);
                    // inform the user
                    string msg = " تم اضافة الاشتراك  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", msg), true);
                }
                else
                {
                    lblError.Text = "الرجاء اختيار القسم";
                    lblError.Visible = true;
                }
            }
        }
    }
}