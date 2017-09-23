using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && AdminTable != null && RecepTable != null && PhysicalTable != null && NutTabel != null)
            {
                string role = Roles.GetRolesForUser().First();
                switch (role)
                {
                    case "Manager":
                        AdminTable.Visible = true;
                        RecepTable.Visible = false;
                        PhysicalTable.Visible = false;
                        NutTabel.Visible = false;
                        break;
                    case "Receptionist":
                        AdminTable.Visible = false;
                        RecepTable.Visible = true;
                        PhysicalTable.Visible = false;
                        NutTabel.Visible = false;
                        break;
                    case "PhysicalS":
                        AdminTable.Visible = false;
                        RecepTable.Visible = false;
                        PhysicalTable.Visible = true;
                        NutTabel.Visible = false;
                        break;
                    case "Nutritionist":
                    case "InternalS":
                        AdminTable.Visible = false;
                        RecepTable.Visible = false;
                        PhysicalTable.Visible = false;
                        NutTabel.Visible = true;
                        break;

                }
            }
        }
    }
}
