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
    public partial class Add : System.Web.UI.Page
    {
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
                    pnlWith.Visible = false;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var r = from o in club.Departments
                                select o;
                        ddlType.DataSource = r;
                        ddlType.DataTextField = "Name";
                        ddlType.DataValueField = "DepID";
                        ddlType.DataBind();
                    }
                    break;
                case 1:
                    pnlEmp.Visible = false;
                    pnlDep.Visible = false;
                    pnlService.Visible = true;
                    pnlWith.Visible = false;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var r = from i in club.Departments
                                select i;
                        ddlSDep.DataSource = r;
                        ddlSDep.DataTextField = "Name";
                        ddlSDep.DataValueField = "DepID";
                        ddlSDep.DataBind();
                    }
                    break;
                case 2:
                    pnlEmp.Visible = false;
                    pnlWith.Visible = false;
                    pnlDep.Visible = true;
                    pnlService.Visible = false;
                    break;
                case 3:
                    pnlEmp.Visible = false;
                    pnlDep.Visible = false;
                    pnlService.Visible = false;
                    pnlWith.Visible = true;
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var r = from i in club.Departments
                                select i;
                        ddlWDep.DataSource = r;
                        ddlWDep.DataTextField = "Name";
                        ddlWDep.DataValueField = "DepID";
                        ddlWDep.DataBind();
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
            tbWName.Text = "";
            ddlWDep.SelectedIndex = ddlWDep.Items.Count == 0 ? -1 : 0;
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
                Employee emp = new Employee();
                emp.Name = name;
                emp.PhoneNum = phone;
                if (dep == 8)
                {
                    emp.Type = "Manager";
                }
                else
                {
                    emp.Type = "Trainer";
                    var t = (from o in club.Departments
                            where o.DepID == dep
                            select o).First();
                    emp.Departments.Add(t);
                }
                club.Employees.AddObject(emp);
                club.SaveChanges();
                chagesSaved();
            }
        }

        protected void btnDAdd_Click(object sender, EventArgs e)
        {
            string name = tbDName.Text;
            using (ClubDBEntities club = new ClubDBEntities())
            {
                Department dep = new Department();
                dep.Name = name;
                club.Departments.AddObject(dep);
                club.SaveChanges();
                chagesSaved();
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
                Service ser = new Service();
                ser.Name = name;
                ser.Price = price;
                ser.Sub = sub;
                ser.TotalDays = days;
                ser.DepID = dep;

                club.Services.AddObject(ser);
                club.SaveChanges();
                chagesSaved();
            }

        }

        protected void btnWSave_Click(object sender, EventArgs e)
        {
            int dep = Convert.ToInt32(ddlWDep.SelectedValue);
            string name = tbWName.Text;
            using (ClubDBEntities club = new ClubDBEntities())
            {
                WithType with = new WithType();
                with.Department = dep;
                with.Name = name;
                club.WithTypes.AddObject(with);
                club.SaveChanges();
                chagesSaved();
            }
        }

    }
}