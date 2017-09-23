using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClubWebApp.Protected;

namespace ClubWebApp
{
    public partial class Visit1 : System.Web.UI.Page
    {
        private static string Where;
        private static int SubID;
        private static int CntID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                EntityDataSource1.Where = Where;
            }
            else
            {
                if (Request["ClientID"] != null)
                {
                    CntID = Convert.ToInt32(Request["ClientID"]);
                    tbID.Text = CntID.ToString();
                    getName();
                    FillSubData();

                }
            }

        }

        protected void gvSubs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.Cells[1].Text == "0")
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(172, 172, 172);
            }
        }

        protected void gvSubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            GridView row = (GridView)sender;
            int id = Convert.ToInt32(row.SelectedRow.Cells[5].Text);
            // get the data then show th panel
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.getSubDetails(id);
                fvDetails.DataSource = result;
                fvDetails.DataBind();
                SubID = id;
                Where = "it.SubID = " + id;
                EntityDataSource1.Where = Where;
                EntityDataSource1.DataBind();
                gvVisits.DataBind();
                pnlSubDetails.Visible = true;
                pnlVisit.Visible = false;

                Panel pnlInt = (Panel)fvDetails.FindControl("pnlInt");
                Panel pnlNut = (Panel)fvDetails.FindControl("pnlNut");
                if (result.ElementAt(0).BPressure == null && result.ElementAt(0).BSugar == null)
                {
                    if (pnlInt != null)
                        pnlInt.Visible = false;
                }
                else
                {
                    if (pnlInt != null)
                        pnlInt.Visible = true;
                }
                if (result.ElementAt(0).Fat == null && result.ElementAt(0).Weight == null && result.ElementAt(0).Hieght == null)
                {
                    if (pnlNut != null)
                        pnlNut.Visible = false;
                }
                else
                {
                    if (pnlInt != null)
                        pnlNut.Visible = true;
                }

            }

        }

        protected void tbID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbID.Text))
            {
                getName();
            }
        }

        private void getName()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int id = Convert.ToInt32(tbID.Text);
                var result = (from m in club.Clients
                              where m.ClientID == id
                              select m).FirstOrDefault();
                if (result == null)
                {
                    lblError.Visible = true;
                    lblError.Text = "خطأ في رقم الملف";
                    tbName.Text = "";
                }
                else
                {
                    tbName.Text = result.FullName();
                    lblError.Visible = false;
                    btnShow.Focus();
                }

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbID.Text))
            {
                FillSubData();
            }
        }

        private void FillSubData()
        {
            lblError.Visible = false;
            int id = Convert.ToInt32(tbID.Text);
            CntID = id;
            using (ClubDBEntities club = new ClubDBEntities())
            {
                pnlSub.Visible = true;
                gvSubs.DataSource = club.getSubs(id).OrderByDescending(a => a.SubDate).ToList();
                gvSubs.DataBind();
                pnlSubDetails.Visible = false;
                pnlVisit.Visible = false;
            }
        }

        protected void gvSubs_DataBound(object sender, EventArgs e)
        {
            if (gvSubs.Rows.Count <= 0)
            {
                lblNoData.Visible = true;
                lblNoData.Text = "لايوجد بيانات لعرضها";
            }
            else
            {
                lblNoData.Visible = false;
            }
        }

        protected void gvVisits_DataBound(object sender, EventArgs e)
        {
            if (gvVisits.Rows.Count <= 0)
            {
                lblNo.Visible = true;
                lblNo.Text = "لايوجد بيانات لعرضها";
            }
            else
            {
                lblNo.Visible = false;
            }
        }

        protected void btnVisit_Click(object sender, EventArgs e)
        {
            pnlVisit.Visible = true;
            tbBefore.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                lblError.Visible = false;
                var sub = (from i in club.Subscribtions
                where i.SubID == SubID
                select i).First();
                if (sub.LeftDays - 1 < 0)
                {
                    // dont save
                    lblNo.Text = "انتهت أيام الاشتراك، لا يمكنك اضافة زيارة";
                    pnlVisit.Visible = false;
                    return;
                }
                else
                {
                    sub.LeftDays--;
                    sub.AttDays++;
                    Visit visit = new Visit();
                    visit.ClientID = CntID;
                    visit.SubID = SubID;
                    visit.Date = DateTime.Now.Date;
                    visit.SigninTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    visit.SizeAfter = tbAfter.Text;
                    visit.SizeBefore = tbBefore.Text;
                    club.Visits.AddObject(visit);
                    club.SaveChanges();
                    var result = club.getSubDetails(SubID);
                    fvDetails.DataSource = result;
                    fvDetails.DataBind();
                }

                // refresh
                EntityDataSource1.DataBind();
                gvVisits.DataBind();

                pnlVisit.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tbBefore.Text = "";
            tbAfter.Text = "";
            pnlVisit.Visible = false;
        }

        protected void fvDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("AddSub.aspx?SubID="+SubID);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportViewer.aspx?type=12&id="+SubID);
            //VisitCR report = new VisitCR();
            //report.Load(Server.MapPath("VisitCR.rpt"));
            //ClubDBEntities club = new ClubDBEntities();
            //report.SetDataSource(club.getVisitReport(SubID));
            //string printer = ClubWebApp.Properties.Settings.Default.DefaultPrinter;
            //report.PrintOptions.PrinterName = printer;
            //report.PrintToPrinter(1, false, 0, 0);

        }


        protected void gvSubs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Visible = false;
            int id = Convert.ToInt32(gvSubs.Rows[e.RowIndex].Cells[5].Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var intsub = club.IntSubs.Where(a => a.SubID == id).FirstOrDefault();
                var nutsub = club.NutSubs.Where(a => a.SubID == id).FirstOrDefault();
                var sub = club.Subscribtions.Where(a => a.SubID == id).First();
                if (intsub != null)
                {
                    club.IntSubs.DeleteObject(intsub);
                }
                if (nutsub != null)
                {
                    club.NutSubs.DeleteObject(nutsub);
                }
                club.Subscribtions.DeleteObject(sub);
                try
                {
                    club.SaveChanges();
                    string Message = " تم حذف الاشتراك  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                    FillSubData();
                }
                catch
                {
                    lblError.Text = "لايمكن حذف الاشتراك لوجود زيارات متعلقة";
                    lblError.Visible = true;
                }
            }
        }



      


    }
}