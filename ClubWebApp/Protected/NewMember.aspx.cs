using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ClubWebApp.Protected;


namespace ClubWebApp
{
    public partial class NewMember : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-GB");
        private void reset()
        {
            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbLastName.Text = "";
            tbFamilyName.Text = "";
            tbPhone.Text = "";
            tbID.Text = "";
            tbNation.Text = "";
            tbDOB.Text = "";
            tbRefferedFrom.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            tbFirstName.Focus();
            CalendarExtender1.SelectedDate = DateTime.Now;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClubDBEntities club = new ClubDBEntities();

            long? id = null;
            int? i = null;

            Client client = new Client()
            {
                FirstName = tbFirstName.Text,
                SecondName = tbSecondName.Text,
                LastName = tbLastName.Text,
                FamilyName = tbFamilyName.Text,
                DOB = string.IsNullOrEmpty(tbDOB.Text) ? i : Convert.ToInt32(tbDOB.Text),
                Nationality = tbNation.Text,
                IDNumber = string.IsNullOrEmpty(tbID.Text) ? id : Convert.ToInt64(tbID.Text),
                Phone = string.IsNullOrEmpty(tbPhone.Text) ? id : Convert.ToInt64(tbPhone.Text),
                Marital = rbMarital.SelectedValue,
                RefferedFrom = tbRefferedFrom.Text,
                RefferedDate = Convert.ToDateTime(tbDate.Text,cul).Date,
                Status = Status.Inactive.toString(),
                Gardian = tbGardian.Text,
                Twon = tbTown.Text,
                Relative = tbRelative.Text,
            };

            club.AddToClients(client);
            club.SaveChanges();
            //string Message = " تمت اضافة العضوة  ";
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);

            Response.Redirect("Invoice.aspx?New=" + client.ClientID);

        }


    }
}
