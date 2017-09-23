using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;

namespace ClubWebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        private static int empID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var user = Membership.GetUser();
                if (!Roles.IsUserInRole(user.UserName, ERoles.Manager.ToString()))
                {
                    Response.Redirect("~/Error.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                            using (ClubDBEntities club = new ClubDBEntities())
                            {
                                var emps = (from o in club.Employees
                                            where o.UserName == null || o.UserName == ""
                                            select o).ToList();
                                if (emps.Count == 0)
                                {
                                    // you need to add emps first
                                    RegisterUser.Enabled = false;
                                    lblError.Text = "اضف ملف للموظف قبل انشاء حساب دخول";
                                    lblError.Visible = true;
                                }
                                ddlName.DataSource = emps;
                                ddlName.DataTextField = "Name";
                                ddlName.DataValueField = "EmpID";
                                ddlName.DataBind();
                            }
                        
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {

        
                string role = ddlRoles.SelectedValue;
                Roles.AddUserToRole(RegisterUser.UserName, role);
            
            //DropDownList ddlname = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ddlName");
            TextBox tbU = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            if ((tbU != null))
            {
                string username = tbU.Text;
                empID = Convert.ToInt32(ddlName.SelectedValue);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var emp = (from o in club.Employees
                               where o.EmpID == empID
                               select o).First();
                    emp.UserName = username;
                    club.SaveChanges();
                }
            }
            //Response.Redirect("Default.aspx");
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (String.IsNullOrEmpty(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }


    }
}
