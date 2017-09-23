﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class EvaluationBrowse : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-GB");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.PhysicalS.ToString()))
            {
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDate.Text))
            {
                DateTime date = Convert.ToDateTime(tbDate.Text, cul);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = club.getEvaluationreport(date);
                    if (result.Count() != 0)
                    {
                        gvRequests.DataSource = result;
                        gvRequests.DataBind();
                        pnlG.Visible = true;
                        lblError.Visible = false;
                    }
                    else
                    {
                        pnlG.Visible = false;
                        lblError.Text = "No Data";
                        lblError.Visible = true;
                    }
                }
            }
            if (!string.IsNullOrEmpty(tbID.Text))
            {
                
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = club.getEvaluationreport(tbID.Text);
                    if (result.Count() != 0)
                    {
                        gvRequests.DataSource = result;
                        gvRequests.DataBind();
                        pnlG.Visible = true;
                        lblError.Visible = false;
                    }
                    else
                    {
                        pnlG.Visible = false;
                        lblError.Text = "No Data";
                        lblError.Visible = true;
                    }
                }
            }
        }

        protected void gvRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = gvRequests.Rows[row].Cells[0].Text;
                Response.Redirect("EvaluationSheet.aspx?ID="+id);

            }
        }

 

    }
}