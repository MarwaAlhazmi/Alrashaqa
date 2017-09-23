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
        private static bool edit;
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
                    tbDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    if (Request["New"] != null)
                    {
                        tbFile.Text = Request["New"].ToString();

                        getName();
                    }
                    if (Request["Inv"] != null)
                    {
                        int inv = Convert.ToInt32(Request["Inv"]);
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            var re = club.InvoiceHeaders.Where(a => a.InvID == inv).FirstOrDefault();
                            if (re != null)
                            {
                                tbDate.Text = re.Date.ToString("yyyy/MM/dd");
                                tbFile.Text = re.ClientID.ToString();
                                lblNameValue.Text = re.Client.FirstName + " " + re.Client.SecondName + " " + re.Client.FamilyName;
                                lblError.Visible = false;
                                pnlService.Visible = true;
                                pnlTotal.Visible = true;
                                pnlType.Visible = true;
                                // services
                                foreach (var r in re.InvoiceServices)
                                {
                                    ListItem list = new ListItem();
                                    list.Text = r.Service.Name;
                                    list.Value = r.ServiceID.ToString();
                                    lbSelected.Items.Add(list);
                                }
                                getPrices();
                                // amount
                                tbTotal.Text = re.TotalAmount.ToString("0.00");
                                tbDis.Text = re.Discount.ToString();
                                tbFinal.Text = re.FinalAmount.ToString("0.00");
                                tbNotes.Text = re.Notes;
                                // type
                                rbType.SelectedValue = re.Type;
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
                                // get the paid amount
                                var paid = club.Deposits.Where(a => a.InvID == inv);
                                if (paid.Count() != 0)
                                {
                                    var sum = paid.Sum(a => a.Amount);
                                    tbPaid.Text = sum.ToString();
                                    tbRemain.Text = (re.FinalAmount - sum).ToString("0.00");
                                }
                                edit = true;
                                InvID = inv;
                                pnlDeposit.Visible = true;
                                btnAddV.Enabled = false;
                                btnPrintV.Enabled = false;
                                btnAdd.Enabled = false;
                                btnDelete.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        edit = false;
                    }
                    if (Request["ClientID"] != null)
                    {
                        // get the client
                        int clientId = Convert.ToInt32(Request["ClientID"]);
                        DateTime date = DateTime.Now.Date;
                        tbFile.Text = clientId.ToString();
                        getName();
                        ddlDep.SelectedIndex = 0;
                        using (ClubDBEntities club = new ClubDBEntities())
                        {
                            // get a list of all services
                            var result = club.Subscribtions.Where(a => a.Date == date).Where(a => a.ClientID == clientId).ToList().Select(a => new { 
                                        ServiceID = a.ServiceID,
                                        ServiceName = a.Service.Name,
                                        }).ToList();
                            lbSelected.DataSource = result;
                            lbSelected.DataTextField = "ServiceName";
                            lbSelected.DataValueField = "ServiceID";
                            lbSelected.DataBind();
                            //get prices
                            getPrices();
                            
                        }
                    }
                    //if (Request["Incomplete"] != null)
                    //{
                    //    int invID = Convert.ToInt32(Request["Incomplete"]);
                    //    incomplete = true;

                    //    InvID = invID;
                    //    // set the id and name
                    //    using (ClubDBEntities club = new ClubDBEntities())
                    //    {
                    //        var result = (from c in club.InvoiceHeaders
                    //                      where c.InvID == invID
                    //                      select c).First();
                    //        if (result != null)
                    //        {
                    //            tbFile.Text = result.ClientID.ToString();
                    //            getName();
                    //            ddlDep.SelectedValue = result.Services.First().DepID.ToString();
                    //            getDocSer();
                    //            ddlDoc.SelectedValue = result.DocID.ToString();
                    //            List<int> ser = (from o in result.Services
                    //                             select o.ServiceID).ToList();
                    //            checkServices(ser);
                    //            getPrices();
                    //            tbNotes.Text = result.Notes;

                    //        }
                    //    }

                    //}
                    //if (Request["subID"] != null && Request["empID"] != null)
                    //{
                    //    // fill data .. no editting .. print
                    //    int subID = Convert.ToInt32(Request["subID"]);
                    //    int empID = Convert.ToInt32(Request["empID"]);
                    //    using (ClubDBEntities club = new ClubDBEntities())
                    //    {
                    //        var sub = (from o in club.Subscribtions
                    //                   where o.SubID == subID
                    //                   select o).First();
                    //        tbFile.Text = sub.ClientID.ToString();
                    //        getName();
                    //        ddlDep.SelectedValue = sub.Service.DepID.ToString();
                    //        getDocSerSubs();
                    //        checkServices(new List<int> { sub.ServiceID });
                    //        getPrices();
                    //    }
                    //}



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
            foreach (ListItem item in lbServices.Items)
            {
                if (services.Contains(Convert.ToInt32(item.Value)))
                {
                    lbSelected.Items.Add(item);
                    //item.Selected = true;
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


                    // services
                    var service = (from n in club.Services
                                   where n.DepID == depID && n.Deleted == false
                                   orderby n.Name descending
                                   select n).ToList();
                    lbServices.DataSource = service;
                    lbServices.DataTextField = "Name";
                    lbServices.DataValueField = "ServiceID";
                    lbServices.DataBind();

                }
            }
        }

        //private void getDocSerSubs()
        //{
        //    if (ddlDep.SelectedIndex != 0)
        //    {
        //        // employees + services
        //        using (ClubDBEntities club = new ClubDBEntities())
        //        {
        //            int depID = Convert.ToInt32(ddlDep.SelectedValue);
        //            //var emp = club.Employees.Where(a => a.Departments.Any(b => b.DepID == depID));
        //            //ddlDoc.DataSource = emp;
        //            //ddlDoc.DataTextField = "Name";
        //            //ddlDoc.DataValueField = "EmpID";
        //            //ddlDoc.DataBind();


        //            // services
        //            var service = (from n in club.Services
        //                           where n.DepID == depID && n.Sub == true
        //                           select n).ToList();
        //            lbServices.DataSource = service;
        //            lbServices.DataTextField = "Name";
        //            lbServices.DataValueField = "ServiceID";
        //            lbServices.DataBind();

        //        }
        //    }
        //}





        private void getPrices()
        {
            ids = new List<int>();
            foreach (ListItem item in lbSelected.Items)
            {
                ids.Add(Convert.ToInt32(item.Value));
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

            Response.Redirect("ReportViewer.aspx?type=0&id=" + InvID.ToString());
                
            
        }

        private void print(int id)
        {
            InvoiceCR report = new InvoiceCR();
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
                // get the invoice then update data
                InvoiceHeader invoice = (from o in club.InvoiceHeaders
                                         where o.InvID == invoiceID
                                         select o).First();
                invoice.Date = Convert.ToDateTime(tbDate.Text);
                invoice.ClientID = Convert.ToInt32(tbFile.Text);
                invoice.Discount = Convert.ToInt32(tbDis.Text);
                invoice.FinalAmount = Convert.ToDecimal(tbFinal.Text);
                invoice.Type = rbType.SelectedValue;

                club.SaveChanges();
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
                //int dep = Convert.ToInt32(ddlDep.SelectedValue);
                InvoiceHeader inv = new InvoiceHeader();
                inv.ClientID = clientID;
                inv.TotalAmount = total;
                inv.Discount = dis;
                inv.FinalAmount = final;
                //inv.Dep = dep;
                inv.Notes = tbNotes.Text;
                inv.Type = rbType.SelectedValue;
                //inv.DocID = Convert.ToInt32(ddlDoc.SelectedValue);
                string userName = User.Identity.Name;
                inv.Status = InvoiceStatus.Complete.ToString();
                
                inv.RecepName = userName;
                inv.Date = Convert.ToDateTime(tbDate.Text);//DateTime.Now.Date;// TODO: chnage this
                
                // services

                club.InvoiceHeaders.AddObject(inv);
                club.SaveChanges();
                invoiceN = inv.InvID;
                var services = (from o in club.Services
                                where ids.Contains(o.ServiceID)
                                select o).ToList();
                foreach (var s in services)
                {
                    // create  a sub if sub
                    if (s.Sub)
                    {
                        Subscribtion sub = new Subscribtion();
                        sub.ClientID = clientID;
                        sub.Date = Convert.ToDateTime(tbDate.Text);
                        sub.ServiceID = s.ServiceID;
                        sub.AttDays = 0;
                        sub.LeftDays = s.TotalDays;
                        sub.SubDays = s.TotalDays;
                        club.Subscribtions.AddObject(sub);
                        club.SaveChanges();
                        switch (s.DepID)
                        {
                            case 1:
                                NutSub nut = new NutSub();
                                nut.SubID = sub.SubID;
                                club.NutSubs.AddObject(nut);
                                club.SaveChanges();
                                break;
                            case 2:
                                IntSub Int = new IntSub();
                                Int.SubID = sub.SubID;
                                club.IntSubs.AddObject(Int);
                                club.SaveChanges();
                                break;
                        }
                    }
                    // create a service
                    InvoiceService ser = new InvoiceService();
                    ser.InvID = inv.InvID;
                    ser.ServiceID = s.ServiceID;
                    if (dis == 0)
                    {
                        if (rbType.SelectedIndex == 1)
                        {
                            decimal paid = Convert.ToDecimal(string.IsNullOrEmpty(tbPaid.Text) ? "0" : tbPaid.Text);
                            ser.PaidAmount = getPrecentage(s.Price, final, paid);
                            ser.AskedAmount = s.Price;
                            ser.Percentage = s.Price / final;
                        }

                        else
                        {
                            ser.PaidAmount = s.Price;
                            ser.AskedAmount = s.Price;
                            ser.Percentage = s.Price/final;
                        }
                    }
                    else
                    {
                        if (rbType.SelectedIndex == 1)
                        {
                            decimal paid = Convert.ToDecimal(string.IsNullOrEmpty(tbPaid.Text) ? "0" : tbPaid.Text);
                            decimal asked = applyDis(dis, s.Price);
                            decimal serpaid = getPrecentage(s.Price,final,paid);
                            ser.AskedAmount = asked;
                            ser.PaidAmount = serpaid;
                            ser.Percentage = s.Price / final;
                        }
                        else
                        {
                            decimal asked = applyDis(dis, s.Price);
                            ser.AskedAmount = asked;
                            ser.PaidAmount = asked;
                            ser.Percentage = s.Price/final;
                            //decimal paid = getPrecentage(asked, final, final);
                        }
                    }
                    
                    club.InvoiceServices.AddObject(ser);
                }
                Deposit deposit = new Deposit();
                deposit.InvID = invoiceN;
                deposit.Notes = tbNotes.Text;
                deposit.Date = Convert.ToDateTime(tbDate.Text);//DateTime.Now.Date;// TODO: chnage this
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



        //private void updateInvoice(int invo)
        //{
        //    using (ClubDBEntities club = new ClubDBEntities())
        //    {
        //        // edit invoivce
        //        // edit deposit
        //        // edit invoice services
        //        // get info
        //        int clientID = Convert.ToInt32(tbFile.Text);
        //        decimal total = Convert.ToDecimal(tbTotal.Text);
        //        int dis = (string.IsNullOrEmpty(tbDis.Text)) ? 0 : Convert.ToInt32(tbDis.Text);
        //        decimal final = Convert.ToDecimal(tbFinal.Text);
        //        decimal rem = (string.IsNullOrEmpty(tbRemain.Text)) ? 0 : Convert.ToDecimal(tbRemain.Text);
        //        //int dep = Convert.ToInt32(ddlDep.SelectedValue);
        //        InvoiceHeader inv = new InvoiceHeader();
        //        inv.ClientID = clientID;
        //        inv.TotalAmount = total;
        //        inv.Discount = dis;
        //        inv.FinalAmount = final;
        //        //inv.Dep = dep;
        //        inv.Notes = tbNotes.Text;
        //        inv.Type = rbType.SelectedValue;
        //        //inv.DocID = Convert.ToInt32(ddlDoc.SelectedValue);
        //        string userName = User.Identity.Name;
        //        inv.Status = InvoiceStatus.Complete.ToString();

        //        inv.RecepName = userName;
        //        inv.Date = Convert.ToDateTime(tbDate.Text);//DateTime.Now.Date;// TODO: chnage this

        //        // services

        //        club.InvoiceHeaders.AddObject(inv);
        //        club.SaveChanges();
        //        invoiceN = inv.InvID;
        //        var services = (from o in club.Services
        //                        where ids.Contains(o.ServiceID)
        //                        select o).ToList();
        //        foreach (var s in services)
        //        {
        //            // create  a sub if sub
        //            if (s.Sub)
        //            {
        //                Subscribtion sub = new Subscribtion();
        //                sub.ClientID = clientID;
        //                sub.Date = Convert.ToDateTime(tbDate.Text);
        //                sub.ServiceID = s.ServiceID;
        //                sub.AttDays = 0;
        //                sub.LeftDays = s.TotalDays;
        //                sub.SubDays = s.TotalDays;
        //                club.Subscribtions.AddObject(sub);
        //                club.SaveChanges();
        //                switch (s.DepID)
        //                {
        //                    case 1:
        //                        NutSub nut = new NutSub();
        //                        nut.SubID = sub.SubID;
        //                        club.NutSubs.AddObject(nut);
        //                        club.SaveChanges();
        //                        break;
        //                    case 2:
        //                        IntSub Int = new IntSub();
        //                        Int.SubID = sub.SubID;
        //                        club.IntSubs.AddObject(Int);
        //                        club.SaveChanges();
        //                        break;
        //                }
        //            }
        //            // create a service
        //            InvoiceService ser = new InvoiceService();
        //            ser.InvID = inv.InvID;
        //            ser.ServiceID = s.ServiceID;
        //            if (dis == 0)
        //            {
        //                if (rbType.SelectedIndex == 1)
        //                {
        //                    decimal paid = Convert.ToDecimal(string.IsNullOrEmpty(tbPaid.Text) ? "0" : tbPaid.Text);
        //                    ser.PaidAmount = getPrecentage(s.Price, final, paid);
        //                    ser.AskedAmount = s.Price;
        //                    ser.Percentage = s.Price / final;
        //                }

        //                else
        //                {
        //                    ser.PaidAmount = s.Price;
        //                    ser.AskedAmount = s.Price;
        //                    ser.Percentage = s.Price / final;
        //                }
        //            }
        //            else
        //            {
        //                if (rbType.SelectedIndex == 1)
        //                {
        //                    decimal paid = Convert.ToDecimal(string.IsNullOrEmpty(tbPaid.Text) ? "0" : tbPaid.Text);
        //                    decimal asked = applyDis(dis, s.Price);
        //                    decimal serpaid = getPrecentage(s.Price, final, paid);
        //                    ser.AskedAmount = asked;
        //                    ser.PaidAmount = serpaid;
        //                    ser.Percentage = s.Price / final;
        //                }
        //                else
        //                {
        //                    decimal asked = applyDis(dis, s.Price);
        //                    ser.AskedAmount = asked;
        //                    ser.PaidAmount = asked;
        //                    ser.Percentage = s.Price / final;
        //                    //decimal paid = getPrecentage(asked, final, final);
        //                }
        //            }

        //            club.InvoiceServices.AddObject(ser);
        //        }
        //        Deposit deposit = new Deposit();
        //        deposit.InvID = invoiceN;
        //        deposit.Notes = tbNotes.Text;
        //        deposit.Date = Convert.ToDateTime(tbDate.Text);//DateTime.Now.Date;// TODO: chnage this
        //        deposit.Employee = club.Employees.Where(a => a.UserName == User.Identity.Name).Select(o => o.Name).First();
        //        deposit.FromPerson = club.Clients.Where(a => a.ClientID == inv.ClientID).First().FullName();
        //        switch (rbType.SelectedIndex)
        //        {
        //            case 0:
        //                deposit.CheckNum = Convert.ToInt64(tbCheck.Text);
        //                deposit.Bank = tbBank.Text;
        //                inv.Type = InvoiceType.Check.ToString();
        //                break;
        //            case 1:
        //                decimal paid = Convert.ToDecimal(tbPaid.Text);
        //                deposit.Amount = paid;
        //                inv.Type = InvoiceType.Credit.ToString();
        //                break;
        //            case 2:
        //                decimal amount = Convert.ToDecimal(tbFinal.Text);
        //                deposit.Amount = amount;
        //                inv.Type = InvoiceType.Cash.ToString();
        //                break;
        //        }
        //        club.Deposits.AddObject(deposit);
        //        club.SaveChanges();
        //        VoucherID = deposit.ID;
        //        return inv.Status;
        //    }
        //}
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
            if (lbSelected.Items.Count == 0)
            {
                return;
            }
            // save the invoice and voucher
            //if (incomplete)
            //{
            //    string username = User.Identity.Name;
            //    if (Roles.GetRolesForUser(username).Contains("Receptionist") || Roles.GetRolesForUser(username).Contains("Manager"))
            //    {
            //        updateInvoice(InvID);
            //        //print(InvID);
            //    }
            //    // update invoice
            //}
            else
            {
                if (edit)
                {
                    updateInvoice(InvID);
                    string msg = " تم تعديل الفاتورة رقم  " + InvID;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", msg), true);
                }
                else
                {
                    // save invoice
                    int id;
                    string status = saveInvoice(out id);
                    InvID = id;
                    string msg = " تم انشاء الفاتورة - رقم الفاتورة  " + InvID;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", msg), true);
                }
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

        }

        protected void btnPrintV_Click(object sender, EventArgs e)
        {
            if (VoucherID != 0)
            {
                Response.Redirect("ReportViewer.aspx?type=1&id=" + VoucherID);
                //using (ClubDBEntities club = new ClubDBEntities())
                //{
                //    var result = club.getDepositReport(VoucherID);
                //    DepositCR report = new DepositCR();
                //    report.Load(Server.MapPath("DepositCR.rpt"));
                //    report.SetDataSource(result);
                //    string printer = ClubWebApp.Properties.Settings.Default.InvoicePrinter;
                //    report.PrintOptions.PrinterName = printer;
                //    report.PrintToPrinter(1, false, 0, 0);
                //}
            }
        }

        protected void btnAddV_Click(object sender, EventArgs e)
        {
            // redirect and fill data
            Response.Redirect("Deposit.aspx?Inv="+InvID);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbServices.SelectedIndex >= 0)
            {
                ListItem item = new ListItem(lbServices.SelectedItem.Text, lbServices.SelectedItem.Value);
                lbSelected.Items.Add(item);
                getPrices();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbSelected.SelectedIndex >= 0)
            {
                lbSelected.Items.RemoveAt(lbSelected.SelectedIndex);
                getPrices();
                

            }
        }

        protected decimal getPrecentage(decimal ser, decimal total, decimal paid)
        {
            decimal temp = ser / total;
            decimal result = temp * paid;
            return result;
        }

        protected decimal applyDis(int dis, decimal ser)
        {
            decimal result = dis / 100;
            decimal t = ser -(result * ser);
            return t;
        }

    

    }
}