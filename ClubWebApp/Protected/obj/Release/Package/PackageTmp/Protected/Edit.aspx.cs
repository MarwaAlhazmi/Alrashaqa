using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int EditEmp;
        private static int EditDep;
        private static int EditSer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(ERoles.Manager.ToString()))
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void rbSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSType.SelectedIndex == 1)
            {
                tbDays.Enabled = true;
            }
            else
            {
                tbDays.Enabled = false;
            }
        }

      

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            switch (rbAdd.SelectedIndex)
            {
                case 0:
                    pnlEmp.Visible = true;
                    pnlDep.Visible = false;
                    pnlService.Visible = false;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        gvEmp.DataSource = club.getEmployees();
                        gvEmp.DataBind();
                    }
                    break;
                case 1:
                    pnlEmp.Visible = false;
                    pnlDep.Visible = false;
                    pnlService.Visible = true;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var r = club.getServices();
                        gvSer.DataSource = r;
                        gvSer.DataBind();
                    }
                    
                    break;
                case 2:
                    pnlEmp.Visible = false;
                    pnlDep.Visible = true;
                    pnlService.Visible = false;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var r = from i in club.Departments
                                    select i;
                        gvDep.DataSource = r;
                        gvDep.DataBind();
                    }
                    break;
            }
        }

        private void chagesSaved()
        {
            tbEName.Text = "";
            tbPhone.Text = "";
            ddlType.SelectedIndex = ddlType.Items.Count == 0 ? -1 : 0;
            tbDName.Text = "";
            tbSName.Text = "";
            ddlSDep.SelectedIndex = ddlSDep.Items.Count == 0? -1:0;
            tbPrice.Text = "";
            tbDays.Text = "";
            string Message = " تمت الإضافة  ";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
        }
        protected void btnEAdd_Click(object sender, EventArgs e)
        {
            string name = tbEName.Text;
            long phone = Convert.ToInt64(tbPhone.Text);
            int dep = Convert.ToInt32(ddlType.SelectedValue);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var emp = club.Employees.Where(a => a.EmpID == EditEmp).First();
                emp.Name = name;
                emp.PhoneNum = phone;
                if (dep == 0)
                {
                    emp.Type = "Manager";
                }
                else
                {
                    emp.Type = "Trainer";
                    var t = (from o in club.Departments
                            where o.DepID == dep
                            select o).First();
                    emp.Departments.Clear();
                    emp.Departments.Add(t);
                }
                club.SaveChanges();
                resetEmp();
                gvEmp.DataSource = club.getEmployees();
                gvEmp.DataBind();
                //chagesSaved();
            }
        }

        protected void btnDAdd_Click(object sender, EventArgs e)
        {
            string name = tbDName.Text;
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var d = (from i in club.Departments where i.DepID == EditDep select i).First();
                d.Name = tbDName.Text;
                club.SaveChanges();
                DepTable.Visible = false;
                tbDName.Text = "";
                gvDep.DataSource = club.Departments;
                gvDep.DataBind();
            }

        }

        protected void btnSAdd_Click(object sender, EventArgs e)
        {
            bool sub = (rbSType.SelectedIndex == 0) ? false : true;
            string name = tbSName.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            int days = string.IsNullOrEmpty(tbDays.Text)?0:Convert.ToInt32(tbDays.Text);
            int dep = Convert.ToInt32(ddlSDep.SelectedValue);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var ser = club.Services.Where(a => a.ServiceID == EditSer).First();
                ser.Name = name;
                ser.Sub = sub;
                ser.Price = price;
                ser.TotalDays = days;
                ser.DepID = dep;
                club.SaveChanges();
                gvSer.DataSource = club.getServices();
                gvSer.DataBind();
                resetSer();
            }

        }

        protected void gvEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvEmp.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "لاتوجد بيانات";
            }
            else
            {
                lblError.Visible = false;
            }
        }

        protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvEmp.Rows[row].Cells[5].Text);
            if (e.CommandName == "Select")
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var r = from o in club.Departments
                            select o;
                    ddlType.DataSource = r;
                    ddlType.DataTextField = "Name";
                    ddlType.DataValueField = "DepID";
                    ddlType.DataBind();
                    var result = club.Employees.Where(a => a.EmpID == id).First();
                    tbEName.Text = result.Name;
                    tbPhone.Text = result.PhoneNum.ToString();
                    if (result.Type == "Manager")
                    {
                        ddlType.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlType.SelectedValue = result.Departments.First().DepID.ToString();
                    }
                    empTable.Visible = true;
                    EditEmp = id;
                }
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            resetEmp();
        }

        private void resetEmp()
        {
            tbEName.Text = "";
            tbPhone.Text = "";
            ddlType.SelectedIndex = 0;
            empTable.Visible = false;
        }

        protected void gvDep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvDep.Rows.Count == 0)
            {
                lblError.Text = "لا توجد بيانات";
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

        protected void gvDep_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //lblError.Visible = false;
            int row = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvDep.Rows[row].Cells[3].Text);
            if (e.CommandName == "Select")
            {
                tbDName.Text = gvDep.Rows[row].Cells[2].Text;
                DepTable.Visible = true;
                EditDep = id;
            }
           
        }

        protected void btnDCancel_Click(object sender, EventArgs e)
        {
            DepTable.Visible = false;
            tbDName.Text = "";
        }

        protected void gvSer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvSer.Rows[row].Cells[7].Text);
            if (e.CommandName == "Select")
            {
                // get data
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var o = from i in club.Departments
                            select i;
                    ddlSDep.DataSource = o;
                    ddlSDep.DataTextField = "Name";
                    ddlSDep.DataValueField = "DepID";
                    ddlSDep.DataBind();
                    var r = club.Services.Where(a => a.ServiceID == id).First();
                    tbSName.Text = r.Name;
                    tbPrice.Text = r.Price.ToString("0,00");
                    ddlSDep.SelectedValue = r.DepID.ToString();
                    rbSType.SelectedIndex = r.Sub? 1:0 ;
                    tbDays.Text = r.TotalDays.ToString();
                }
                // show table
                serTable.Visible = true;
                EditSer = id;
            }
            
            
        }

        protected void btnSCancel_Click(object sender, EventArgs e)
        {
            resetSer();
        }

        private void resetSer()
        {
            tbSName.Text = "";
            ddlSDep.SelectedIndex = 0;
            rbSType.SelectedIndex = 0;
            tbPrice.Text = "";
            tbDays.Text = "";
            serTable.Visible = false;
        }

        protected void gvSer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSer.Rows[e.RowIndex].Cells[7].Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                try
                {
                    var re = club.Services.Where(a => a.ServiceID == id).First();
                    club.Services.DeleteObject(re);
                    club.SaveChanges();
                    gvSer.DataSource = club.getServices();
                    gvSer.DataBind();
                    string Message = " تم الحذف  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                }
                catch
                {
                    lblError.Text = "لايمكن الحذف";
                    lblError.Visible = true;
                }
            }
        }

        protected void gvDep_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvDep.Rows[e.RowIndex].Cells[3].Text);
            try
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var dep = club.Departments.Where(a => a.DepID == id).First();
                    club.Departments.DeleteObject(dep);
                    club.SaveChanges();
                    gvDep.DataSource = club.Departments;
                    gvDep.DataBind();
                    string Message = " تم الحذف  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                }
            }
            catch
            {
                lblError.Text = "لايمكن حذف العيادة";
                lblError.Visible = true;
            }
        }

        protected void gvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvEmp.Rows[e.RowIndex].Cells[5].Text);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var emp = club.Employees.Where(a => a.EmpID == id).First();
                    club.Employees.DeleteObject(emp);
                    if (!string.IsNullOrEmpty(emp.UserName))
                    {
                        Membership.DeleteUser(emp.UserName, true);
                    }
                    club.SaveChanges();
                    gvEmp.DataSource = club.getEmployees();
                    gvEmp.DataBind();
                    string Message = " تم الحذف  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                }
            }
            catch
            {
                lblError.Text = "لايمكن حذف الموظف";
                lblError.Visible = true;
            }
        }
      
    }
}