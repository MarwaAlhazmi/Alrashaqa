using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using System.IO;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class DietSystem : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-GB");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Nutritionist.ToString()) || Roles.IsUserInRole(ERoles.InternalS.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("Diet"));
                    FileInfo[] files = dir.GetFiles("*.doc");
                    ddlDep.DataSource = files;
                    ddlDep.DataTextField = "Name";
                    ddlDep.DataValueField = "Name";
                    ddlDep.DataBind();

                    foreach (System.IO.FileInfo fi in files)
                    {
                        string fileName = fi.Name;
                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string file = ddlDep.SelectedValue;
            Response.Redirect("Diet\\"+file);
        }


    }
}