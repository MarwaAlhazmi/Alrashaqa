﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class BrowseWith : System.Web.UI.Page
    {
        private static string where;
        private static bool first;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                if (Page.IsPostBack)
                {
                    edsInvoices.Where = where;
                }
                else
                {
                    where = "it.Date between @Invoice and @Invoice";
                    first = true;
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void rbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSelect.SelectedIndex == 0)
            {
                lblDate.Text = "تاريخ السند";
                tbDate.Text = "";
                tbDate0_CalendarExtender.Enabled = true;
                reID.Enabled = false;
                where = "it.Date between @Invoice and @Invoice";
            }
            else
            {
                lblDate.Text = "رقم السند";
                tbDate.Text = "";
                where = "it.ID = @Invoice";
                tbDate0_CalendarExtender.Enabled = false;
                reID.Enabled = true;
            }
        }

        protected void btnSearch0_Click(object sender, EventArgs e)
        {
            if (rbSelect.SelectedIndex == 0)
            {
                edsInvoices.WhereParameters.Clear();
                edsInvoices.WhereParameters.Add("Invoice", TypeCode.DateTime, tbDate.Text);
                edsInvoices.Where = where;
                edsInvoices.DataBind();
                GridView1.DataBind();
            }
            else
            {
                edsInvoices.WhereParameters.Clear();
                edsInvoices.WhereParameters.Add("Invoice", TypeCode.Int32, tbDate.Text);
                edsInvoices.Where = where;
                edsInvoices.DataBind();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridView1.Rows[row].Cells[8].Text;
                Session["WithID"] = id;
                Session["InvoiceID"] = null;
                Response.Redirect("ShowInvoice.aspx");
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count <= 0 && !first)
            {
                lblError.Visible = true;
                lblError.Text = "لايوجد بيانات لعرضها";
            }
            else
            {
                lblError.Visible = false;
                first = false;
            }
        }
    }
}