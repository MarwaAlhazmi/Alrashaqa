using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class Search : System.Web.UI.Page
    {
        private static bool clicked;
        private static string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                EntityDataSource1.Where = query;
                EntityDataSource1.DataBind();
            }
            else
            {
                clicked = false;
                if (Request["ClientID"] != null)
                {
                    int id = Convert.ToInt32(Request["ClientID"]);
                    dllSearch.SelectedIndex = 1;
                    setUI();
                    tbSearch.Text = id.ToString();
                    getData();
                }
            }

        }

        protected void dllSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            setUI();
        }

        private void setUI()
        {
            switch (dllSearch.SelectedIndex)
            {
                case 0:
                    tbSearch.Visible = true;
                    reNumber.Visible = false;
                    tbSearch_CalendarExtender.Enabled = false;
                    tbSearch.Text = "";
                    tbSearch.Focus();
                    break;
                case 1:
                case 3:
                case 4:
                    tbSearch.Visible = true;
                    reNumber.Visible = true;
                    tbSearch_CalendarExtender.Enabled = false;
                    tbSearch.Text = "";
                    tbSearch.Focus();
                    break;
                case 2:
                    tbSearch.Visible = true;
                    reNumber.Visible = false;
                    tbSearch_CalendarExtender.Enabled = true;
                    tbSearch.Text = "";
                    tbSearch.Focus();
                    break;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clicked = true;
            getData();
        }

        private void getData()
        {
            switch (dllSearch.SelectedIndex)
            {
                case 0:
                    // member name
                    query = "it.FirstName +' '+ it.SecondName +' '+ it.LastName +' '+ it.FamilyName LIKE '%' + @name + '%' ";
                    EntityDataSource1.WhereParameters.Clear();
                    EntityDataSource1.WhereParameters.Add("name", tbSearch.Text);
                    EntityDataSource1.WhereParameters[0].Type = TypeCode.String;

                    break;
                case 1:
                    // file id

                    query = "it.ClientID = @id";
                    EntityDataSource1.WhereParameters.Clear();
                    EntityDataSource1.WhereParameters.Add("id", tbSearch.Text);
                    EntityDataSource1.WhereParameters[0].Type = TypeCode.Int32;
                    
                    
                    break;
                case 2:
                    // admission date
                    query = "it.RefferedDate = @date";
                    EntityDataSource1.WhereParameters.Clear();
                    EntityDataSource1.WhereParameters.Add("date", tbSearch.Text);
                    EntityDataSource1.WhereParameters[0].Type = TypeCode.DateTime;
                    break;
                case 3:
                    //phone number
                    query = "it.Phone = @phone";
                    EntityDataSource1.WhereParameters.Clear();
                    EntityDataSource1.WhereParameters.Add("phone", tbSearch.Text);
                    EntityDataSource1.WhereParameters[0].Type = TypeCode.Int64;
                    break;
                case 4:
                    //result = club.getClinetsByID(tbSearch.Text);
                    //ID number
                    query = "it.IDNumber = @id";
                    EntityDataSource1.WhereParameters.Clear();
                    EntityDataSource1.WhereParameters.Add("id", tbSearch.Text);
                    EntityDataSource1.WhereParameters[0].Type = TypeCode.Int64;
                    break;
            }
            EntityDataSource1.Where = query;
            EntityDataSource1.DataBind();
            fvResult.DataBind();
        }
                    
   

        protected void fvResult_DataBound(object sender, EventArgs e)
        {
           
        }

        protected void fvResult_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            string clientID = "";
            Label lbl = (Label)fvResult.FindControl("ClientIDLabel");
            if (lbl != null)
            {
               clientID= lbl.Text;
            }
            switch (e.CommandName)
            {
                case "Visit":
                case "SSub":
                    Response.Redirect("Visit.aspx?ClientID="+ clientID);
                    break;
                //case "Sub":
                //    Response.Redirect("AddSub.aspx?new="+clientID);
                //    // create a new sub
                //    break;
            }
        }

        protected void EntityDataSource1_Selected(object sender, EntityDataSourceSelectedEventArgs e)
        {
            if (e.TotalRowCount == 0 && clicked)
            {
                lblError.Visible = true;
                lblError.Text = "ملف غير موجود";
            }
            else
            {
                lblError.Visible = false;
            }
        }










    }
}