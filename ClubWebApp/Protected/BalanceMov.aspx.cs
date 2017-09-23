using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClubWebApp.Protected;
using System.Web.Security;
using System.Globalization;

namespace ClubWebApp
{
    public partial class BalanceMov : System.Web.UI.Page
    {
        private static bool saved;
        private static DateTime Date;
        private static bool show;
        private static bool edit;
        CultureInfo cul = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Roles.IsUserInRole(ERoles.Manager.ToString()))
                {
                    if (Request["show"] != null)
                    {
                        show = true;
                    }
                    else
                    {
                        show = false;
                        edit = false;
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx");
                    
                }
            }
        }

        protected void tbPreBalance_TextChanged(object sender, EventArgs e)
        {
            //tbTIncome.Text = getSum(tbPreBalance.Text,tbIncome.Text);
            //tbIncome.Focus();
        }

        private string getSum(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                a = "0";
            }
            if (string.IsNullOrEmpty(b))
            {
                b = "0";
            }
            Decimal x = Convert.ToDecimal(a);
            Decimal y = Convert.ToDecimal(b);
            return (x + y).ToString();
        }

        private string getSum(string a, string b, string c)
        {
            if (string.IsNullOrEmpty(a))
            {
                a = "0";
            }
            if (string.IsNullOrEmpty(b))
            {
                b = "0";
            }
            if (string.IsNullOrEmpty(c))
            {
                c = "0";
            }
            Decimal x = Convert.ToDecimal(a);
            Decimal y = Convert.ToDecimal(b);
            Decimal z = Convert.ToDecimal(c);
            return (x + y + z).ToString();
        }

        private string getSub(string big, string small)
        {
            if (string.IsNullOrEmpty(big))
            {
                big = "0";
            }
            if (string.IsNullOrEmpty(small))
            {
                small = "0";
            }
            Decimal x = Convert.ToDecimal(big);
            Decimal y = Convert.ToDecimal(small);
            return (x-y).ToString();
        }

        private string getSub(string big, string smallA, string smallB)
        {
            if (string.IsNullOrEmpty(big))
            {
                big = "0";
            }
            if (string.IsNullOrEmpty(smallA))
            {
                smallA = "0";
            }
            if (string.IsNullOrEmpty(smallB))
            {
                smallB = "0";
            }
            Decimal x = Convert.ToDecimal(big);
            Decimal y = Convert.ToDecimal(smallA);
            Decimal z = Convert.ToDecimal(smallB);
            return (x - (y+z)).ToString();
        }

        //protected void tbIncome_TextChanged(object sender, EventArgs e)
        //{
        //    tbTIncome.Text = getSum(tbPreBalance.Text, tbIncome.Text);
        //    //tbSales.Focus();
        //}

        //protected void tbSales_TextChanged(object sender, EventArgs e)
        //{
        //    tbMigBalance.Text = getSub(tbTIncome.Text , tbSales.Text);
        //    //tbOPreBalance.Focus();
        //}


   

        protected void tbCPreBalance_TextChanged(object sender, EventArgs e)
        {
            tbCTotal.Text = getSub(getSum(tbCIncome.Text, tbCPreBalance.Text), tbCExpenses.Text);
            //tbOMigBlanace.Text = getSub(tbOTBalance.Text, tbOExpenses.Text);
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCBank.Text);
        }





 

        protected void tbCBank_TextChanged(object sender, EventArgs e)
        {
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCBank.Text);
            decimal dm = Convert.ToDecimal(tbCBank.Text);
            if (dm > 0)
            {
                // get the date 
                lblBankDate.Visible = true;
                tbBankDate.Visible = true;
                tbBankDate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
            }
            else
            {
                lblBankDate.Visible = false;
                tbBankDate.Visible = false;
            }
        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tbDate.Text)))
            {
                DateTime date = Convert.ToDateTime(tbDate.Text);
                if (show)
                {
                    BuffetReport buff = new BuffetReport();
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var re = club.getBuffetExpenseReport(date).First();
                        if (string.IsNullOrEmpty(re.CBalance))
                        {
                            reset();
                            lblError.Visible = true;
                            lblError.Text = "لا يوجد بيانات لعرضها";
                        }
                        else
                        {
                            cbEdit.Visible = true;
                            // cash
                            tbCBank.Text = re.CBank;
                            
                            tbCExpenses.Text = re.CExpenses;
                            tbCIncome.Text = re.CInvIncome;
                            tbCMigBalance.Text = re.CMigBalance;
                            tbCPreBalance.Text = re.CPreBalance;
                            tbCTotal.Text = re.CBalance;

                            // buffet
                            //tbMigBalance.Text = re.BMigBalance;
                            //tbIncome.Text = re.BPurchase;
                            //tbTIncome.Text = re.BBalance;
                            //tbSales.Text = re.BSales;
                            //tbPreBalance.Text = re.BPreBalance;
                            Date = date;
                            // expenses
                            //tbOBalance.Text = re.EPlusBalance;
                            //tbOExpenses.Text = re.EExpenses;
                            //tbOMigBlanace.Text = re.EMigBalance;
                            //tbOPreBalance.Text = re.EPreBalance;
                            //tbOTBalance.Text = re.EBalance;

                            readOnly(true);
                        }
                    }
                }
                else
                {
                    DateTime predate = date.AddDays(-1);
                    string day = cul.DateTimeFormat.DayNames[(int)date.DayOfWeek];
                    if (day == "Saturday")
                    {
                        predate = date.AddDays(-2);
                    }
                    
                    using (ClubDBEntities club = new ClubDBEntities())
                    {
                        var buffet = (from o in club.BuffetMovs
                                      where o.Date == predate
                                      select o.MigBalance).FirstOrDefault();
                        var cash = (from o in club.CashMovs
                                    where o.Date == predate
                                    select o.MigBalance).FirstOrDefault();
                        var ex = (from o in club.ExpensesMovs
                                  where o.Date == predate
                                  select o.MigBalance).FirstOrDefault();

                        //tbPreBalance.Text = buffet.ToString("0.00");
                        tbCPreBalance.Text = cash.ToString("0.00");
                       

                        // get income
                        var sum = club.Deposits.Where(a => a.Date == date).Sum(a => (decimal?)a.Amount);
                        tbCIncome.Text = sum == null? "0" : sum.ToString();
                        var exp = club.Withdraws.Where(a => a.Date == date && a.BankID == null).Sum(a => (decimal?)a.Amount);
                        tbCExpenses.Text = exp == null ? "0": exp.ToString();
                        tbCTotal.Text = getSub(getSum(tbCIncome.Text, tbCPreBalance.Text), tbCExpenses.Text);
                        //tbOMigBlanace.Text = getSub(tbOTBalance.Text, tbOExpenses.Text);
                        tbCMigBalance.Text = getSub(tbCTotal.Text,tbCBank.Text);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo(edit);
        }

        private void SaveInfo(bool ed)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                DateTime date = Convert.ToDateTime(tbDate.Text);
                if (ed)
                {
                    var re = club.CashMovs.Where(a => a.Date == date).First();
                    re.Balance = Convert.ToDecimal(tbCTotal.Text);
                    re.Bank = Convert.ToDecimal(tbCBank.Text);
                    re.BuffetIncome = 0;
                    re.Expenses = Convert.ToDecimal(tbCExpenses.Text);
                    re.InvIncome = Convert.ToDecimal(tbCIncome.Text);
                    re.MigBalance = Convert.ToDecimal(tbCMigBalance.Text);
                    re.PreBalance = Convert.ToDecimal(tbCPreBalance.Text);
                    if (re.Bank > 0)
                    {
                        BankTran b = new BankTran();
                        b.Amount = re.Bank;
                        b.Note = "إيداع نقدي";
                        b.Date = Convert.ToDateTime(tbBankDate.Text);
                        club.BankTrans.AddObject(b);
                        re.BankID = b.ID;
                    }
                    else if (re.Bank == 0)
                    {
                        var b = club.BankTrans.Where(a => a.ID == re.BankID).FirstOrDefault();
                        if (b != null)
                        {
                            club.BankTrans.DeleteObject(b);
                        }
                    }
                }
                else
                {
                    
                    // buffet
                    //BuffetMov buff = new BuffetMov();
                    //buff.Date = date;
                    //buff.Balance = Convert.ToDecimal(tbTIncome.Text);
                    //buff.PreBalance = Convert.ToDecimal(tbPreBalance.Text);
                    //buff.MigBalance = Convert.ToDecimal(tbMigBalance.Text);
                    //buff.Purchase = Convert.ToDecimal(tbIncome.Text);
                    //buff.Sales = Convert.ToDecimal(tbSales.Text);
                    //club.BuffetMovs.AddObject(buff);

                    // ohda
                    //ExpensesMov ex = new ExpensesMov();
                    //ex.Date = date;
                    //ex.Balance = 0;
                    //ex.Expenses = 0;
                    //ex.MigBalance = 0;
                    //ex.PlusBalance = 0;
                    //ex.PreBalance = 0;
                    //club.ExpensesMovs.AddObject(ex);

                    // cash 
                    CashMov cash = new CashMov();
                    cash.Date = date;
                    cash.Balance = Convert.ToDecimal(tbCTotal.Text);
                    cash.Bank = Convert.ToDecimal(tbCBank.Text);
                    cash.BuffetIncome = 0;
                    cash.Expenses = Convert.ToDecimal(tbCExpenses.Text);
                    cash.InvIncome = Convert.ToDecimal(tbCIncome.Text);
                    cash.MigBalance = Convert.ToDecimal(tbCMigBalance.Text);
                    cash.PreBalance = Convert.ToDecimal(tbCPreBalance.Text);
                    club.CashMovs.AddObject(cash);

                    // bank
                    if (cash.Bank > 0)
                    {
                        BankTran b = new BankTran();
                        b.Amount = cash.Bank;
                        b.Note = "إيداع نقدي";
                        b.Date = Convert.ToDateTime(tbBankDate.Text);
                        club.BankTrans.AddObject(b);
                        cash.BankID = b.ID;
                    }
                }
                try
                {
                    club.SaveChanges();
                    
                    saved = true;
                    Date = date;
                    lblError.Visible = false;
                    string Message = " تم حفظ المعلومات  ";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
                }
                catch
                {
                    lblError.Text = "خطأ في التاريخ. الرجاء التأكد من المعلومات";
                    lblError.Visible = true;
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                SaveInfo(true);
            }
            Response.Redirect("ReportViewer.aspx?type=13&date="+Date);
            //BuffetMovCR report = new BuffetMovCR();
            //report.Load(Server.MapPath("BuffetMovCR.rpt"));
            //ClubDBEntities club = new ClubDBEntities();
            //report.SetDataSource(club.getBuffetExpenseReport(Date));
            //string printer = ClubWebApp.Properties.Settings.Default.DefaultPrinter;
            //report.PrintOptions.PrinterName = printer;
            //report.PrintToPrinter(1, false, 0, 0);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            tbCBank.Text = "";
           
            tbCExpenses.Text = "";
            tbCIncome.Text = "";
            tbCMigBalance.Text = "";
            tbCPreBalance.Text = "";
            tbCTotal.Text = "";
            tbDate.Text = "";
            cbEdit.Visible = false;
            //tbIncome.Text = "";
            //tbMigBalance.Text = "";
            //tbPreBalance.Text = "";
            //tbSales.Text = "";
            //tbTIncome.Text = "";
            saved = false;
            lblError.Visible = false;
        }

        private void readOnly(bool re)
        {
            tbCBank.ReadOnly = re;
            tbCExpenses.ReadOnly = re;
            tbCIncome.ReadOnly = re;
            tbCMigBalance.ReadOnly = re;
            tbCPreBalance.ReadOnly = re;
            tbCTotal.ReadOnly = re;
            //tbDate.ReadOnly = true;
            //tbIncome.ReadOnly = true;
            //tbMigBalance.ReadOnly = true;
            //tbPreBalance.ReadOnly = true;
            //tbSales.ReadOnly = true;
            //tbTIncome.ReadOnly = true;
            saved = re;
            lblError.Visible = false;
            btnSave.Visible= false;
            btnReset.Visible = false;

        }

        protected void cbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEdit.Checked)
            {
                edit = true;
                tbCBank.ReadOnly = false;
                btnSave.Visible = true;
            }
            else
            {
                readOnly(true);
            }
        }

        protected void ibPreBalance_Click(object sender, ImageClickEventArgs e)
        {
            DateTime date = Convert.ToDateTime(tbDate.Text);
            DateTime predate = date.AddDays(-1);
            string day = cul.DateTimeFormat.DayNames[(int)date.DayOfWeek];
            if (day == "Saturday")
            {
                predate = date.AddDays(-2);
            }
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.CashMovs.Where(a => a.Date == predate).FirstOrDefault();
                tbCPreBalance.Text = result != null ? result.MigBalance.ToString("0.00") : "0";
            }
            tbCTotal.Text = getSub(getSum(tbCIncome.Text, tbCPreBalance.Text), tbCExpenses.Text);
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCBank.Text);
        }

        protected void inIncome_Click(object sender, ImageClickEventArgs e)
        {
            DateTime date = Convert.ToDateTime(tbDate.Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var sum = club.Deposits.Where(a => a.Date == date).Sum(a => (decimal?)a.Amount);
                tbCIncome.Text = sum == null ? "0" : sum.ToString();
            }
            tbCTotal.Text = getSub(getSum(tbCIncome.Text, tbCPreBalance.Text), tbCExpenses.Text);
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCBank.Text);
        }

        protected void ibExpenses_Click(object sender, ImageClickEventArgs e)
        {
            DateTime date = Convert.ToDateTime(tbDate.Text);
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var exp = club.Withdraws.Where(a => a.Date == date && a.BankID == null).Sum(a => (decimal?)a.Amount);
                tbCExpenses.Text = exp == null ? "0" : exp.ToString();
            }
            tbCTotal.Text = getSub(getSum(tbCIncome.Text, tbCPreBalance.Text), tbCExpenses.Text);
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCBank.Text);
        }

       

        

     

  
    }
}