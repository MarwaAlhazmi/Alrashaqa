using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

namespace ClubWebApp
{
    public partial class Withdraw1 : System.Web.UI.Page
    {
        private static int withID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var re = club.Departments.ToList();
                        ddlDep.DataSource = re;
                        ddlDep.DataTextField = "Name";
                        ddlDep.DataValueField = "DepID";
                        ddlDep.DataBind();
                        tbDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void rbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbType.SelectedIndex == 0)
            {
                pnlBank.Visible = false;
            }
            else
            {
                pnlBank.Visible = true;
                tbDate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (withID != 0)
            {
                Response.Redirect("ReportViewer.aspx?type=2&id=" + withID);
            }
        }

        protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDep.SelectedIndex != 0)
            {
                //if (ddlDep.SelectedIndex == 1)
                //{
                //    using (ClubDBEntities club = new ClubDBEntities())
                //    {
                //        var re = from p in club.WithTypes
                //                 where p.Department == null
                //                 select p; 
                //        lbType.Visible = true;
                //        lbType.DataSource = re;
                //        lbType.DataValueField = "ID";
                //        lbType.DataTextField = "Name";
                //        lbType.DataBind();
                //    }
                //}
                //else
                //{
                    int depid = Convert.ToInt32(ddlDep.SelectedValue);
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var re = from o in club.WithTypes
                                 where o.Department == depid
                                 select o;
                        lbType.DataSource = re;
                        lbType.DataValueField = "ID";
                        lbType.DataTextField = "Name";
                        lbType.DataBind();
                        lbType.Visible = true;
                    }
                //}
            }
        }


     

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string toPerson = tbTo.Text;
            decimal amount = Convert.ToDecimal(tbAmount.Text);
            string amountW = tbAmountW.Text;
            string note = tbNotes.Text;
            int? type = null;
            bool bank = false;

            if (ddlDep.SelectedIndex == 0)
            {
                lblError.Text = "لم يتم اختيار نوع الفاتورة";
                lblError.Visible = true;
            }
            else
            {
                type = Convert.ToInt32(lbType.SelectedValue);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    string username = User.Identity.Name;
                    var emp = (from o in club.Employees
                               where o.UserName == username
                               select o.EmpID).First();
                    Withdraw with = new Withdraw();
                    with.Amount = amount;
                    with.AmountW = amountW;
                    with.WithType = type;
                    with.Date = Convert.ToDateTime(tbDate1.Text);//Change this
                    with.EmpID = emp;
                    with.Notes = note;
                    with.ToPerson = toPerson;
                    club.Withdraws.AddObject(with);
                    club.SaveChanges();
                    if (rbType.SelectedIndex == 1)
                    {
                        DateTime date = Convert.ToDateTime(tbDate.Text);
                        BankTran bb = new BankTran();
                        bb.Date = date;
                        bb.Amount = amount * -1;
                        bb.Note = toPerson;
                        with.Date = Convert.ToDateTime(tbDate.Text);
                        with.CheckNum = string.IsNullOrEmpty(tbCheck.Text)? 0:Convert.ToInt64(tbCheck.Text);
                        with.BankName = tbBank.Text;
                        club.BankTrans.AddObject(bb);
                        with.BankID = bb.ID;
                        club.SaveChanges();
                    }
                    withID = with.ID;
                    string Message = " تم حفظ المعلومات  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                    
                    // print the bill
                    //var result = club.getWithReport(with.ID);
                    //WithdrawCR report = new WithdrawCR();
                    //report.Load(Server.MapPath("WithdrawCR.rpt"));
                    //report.SetDataSource(result);
                    //string printer = "";
                    //report.PrintOptions.PrinterName = ClubWebApp.Properties.Settings.Default.InvoicePrinter;
                    //report.PrintOptions.PrinterName = printer;
                    //report.PrintToPrinter(1, false, 0, 0);

                }

            }
        }

       
    }
}