using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Security;
using System.Drawing;
using ClubWebApp.Protected;
using System.Web.Security;


namespace ClubWebApp
{
    public partial class InvoiceOrder : System.Web.UI.Page
    {
        private static List<int> ids;
        private static int InvID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.PhysicalS.ToString()) || Roles.IsUserInRole(ERoles.Nutritionist.ToString()) || Roles.IsUserInRole(ERoles.InternalS.ToString()))
            {
                IEnumerable<Department> dep;
                if (!Page.IsPostBack)
                {
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        dep = (from i in club.Departments
                               select i).ToList();
                    }
                    ddlDep.DataSource = dep;
                    ddlDep.DataTextField = "Name";
                    ddlDep.DataValueField = "DepID";
                    ddlDep.DataBind();
                }
            }
            else
            {
                Response.Redirect("Error");
            }

        }


        private void checkServices(List<int> services)
        {
            foreach (ListItem item in cbServices.Items)
            {
                if (services.Contains(Convert.ToInt32(item.Value)))
                {
                    item.Selected = true;
                }

            }
        }
        protected void tbFile_TextChanged(object sender, EventArgs e)
        {

            getName();
        }

        private void getName()
        {
            if (!string.IsNullOrEmpty(tbFile.Text))
            {
                int id = Convert.ToInt32(tbFile.Text);
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = (from c in club.Clients
                                  where c.ClientID == id
                                  select c.FirstName + " " + c.SecondName + " " + c.FamilyName).FirstOrDefault();
                    if (string.IsNullOrEmpty(result))
                    {
                        lblError.Visible = true;
                        lblError.Text = "خطأ في رقم الملف";
                        lblNameValue.Text = "";
                    }
                    else
                    {
                        lblError.Visible = false;
                        lblNameValue.Text = result;
                        pnlService.Visible = true;
                        pnlTotal.Visible = true;
                        
                    }
                }
            }
        }

        protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDocSer();
        }

        private void getDocSer()
        {
            if (ddlDep.SelectedIndex != 0)
            {
                // employees + services
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    int depID = Convert.ToInt32(ddlDep.SelectedValue);
                    var emp = club.Employees.Where(a => a.Departments.Any(b => b.DepID == depID));
                    ddlDoc.DataSource = emp;
                    ddlDoc.DataTextField = "Name";
                    ddlDoc.DataValueField = "EmpID";
                    ddlDoc.DataBind();


                    // services
                    var service = (from n in club.Services
                                   where n.DepID == depID && n.Sub == false
                                   select n).ToList();
                    cbServices.DataSource = service;
                    cbServices.DataTextField = "Name";
                    cbServices.DataValueField = "ServiceID";
                    cbServices.DataBind();

                }
            }
        }

        private void getDocSerSubs()
        {
            if (ddlDep.SelectedIndex != 0)
            {
                // employees + services
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    int depID = Convert.ToInt32(ddlDep.SelectedValue);
                    var emp = club.Employees.Where(a => a.Departments.Any(b => b.DepID == depID));
                    ddlDoc.DataSource = emp;
                    ddlDoc.DataTextField = "Name";
                    ddlDoc.DataValueField = "EmpID";
                    ddlDoc.DataBind();


                    // services
                    var service = (from n in club.Services
                                   where n.DepID == depID && n.Sub == true
                                   select n).ToList();
                    cbServices.DataSource = service;
                    cbServices.DataTextField = "Name";
                    cbServices.DataValueField = "ServiceID";
                    cbServices.DataBind();

                }
            }
        }




        protected void cbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPrices();
        }

        private void getPrices()
        {
            ids = new List<int>();
            foreach (ListItem item in cbServices.Items)
            {
                if (item.Selected)
                {
                    ids.Add(Convert.ToInt32(item.Value));
                }
            }
            if (ids.Count != 0)
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = (from o in club.Services
                                  where ids.Contains(o.ServiceID)
                                  select o.Price).Sum();
                    tbTotal.Text = result.ToString("0.00");
                    getDis();
                }
            }
            else
            {
                tbTotal.Text = "";
                tbFinal.Text = "";
            }
        }

        protected void tbDis_TextChanged(object sender, EventArgs e)
        {
            getDis();
        }

        private void getDis()
        {
            if (!string.IsNullOrEmpty(tbDis.Text))
            {
                decimal total = Convert.ToDecimal(tbTotal.Text);
                decimal dis = Convert.ToDecimal(tbDis.Text);
                decimal temp = (total * (dis / 100));
                tbFinal.Text = (total - temp).ToString("0.00");
                
            }
            else
            {
                tbFinal.Text = tbTotal.Text;
               
            }
        }

       

       
        private string saveInvoice(out int invoiceN)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                // get info


                int clientID = Convert.ToInt32(tbFile.Text);
                decimal total = Convert.ToDecimal(tbTotal.Text);
                int dis = (string.IsNullOrEmpty(tbDis.Text)) ? 0 : Convert.ToInt32(tbDis.Text);
                decimal final = Convert.ToDecimal(tbFinal.Text);
                //decimal rem = (string.IsNullOrEmpty(tbRemain.Text)) ? 0 : Convert.ToDecimal(tbRemain.Text);
                int dep = Convert.ToInt32(ddlDep.SelectedValue);
                InvoiceHeader inv = new InvoiceHeader();
                inv.ClientID = clientID;
                inv.TotalAmount = total;
                inv.Discount = dis;
                inv.FinalAmount = final;
                inv.Dep = dep;
                inv.Notes = tbNotes.Text;
                inv.DocID = Convert.ToInt32(ddlDoc.SelectedValue);
                string userName = User.Identity.Name;
                inv.Status = InvoiceStatus.Incomplete.ToString();
                inv.RecepName = userName;
                inv.Date = DateTime.Now.Date;
                
                // services
                var services = from o in club.Services
                               where ids.Contains(o.ServiceID)
                               select o;
                foreach (var s in services)
                {
                    inv.Services.Add(s);
                }
                club.InvoiceHeaders.AddObject(inv);
                club.SaveChanges();
                invoiceN = inv.InvID;
                return inv.Status;
            }
        }

    

       

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlDep.SelectedIndex == 0 || cbServices.SelectedIndex < 0)
            {
                return;
            }
            // save the invoice and voucher
           
                // save invoice
                int id;
                string status = saveInvoice(out id);
                InvID = id;
                btnSave0.Enabled = false;
                string Message = " تم ارسال الفاتورة للطباعة  ";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                
            
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            tbFile.Text = "";
            lblNameValue.Text = "";
            ddlDep.SelectedIndex = 0;
            ddlDoc.SelectedIndex = 0;
            tbTotal.Text = "";
            tbDis.Text = "";
            tbFinal.Text = "";
            tbNotes.Text = "";
            btnSave0.Enabled = true;
        }



    }
}