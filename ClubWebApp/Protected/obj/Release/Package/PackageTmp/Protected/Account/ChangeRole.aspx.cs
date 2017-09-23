using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClubWebApp.Account
{
    public partial class ChangeRole : System.Web.UI.Page
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
                else
                {
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbRoles.SelectedIndex != 0)
            {
                pnlPass.Visible = true;
                string username = ddlUsers.SelectedItem.Text;
                rbRoles.SelectedValue = Roles.GetRolesForUser(username).First();
            }
            else
            {
                pnlPass.Visible = false;
            }

        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            string username = ddlUsers.SelectedItem.Text;
            string role = rbRoles.SelectedValue;
            string oldrole = Roles.GetRolesForUser(username).FirstOrDefault();
            if (!string.IsNullOrEmpty(oldrole))
            {
                Roles.RemoveUserFromRole(username, oldrole);
            }
            Roles.AddUserToRole(username, role);
                        
        }
    }
}