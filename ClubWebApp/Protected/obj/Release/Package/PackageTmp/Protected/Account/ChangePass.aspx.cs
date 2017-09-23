using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClubWebApp.Account
{
    public partial class ChangePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Roles.IsUserInRole(ERoles.Manager.ToString()))
                {
                    ddlUsers.DataSource = Membership.GetAllUsers();
                    ddlUsers.DataBind();
                    
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            string username = ddlUsers.SelectedItem.Text;
            string oldpass = CurrentPassword.Text;
            string newpass = NewPassword.Text;
            var user = Membership.GetUser(username);
            user.ChangePassword(oldpass, newpass);
            Success();
            reset();
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedIndex != 0)
            {
                pnlPass.Visible = true;
            }
                
            
        }
        private void Success()
        {
            lblError.Text = "تم تغيير كلمة المرور بنجاح";
        }
        private void reset()
        {
            pnlPass.Visible = false;
            ddlUsers.SelectedIndex = 0;
            CurrentPassword.Text = "";
            NewPassword.Text = "";
            ConfirmNewPassword.Text = "";
        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}