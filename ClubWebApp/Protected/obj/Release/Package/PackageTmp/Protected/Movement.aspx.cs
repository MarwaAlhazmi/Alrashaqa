﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class Movement : System.Web.UI.Page
    {
        private static DateTime date;
        private static int depID;
        CultureInfo cul = new CultureInfo("en-GB");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                if (!Page.IsPostBack)
                {
                    tbDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    // get departments
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var result = from o in club.Departments
                                     select o;
                        ddlDep.DataSource = result;
                        ddlDep.DataTextField = "Name";
                        ddlDep.DataValueField = "DepID";
                        ddlDep.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("Error");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                date = Convert.ToDateTime(tbDate.Text,cul);
                depID = Convert.ToInt32(ddlDep.SelectedValue);
                if (ddlDep.SelectedIndex == 0)
                {
                    var result = club.getMovReport(date);
                    gvIncome.DataSource = result;
                }
                else
                {
                    var result = club.getMovReport(date, depID);
                    gvIncome.DataSource = result;
                }
                gvIncome.DataBind();
                pnlData.Visible = true;
            }
        }

        protected void gvIncome_DataBound(object sender, EventArgs e)
        {
            if (gvIncome.Rows.Count <= 0)
            {
                lblError.Visible = true;
                btnPrint.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                btnPrint.Visible = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("MovCR.rpt"));
            ClubDBEntities club = new ClubDBEntities();
            if (depID == 0)
            {
                report.SetDataSource(club.getMovReport(date));
            }
            else
            {
                report.SetDataSource(club.getMovReport(date, depID));
            }
            
            ParameterValues pvDate = new ParameterValues();
            ParameterDiscreteValue DisDate = new ParameterDiscreteValue();
            DisDate.Value = date;
            pvDate.Add(DisDate);
            report.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(pvDate);
            string printer = Properties.Settings.Default.DefaultPrinter;
            report.PrintOptions.PrinterName = printer;
            report.PrintToPrinter(1, false, 0, 0);
        }
    }
}