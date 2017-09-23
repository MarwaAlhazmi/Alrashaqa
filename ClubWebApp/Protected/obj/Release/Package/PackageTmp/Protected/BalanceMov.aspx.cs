using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClubWebApp.Protected;
using System.Web.Security;

namespace ClubWebApp
{
    public partial class BalanceMov : System.Web.UI.Page
    {
        private static bool saved;
        private static DateTime Date;
        private static bool show;
        
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
                }
                else
                {
                    Response.Redirect("Error.aspx");
                    
                }
            }
        }

        protected void tbPreBalance_TextChanged(object sender, EventArgs e)
        {
            tbTIncome.Text = getSum(tbPreBalance.Text,tbIncome.Text);
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

        protected void tbIncome_TextChanged(object sender, EventArgs e)
        {
            tbTIncome.Text = getSum(tbPreBalance.Text, tbIncome.Text);
            //tbSales.Focus();
        }

        protected void tbSales_TextChanged(object sender, EventArgs e)
        {
            tbMigBalance.Text = getSub(tbTIncome.Text , tbSales.Text);
            //tbOPreBalance.Focus();
        }

        protected void tbOPreBalance_TextChanged(object sender, EventArgs e)
        {
            tbOTBalance.Text = getSum(tbOPreBalance.Text, tbOBalance.Text);
        }

        protected void tbOBalance_TextChanged(object sender, EventArgs e)
        {
            tbOTBalance.Text = getSum(tbOPreBalance.Text, tbOBalance.Text);
        }

        protected void tbOExpenses_TextChanged(object sender, EventArgs e)
        {
            tbOMigBlanace.Text = getSub(tbOTBalance.Text , tbOExpenses.Text);
        }

        protected void tbCPreBalance_TextChanged(object sender, EventArgs e)
        {
            tbCTotal.Text = getSum(tbCPreBalance.Text, tbCIncome.Text, tbCBuffet.Text);
        }

        protected void tbCIncome_TextChanged(object sender, EventArgs e)
        {
            tbCTotal.Text = getSum(tbCPreBalance.Text, tbCIncome.Text, tbCBuffet.Text);
        }

        protected void tbCBuffet_TextChanged(object sender, EventArgs e)
        {
            tbCTotal.Text = getSum(tbCPreBalance.Text, tbCIncome.Text, tbCBuffet.Text);
        }

        protected void tbCExpenses_TextChanged(object sender, EventArgs e)
        {
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCExpenses.Text, tbCBank.Text);
        }

        protected void tbCBank_TextChanged(object sender, EventArgs e)
        {
            tbCMigBalance.Text = getSub(tbCTotal.Text, tbCExpenses.Text, tbCBank.Text);
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
                        if (string.IsNullOrEmpty(re.BBalance))
                        {
                            lblError.Visible = true;
                            lblError.Text = "لا يوجد بيانات لعرضها";
                        }
                        else
                        {
                            // cash
                            tbCBank.Text = re.CBalance;
                            tbCBuffet.Text = re.CBuffetIncome;
                            tbCExpenses.Text = re.CExpenses;
                            tbCIncome.Text = re.CInvIncome;
                            tbCMigBalance.Text = re.CMigBalance;
                            tbCPreBalance.Text = re.CPreBalance;
                            tbCTotal.Text = re.CBalance;

                            // buffet
                            tbMigBalance.Text = re.BMigBalance;
                            tbIncome.Text = re.BPurchase;
                            tbTIncome.Text = re.BBalance;
                            tbSales.Text = re.BSales;
                            tbPreBalance.Text = re.BPreBalance;

                            // expenses
                            tbOBalance.Text = re.EPlusBalance;
                            tbOExpenses.Text = re.EExpenses;
                            tbOMigBlanace.Text = re.EMigBalance;
                            tbOPreBalance.Text = re.EPreBalance;
                            tbOTBalance.Text = re.EBalance;

                            readOnly();
                        }
                    }
                }
                else
                {
                    
                    DateTime predate = date.AddDays(-1);
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

                        tbPreBalance.Text = buffet.ToString("0.00");
                        tbCPreBalance.Text = cash.ToString("0.00");
                        tbOPreBalance.Text = ex.ToString("0.00");

                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
            string Message = " تم حفظ المعلومات  ";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{0}');", Message), true);
        }

        private void SaveInfo()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                DateTime date = Convert.ToDateTime(tbDate.Text);
                // buffet
                BuffetMov buff = new BuffetMov();
                buff.Date = date;
                buff.Balance = Convert.ToDecimal(tbTIncome.Text);
                buff.PreBalance = Convert.ToDecimal(tbPreBalance.Text);
                buff.MigBalance = Convert.ToDecimal(tbMigBalance.Text);
                buff.Purchase = Convert.ToDecimal(tbIncome.Text);
                buff.Sales = Convert.ToDecimal(tbSales.Text);
                club.BuffetMovs.AddObject(buff);

                // ohda
                ExpensesMov ex = new ExpensesMov();
                ex.Date = date;
                ex.Balance = Convert.ToDecimal(tbOTBalance.Text);
                ex.Expenses = Convert.ToDecimal(tbOExpenses.Text);
                ex.MigBalance = Convert.ToDecimal(tbOMigBlanace.Text);
                ex.PlusBalance = Convert.ToDecimal(tbOBalance.Text);
                ex.PreBalance = Convert.ToDecimal(tbOPreBalance.Text);
                club.ExpensesMovs.AddObject(ex);

                // cash 
                CashMov cash = new CashMov();
                cash.Date = date;
                cash.Balance = Convert.ToDecimal(tbCTotal.Text);
                cash.Bank = Convert.ToDecimal(tbCBank.Text);
                cash.BuffetIncome = Convert.ToDecimal(tbCBuffet.Text);
                cash.Expenses = Convert.ToDecimal(tbCExpenses.Text);
                cash.InvIncome = Convert.ToDecimal(tbCIncome.Text);
                cash.MigBalance = Convert.ToDecimal(tbCMigBalance.Text);
                cash.PreBalance = Convert.ToDecimal(tbCPreBalance.Text);
                club.CashMovs.AddObject(cash);
                try
                {
                    club.SaveChanges();
                    saved = true;
                    Date = date;
                    lblError.Visible = false;
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
                SaveInfo();
            }

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("BuffetMovCR.rpt"));
            ClubDBEntities club = new ClubDBEntities();
            report.SetDataSource(club.getBuffetExpenseReport(Date));
            string printer = ClubWebApp.Properties.Settings.Default.DefaultPrinter;
            report.PrintOptions.PrinterName = printer;
            report.PrintToPrinter(1, false, 0, 0);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            tbCBank.Text = "";
            tbCBuffet.Text = "";
            tbCExpenses.Text = "";
            tbCIncome.Text = "";
            tbCMigBalance.Text = "";
            tbCPreBalance.Text = "";
            tbCTotal.Text = "";
            tbDate.Text = "";
            tbIncome.Text = "";
            tbMigBalance.Text = "";
            tbOBalance.Text = "";
            tbOExpenses.Text = "";
            tbOMigBlanace.Text = "";
            tbOPreBalance.Text = "";
            tbOTBalance.Text = "";
            tbPreBalance.Text = "";
            tbSales.Text = "";
            tbTIncome.Text = "";
            saved = false;
            lblError.Visible = false;
        }

        private void readOnly()
        {
            tbCBank.ReadOnly = true;
            tbCBuffet.ReadOnly = true;
            tbCExpenses.ReadOnly = true;
            tbCIncome.ReadOnly = true;
            tbCMigBalance.ReadOnly = true;
            tbCPreBalance.ReadOnly = true;
            tbCTotal.ReadOnly = true;
            tbDate.ReadOnly = true;
            tbIncome.ReadOnly = true;
            tbMigBalance.ReadOnly = true;
            tbOBalance.ReadOnly = true;
            tbOExpenses.ReadOnly = true;
            tbOMigBlanace.ReadOnly = true;
            tbOPreBalance.ReadOnly = true;
            tbOTBalance.ReadOnly = true;
            tbPreBalance.ReadOnly = true;
            tbSales.ReadOnly = true;
            tbTIncome.ReadOnly = true;
            saved = true;
            lblError.Visible = false;
            btnSave.Visible= false;
            btnReset.Visible = false;

        }
    }
}