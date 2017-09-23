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
    public partial class Withdraw1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(ERoles.Manager.ToString()))
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
                          select o.EmpID).First();
                Withdraw with = new Withdraw();
                with.Amount = amount;
                with.AmountW = amountW;
                with.Bank = bank;
                with.CheckNum = check;
                with.Date = DateTime.Now.Date;
                with.EmpID = emp;
                with.Notes = note;
                with.ToPerson = toPerson;
                club.Withdraws.AddObject(with);
                club.SaveChanges();
 
            }
            Response.Redirect("Default.aspx");

        }
    }
}