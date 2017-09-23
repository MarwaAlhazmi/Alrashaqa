using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class Deposit1 : System.Web.UI.Page
    {
        private static int invID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        string ii = User.Identity.Name;
                        var name = club.Employees.Where(a => a.UserName == ii).Select(o => o.Name).First();
                        tbTo.Text = name;
                    }
                    if (Request["Inv"] != null)
                    {
                        int inv = Convert.ToInt32(Request["Inv"]);
                        invID = inv;
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            var result = club.InvoiceHeaders.Where(a => a.InvID == inv).First();
                            tbFrom.Text = result.Client.FullName();
                            tbAmount.Text = (result.FinalAmount - club.Deposits.Where(a => a.InvID == inv).Sum(a => a.Amount)).ToString("0.00");
                            tbNotes.Text = result.Notes;
                        }
                    }
                    else
                    {
                        invID = 0;
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
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string toPerson = tbTo.Text;
            
            decimal amount = Convert.ToDecimal(tbAmount.Text);
            string amountW = tbAmountW.Text;
            string note = tbNotes.Text;
            long? check = null;
            string bank= "";

            if (pnlBank.Visible)
            {
                check = Convert.ToInt64(tbCheck.Text);
                bank = tbBank.Text;
            }
            using (ClubDBEntities club = new ClubDBEntities())
            {
                string username = User.Identity.Name;
                var emp = (from o in club.Employees
                          where o.UserName == username
                          select o).First();
                Deposit deposit = new Deposit();
                deposit.Amount = amount;
                deposit.AmountW = amountW;
                deposit.Bank = bank;
                deposit.CheckNum = check;
                deposit.Date = DateTime.Now.Date;
                deposit.Notes = note;
                deposit.Employee = toPerson;
                deposit.FromPerson = tbFrom.Text;
                deposit.InvID = invID;
                club.Deposits.AddObject(deposit);
                club.SaveChanges();
 
            }
            Response.Redirect("Default.aspx");
        }
        
        protected void tbInv_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbInv.Text))
            {
                int inv = Convert.ToInt32(tbInv.Text);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var re = (from o in club.InvoiceHeaders
                              where o.InvID == inv
                              select o).FirstOrDefault();
                    if (re == null)
                    {
                        lblError.Text = "خطأ في رقم الفاتورة";
                        lblError.Visible = true;
                        pnlDeposit.Visible = false;
                    }
                    else
                    {
                        pnlDeposit.Visible = true;
                        lblError.Visible = false;
                        invID = inv;
                    }
                }
            }
        }
    }
}