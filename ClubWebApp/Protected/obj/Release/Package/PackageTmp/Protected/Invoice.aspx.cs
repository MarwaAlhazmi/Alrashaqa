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


namespace ClubWebApp
{
    public partial class Invoice : System.Web.UI.Page
    {
        private static List<int> ids;
        private static bool incomplete;
        private static int InvID;
        private static int VoucherID;
        private static InvoiceType invoiceType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(ERoles.Manager.ToString()) || Roles.IsUserInRole(ERoles.Receptionist.ToString()))
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

                    if (Request["New"] != null)
                    {
                        tbFile.Text = Request["New"].ToString();

                        getName();
                    }
                    if (Request["Incomplete"] != null)
                    {
                        int invID = Convert.ToInt32(Request["Incomplete"]);
                        incomplete = true;

                        InvID = invID;
                        // set the id and name
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            var result = (from c in club.InvoiceHeaders
                                          where c.InvID == invID
                                          select c).First();
                            if (result != null)
                            {
                                tbFile.Text = result.ClientID.ToString();
                                getName();
                                ddlDep.SelectedValue = result.Services.First().DepID.ToString();
                                getDocSer();
                                ddlDoc.SelectedValue = result.DocID.ToString();
                                List<int> ser = (from o in result.Services
                                                 select o.ServiceID).ToList();
                                checkServices(ser);
                                getPrices();
                                tbNotes.Text = result.Notes;

                            }
                        }

                    }
                    if (Request["subID"] != null && Request["empID"] != null)
                    {
                        // fill data .. no editting .. print
                        int subID = Convert.ToInt32(Request["subID"]);
                        int empID = Convert.ToInt32(Request["empID"]);
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            var sub = (from o in club.Subscribtions
                                       where o.SubID == subID
                                       select o).First();
                            tbFile.Text = sub.ClientID.ToString();
                            getName();
                            ddlDep.SelectedValue = sub.Service.DepID.ToString();
                            getDocSerSubs();
                            ddlDoc.SelectedValue = empID.ToString();
                            checkServices(new List<int> { sub.ServiceID });
                            getPrices();
                        }
                    }



                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        private void noPrintUI()
        {
                btnSave.Text = "إرسال";
                btnPrint.ForeColor = Color.Silver;
                btnPrint.Enabled = false;
                btnPrintV.Enabled = false;
                btnPrintV.ForeColor = Color.Silver;
                btnAddV.Enabled = false;
                btnAddV.ForeColor = Color.Silver;
                rbType.Enabled = false;
            
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
                        pnlType.Visible = true;
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
                tbPaid.Text = tbFinal.Text;
            }
            else
            {
                tbFinal.Text = tbTotal.Text;
                tbPaid.Text = tbTotal.Text;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            
                print(InvID);
                
            
        }

        private void print(int id)
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("InvoiceCR.rpt"));
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.getInvoiceHeader(id);
                report.SetDataSource(result);
            }
            // get printer name
            string printer = ClubWebApp.Properties.Settings.Default.InvoicePrinter;
            report.PrintOptions.PrinterName = printer;
            report.PrintToPrinter(1, false, 0, 0);
        }

        private void updateInvoice(int invoiceID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                InvoiceHeader result = (from o in club.InvoiceHeaders
                                        where o.InvID == invoiceID
                                        select o).First();
                decimal total = Convert.ToDecimal(tbTotal.Text);
                int dis = (string.IsNullOrEmpty(tbDis.Text)) ? 0 : Convert.ToInt32(tbDis.Text);
                decimal final = Convert.ToDecimal(tbFinal.Text);
                //decimal paid = Convert.ToDecimal(tbPaid.Text);
                //decimal rem = string.IsNullOrEmpty(tbRemain.Text) ? 0 : Convert.ToDecimal(tbRemain.Text);
                result.TotalAmount = total;
                result.Discount = dis;
                result.FinalAmount = final;
               // result.PaidAmount = paid;
               // result.RemainAmount = rem;
                result.Notes = tbNotes.Text;
                result.Status = InvoiceStatus.Complete.ToString();
                result.Type = rbType.SelectedValue;
                club.SaveChanges();
                // create deposit
                Deposit deposit = new Deposit();
                deposit.InvID = invoiceID;
                deposit.Notes = tbNotes.Text;
                deposit.Date = DateTime.Now.Date;
                deposit.Employee = club.Employees.Where(a=>a.UserName == User.Identity.Name).Select(o=>o.Name).First();
                deposit.FromPerson = club.Clients.Where(a => a.ClientID == result.ClientID).First().FullName();
                
                switch (rbType.SelectedIndex)
                {
                    case 0:
                        deposit.CheckNum = Convert.ToInt64(tbCheck.Text);
                        deposit.Bank = tbBank.Text;
                      
                        break;
                    case 1:
                        decimal paid = Convert.ToDecimal(tbPaid.Text);
                        deposit.Amount = paid;
                        
                        break;
                    case 2:
                        decimal amount = Convert.ToDecimal(tbFinal.Text);
                        deposit.Amount = amount;
                        break;
                }
                club.Deposits.AddObject(deposit);
                club.SaveChanges();
                VoucherID = deposit.ID;
                InvID = invoiceID;

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
                decimal rem = (string.IsNullOrEmpty(tbRemain.Text)) ? 0 : Convert.ToDecimal(tbRemain.Text);
                int dep = Convert.ToInt32(ddlDep.SelectedValue);
                InvoiceHeader inv = new InvoiceHeader();
                inv.ClientID = clientID;
                inv.TotalAmount = total;
                inv.Discount = dis;
                inv.FinalAmount = final;
                inv.Dep = dep;
                inv.Notes = tbNotes.Text;
                inv.Type = rbType.SelectedValue;
                inv.DocID = Convert.ToInt32(ddlDoc.SelectedValue);
                string userName = User.Identity.Name;
                inv.Status = InvoiceStatus.Complete.ToString();
                
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
                Deposit deposit = new Deposit();
                deposit.InvID = invoiceN;
                deposit.Notes = tbNotes.Text;
                deposit.Date = DateTime.Now.Date;
                deposit.Employee = club.Employees.Where(a => a.UserName == User.Identity.Name).Select(o => o.Name).First();
                deposit.FromPerson = club.Clients.Where(a => a.ClientID == inv.ClientID).First().FullName();
                switch (rbType.SelectedIndex)
                {
                    case 0:
                        deposit.CheckNum = Convert.ToInt64(tbCheck.Text);
                        deposit.Bank = tbBank.Text;
                        inv.Type = InvoiceType.Check.ToString();
                        break;
                    case 1:
                        decimal paid = Convert.ToDecimal(tbPaid.Text);
                        deposit.Amount = paid;
                        inv.Type = InvoiceType.Credit.ToString();
                        break;
                    case 2:
                        decimal amount = Convert.ToDecimal(tbFinal.Text);
                        deposit.Amount = amount;
                        inv.Type = InvoiceType.Cash.ToString();
                        break;
                }
                club.Deposits.AddObject(deposit);
                club.SaveChanges();
                VoucherID = deposit.ID;
                return inv.Status;
            }
        }

        protected void tbPaid_TextChanged(object sender, EventArgs e)
        {
            getRemainder();
        }

        private void getRemainder()
        {
            decimal asked = Convert.ToDecimal(tbFinal.Text);
            decimal paid = Convert.ToDecimal(tbPaid.Text);
            tbRemain.Text = (asked - paid).ToString("0.00");
        }

        protected void rbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rbType.SelectedIndex)
            {
                case 0:
                    pnlCheck.Visible = true;
                    pnlCredit.Visible = false;
                    break;
                case 1:
                    pnlCheck.Visible = false;
                    pnlCredit.Visible = true;
                    break;
                case 2:
                    pnlCheck.Visible = false;
                    pnlCredit.Visible = false;
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlDep.SelectedIndex == 0 || cbServices.SelectedIndex < 0)
            {
                return;
            }
            // save the invoice and voucher
            if (incomplete)
            {
                string username = User.Identity.Name;
                if (Roles.GetRolesForUser(username).Contains("Receptionist") || Roles.GetRolesForUser(username).Contains("Manager"))
                {
                    updateInvoice(InvID);
                    //print(InvID);
                }
          
                // update invoice

            }
            else
            {
                // save invoice
                int id;
                string status = saveInvoice(out id);
                InvID = id;
            }
            switch (rbType.SelectedIndex)
            {
                case 0:
                    btnSave.Enabled = false;
                    btnPrint.Enabled = true;
                    btnPrintV.Enabled = true;
                    btnAddV.Enabled = false;
                    btnAddV.ForeColor = Color.Silver;
                    break;
                case 1:
                    btnSave.Enabled = false;
                    btnPrint.Enabled = true;
                    btnPrintV.Enabled = true;
                    btnAddV.Enabled = true;
                    btnAddV.ForeColor = Color.Gray;
                    break;
                case 2:
                    btnSave.Enabled = false;
                    btnPrint.Enabled = true;
                    btnPrintV.Enabled = true;
                    btnAddV.Enabled = false;
                    btnAddV.ForeColor = Color.Silver;
                    break;
            }
            string msg = " تم انشاء الفاتورة  ";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", msg), true);
        }

        protected void btnPrintV_Click(object sender, EventArgs e)
        {
            if (VoucherID != 0)
            {
                using (ClubDBEntities club = new ClubDBEntities())
                {
                    var result = club.getDepositReport(VoucherID);
                    ReportDocument report = new ReportDocument();
                    report.Load(Server.MapPath("DepositCR.rpt"));
                    report.SetDataSource(result);
                    string printer = ClubWebApp.Properties.Settings.Default.InvoicePrinter;
                    report.PrintOptions.PrinterName = printer;
                    report.PrintToPrinter(1, false, 0, 0);
                }
            }
        }

        protected void btnAddV_Click(object sender, EventArgs e)
        {
            // redirect and fill data
            Response.Redirect("Deposit.aspx?Inv="+InvID);
        }



    }
}