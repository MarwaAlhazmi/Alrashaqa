using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace ClubWebApp.Protected
{
    public partial class Client
    {
        public string FullName()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                string name = FirstName + " " + SecondName + " " + LastName + " " + FamilyName;
                return name;
            }
        }
    }
    public partial class ClubDBEntities
    {
        public IEnumerable<IncompleteInv> getIncompleteInvoices()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.InvoiceHeaders.Where(a => a.FinalAmount > club.Deposits.Where(o => o.InvID == a.InvID).Sum(l => (int?)l.Amount)).ToList().Select(i => new IncompleteInv()
                {
                    InvID = i.InvID.ToString(),
                    FileID = i.ClientID.ToString(),
                    Date = i.Date.ToString("dd/MM/yyyy"),
                    ClientName = i.Client.FullName(),
                    Amount = i.FinalAmount.ToString("0.00"),
                    EmpName = i.RecepName,
                    Remain = (i.FinalAmount - club.Deposits.Where(a => a.InvID == i.InvID).Sum(o => o.Amount)).ToString()
                }).ToList();
                return result;
            }
        }

        public IEnumerable<InvoiceReport> getInvoice(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.InvoiceHeaders.Where(a => a.Date == date).ToList().Select(o => new InvoiceReport() { 
                    ClientName = o.Client.FullName(),
                    Date = o.Date.ToString("dd/MM/yyyy"),
                    Discount = o.Discount.ToString(),
                    FileID = o.ClientID.ToString(),
                    FinalAmount = o.FinalAmount.ToString("0.00"),
                    InvoiceID = o.InvID.ToString(),
                    PaidAmount = club.Deposits.Where(a => a.InvID == o.InvID).Count() == 0 ? "0" : club.Deposits.Where(a => a.InvID == o.InvID).Sum(a => a.Amount).ToString("0.00"),
                    Receptionist = o.RecepName,
                    RemainAmount = (o.FinalAmount - (club.Deposits.Where(a=> a.InvID == o.InvID).Count() == 0? 0:club.Deposits.Where(a=> a.InvID == o.InvID).Sum(a=>a.Amount))).ToString("0.00"),
                    TotalAmount = o.TotalAmount.ToString("0.00"),
                    Notes = o.Notes,
                }).ToList();
                return result.AsEnumerable();
            }
        }

        public IEnumerable<InvoiceReport> getInvoice(int invID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.InvoiceHeaders.Where(a => a.InvID == invID).ToList().Select(o => new InvoiceReport()
                {
                    ClientName = o.Client.FullName(),
                    Date = o.Date.ToString("dd/MM/yyyy"),
                    Discount = o.Discount.ToString(),
                    FileID = o.ClientID.ToString(),
                    FinalAmount = o.FinalAmount.ToString("0.00"),
                    InvoiceID = o.InvID.ToString(),
                    PaidAmount = club.Deposits.Where(a => a.InvID == o.InvID).Count() == 0 ? "0" : club.Deposits.Where(a => a.InvID == o.InvID).Sum(a => a.Amount).ToString("0.00"),
                    Receptionist = o.RecepName,
                    RemainAmount = (o.FinalAmount - (club.Deposits.Where(a => a.InvID == o.InvID).Count() == 0? 0 : club.Deposits.Where(a => a.InvID == o.InvID).Sum(a => a.Amount))).ToString("0.00"),
                    TotalAmount = o.TotalAmount.ToString("0.00"),
                    Notes = o.Notes,
                }).ToList();
                return result.AsEnumerable();
            }
        }

        public IEnumerable<InvoiceReport> getInvoice(string FileID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int id = Convert.ToInt32(FileID);
                var result = club.InvoiceHeaders.Where(a => a.ClientID == id).ToList().Select(o => new InvoiceReport()
                {
                    ClientName = o.Client.FullName(),
                    Date = o.Date.ToString("dd/MM/yyyy"),
                    Discount = o.Discount.ToString(),
                    FileID = o.ClientID.ToString(),
                    FinalAmount = o.FinalAmount.ToString("0.00"),
                    InvoiceID = o.InvID.ToString(),
                    PaidAmount = club.Deposits.Where(a => a.InvID == o.InvID).Count() == 0 ? "0" : club.Deposits.Where(a => a.InvID == o.InvID).Sum(a => a.Amount).ToString("0.00"),
                    Receptionist = o.RecepName,
                    RemainAmount = (o.FinalAmount - (club.Deposits.Where(a => a.InvID == o.InvID).Count() == 0 ? 0 : club.Deposits.Where(a => a.InvID == o.InvID).Sum(a => a.Amount))).ToString("0.00"),
                    TotalAmount = o.TotalAmount.ToString("0.00"),
                    Notes = o.Notes,
                }).ToList();
                return result.AsEnumerable();
            }
        }
        public IEnumerable<InvoiceReport> getInvoiceHeader(int invID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                //var result = club.InvoiceHeaders.Where(a => a.InvID == invID);
                // get the services
                var result = club.InvoiceServices.Where(a => a.InvID == invID).ToList().Select(
                                                                                        a => new InvoiceReport
                                                                                        {
                                                                                            ServiceName = a.Service.Name,
                                                                                            ServicePrice = a.Service.Price.ToString("0.00")
                                                                                        }).ToList(); ;

                var invoice = club.InvoiceHeaders.Where(a => a.InvID == invID).First();
                var paid = club.Deposits.Where(a => a.InvID == invID).Count() == 0 ? 0 : club.Deposits.Where(a => a.InvID == invID).Sum(a => a.Amount);
                var remain = invoice.FinalAmount - paid;
                foreach (var row in result)
                {
                    row.ClientName = invoice.Client.FullName();
                    row.Date = invoice.Date.ToString("dd/MM/yyyy");
                    row.Discount = invoice.Discount.ToString();
                    row.FileID = invoice.ClientID.ToString();
                    row.FinalAmount = invoice.FinalAmount.ToString("0.00");
                    row.InvoiceID = invoice.InvID.ToString();
                    row.PaidAmount = paid.ToString("0.00");
                    row.Receptionist = invoice.RecepName;
                    row.RemainAmount = remain.ToString("0.00");
                    row.TotalAmount = invoice.TotalAmount.ToString("0.00");
                    row.Notes = invoice.Notes;
                }
                return result;
            }
        }



        public List<Subs> getSubs(int ClientID)
        {
            ClubDBEntities club = new ClubDBEntities();
            var sub = club.Subscribtions.Include("Service")
                      .Where(i => i.ClientID == ClientID)
                      .ToList()
                      .Select(item =>
                                new Subs
                                {
                                    ServiceName = item.Service.Name,
                                    DaysLeft = item.LeftDays,
                                    SubDate = item.Date,
                                    SubID = item.SubID
                                }).ToList();
            return sub;
        }

        public IEnumerable<TodayVisits> getVisitsByDate(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Visits.Where(a => a.Date == date).ToList().Select(a => new TodayVisits()
                {
                    ClientID = a.ClientID.ToString(),
                    ClientName = a.Client.FullName(),
                    Sub = a.Subscribtion.Service.Name,
                    Time = a.SigninTime.ToString()
                }).ToList();
                return result;
            }
        }

        public IEnumerable<SubDetails> getSubDetails(int subID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {

                var result = club.Subscribtions.Where(a => a.SubID == subID).ToList()
                                                .Select(item => new SubDetails
                                                {
                                                    ServiceName = item.Service.Name,
                                                    SubDate = item.Date,
                                                    TotalDays = item.SubDays,
                                                    AttDays = item.AttDays,
                                                    LeftDays = item.LeftDays,
                                                    Measurements = item.Measurements,
                                                    Diagnosis = item.Diagnosis,
                                                    History = item.History,
                                                }).First();

                // get rest of data if there is any
                var nut = (from n in club.NutSubs
                           where n.SubID == subID
                           select n).FirstOrDefault();
                var iint = (from n in club.IntSubs
                            where n.SubID == subID
                            select n).FirstOrDefault();
                if (!(nut == null))
                {
                    result.Fat = nut.Fat;
                    result.Hieght = nut.Hight;
                    result.Weight = nut.Weight;

                }
                else if (!(iint == null))
                {
                    result.BPressure = iint.BloodPressure;
                    result.BSugar = iint.BloodSugar;
                }

                List<SubDetails> ii = new List<SubDetails>();
                ii.Add(result);

                return ii.AsEnumerable();
            }
        }






        public IEnumerable<VisitReport> getVisitReport(int subID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var visitResult = club.Visits.Where(a => a.SubID == subID).ToList().Select(s => new VisitReport()
                {
                    DateOfVisit = s.Date.ToShortDateString(),
                    SigninTime = s.SigninTime.ToString(),
                    SizeAfter = s.SizeAfter,
                    SizeBefore = s.SizeBefore
                }).ToList();

                var rest = (from o in club.Subscribtions
                            where o.SubID == subID
                            select new
                            {
                                serviceName = o.Service.Name,
                                fileID = o.ClientID,
                                clientName = o.Client.FirstName + " " + o.Client.SecondName + " " + o.Client.LastName + " " + o.Client.FamilyName,
                                dateOfSub = o.Date
                            }).First();
                int index = 1;
                foreach (var row in visitResult)
                {
                    row.DateOfSub = rest.dateOfSub.ToShortDateString();
                    row.FileID = rest.fileID.ToString();
                    row.Name = rest.clientName;
                    row.ServiceName = rest.serviceName;
                    row.Ser = index.ToString();
                    index++;
                }

                return (visitResult.AsEnumerable());

            }
        }

        public IEnumerable<WithdrawReport> getWithReport(int WithID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Withdraws.Where(a => a.ID == WithID).ToList().Select(o => new WithdrawReport()
                {
                    Amount = o.Amount.ToString("0.00"),
                    AmountW = o.AmountW,
                    Bank = o.BankName,
                    CheckNum = o.CheckNum.ToString(),
                    Date = o.Date.ToString("dd/MM/yyyy"),
                    EmployeeName = o.Employee.Name,
                    ID = o.ID.ToString(),
                    Notes = o.Notes,
                    ToPerson = o.ToPerson,
                }).ToList();

                return result.AsEnumerable();
            }
        }

        public IEnumerable<WithdrawReport> getDepositReport(int depID)
        {
            using (ClubDBEntities club = new ClubDBEntities()) 
            {
                var result = club.Deposits.Where(a => a.ID == depID).ToList().Select(o => new WithdrawReport() { 
                Amount = o.Amount.ToString("0.00"),
                AmountW = o.AmountW,
                Bank = o.Bank,
                InvNum = o.InvID.ToString(),
                PrePaid = club.Deposits.Where(a => a.InvID == o.InvID && a.ID != depID && a.Date < o.Date).Sum(a => (decimal?)a.Amount).HasValue ? club.Deposits.Where(a => a.InvID == o.InvID && a.ID != depID && a.Date < o.Date).Sum(a => a.Amount).ToString() : "0",
                CheckNum = o.CheckNum.ToString(),
                Date = o.Date.ToString("yyyy/MM/dd"),
                EmployeeName = o.Employee,
                ID = o.ID.ToString(),
                Notes = o.Notes,
                ToPerson = o.InvoiceHeader.Client.FullName(),
                }).ToList();

                return result.AsEnumerable();
            }
        }

        public IEnumerable<IncomeReport> getIncomeReport(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int month = date.Month;
                int year = date.Year;
                DateTime start = new DateTime(year,month,1);
                DateTime end = start.AddMonths(1).AddDays(-1);
                CultureInfo cul = new CultureInfo("ar-SA");
                List<IncomeReport> result = new List<IncomeReport>();
                IncomeReport one;
                int index =1;
                for (DateTime d = start; d <= end; d=d.AddDays(1))
                {
                    one = new IncomeReport();
                    one.Ser = index.ToString();
                    one.Date = d.ToString("yyyy/MM/dd");
                    one.Income = club.Deposits.Where(a => a.Date == d).Count() == 0 ? "0" : club.Deposits.Where(a => a.Date == d).Sum(a=>a.Amount).ToString("0.00");
                    one.Day = cul.DateTimeFormat.DayNames[(int)d.DayOfWeek];
                    one.Withdrawl = club.Withdraws.Where(a => a.Date == d && a.BankID == null).Sum(a => (decimal?)a.Amount) == null ? "0" : club.Withdraws.Where(a => a.Date == d && a.BankID == null).Sum(a => (decimal)a.Amount).ToString("0.00");
                    one.Total = (Convert.ToDecimal(one.Income) - Convert.ToDecimal(one.Withdrawl)).ToString();
                    result.Add(one);
                    index++;
                }
                return result;

            }
        }

        public IEnumerable<ExpenseReport> getExpenseReport(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int month = date.Month;
                int year = date.Year;
                CultureInfo cul = new CultureInfo("ar-SA");
                var result = club.Withdraws.Where(a => a.Date.Month == month && a.Date.Year == year && a.BankID == null).OrderBy(q => q.Date).ToList().Select(i => new ExpenseReport()
                {
                    Date = i.Date.ToString("yyyy/MM/dd"),
                    Day = cul.DateTimeFormat.DayNames[(int)i.Date.DayOfWeek],
                    InvNum = i.ID.ToString(),
                    InvAmount = i.Amount.ToString("0.00"),
                    Note = i.Notes
                }).ToList();
                int index = 1;
                foreach (var row in result)
                {
                    row.Ser = index.ToString();
                    index++;
                }
                return result;
            }
        }

        public IEnumerable<MovReport> getMovReport(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Deposits.Where(i => i.Date == date).ToList().Select(i => new MovReport()
                {
                    ClientName = i.InvoiceHeader.Client.FullName(),
                    Phone = i.InvoiceHeader.Client.Phone.ToString(),
                    InvNum = i.InvID.ToString(),
                    VoucherNum = i.ID.ToString(),
                    Amount = i.InvoiceHeader.FinalAmount.ToString("0.00"),
                    Services = arrayToString(club.InvoiceServices.Where(p=> p.InvID == i.InvoiceHeader.InvID).Select(o => o.Service.Name)),
                    Notes = i.Notes,
                    Paid = i.Amount.ToString("0.00"),
                    Date = date.ToString("dd/MM/yyyy"),
                }).ToList();
                int index = 1;
                foreach (var row in result)
                {
                    row.Ser = index.ToString();
                    index++;
                    int invNum = Convert.ToInt32(row.InvNum);
                    var r = (from o in club.Deposits
                             where o.Date != date && o.InvID == invNum
                             select o.Amount);
                    if (r.Count() <= 0)
                    {
                        row.PrePaid = "0";
                    }
                    else
                    {
                        row.PrePaid = r.Sum().ToString();
                    }
                    row.Remain = (Convert.ToDecimal(row.Amount) - Convert.ToDecimal(row.PrePaid) - Convert.ToDecimal(row.Paid)).ToString();
                }
                return result;
            }
        }

        public IEnumerable<JointReport> getMovReportWithCash(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Deposits.Where(i => i.Date == date).ToList().Select(i => new JointReport()
                {
                    ClientName = i.InvoiceHeader.Client.FullName(),
                    FileID = i.InvoiceHeader.ClientID.ToString(),
                    Phone = i.InvoiceHeader.Client.Phone.ToString(),
                    InvNum = i.InvID.ToString(),
                    VoucherNum = i.ID.ToString(),
                    Amount = i.InvoiceHeader.FinalAmount.ToString("0.00"),
                    Services = arrayToString(club.InvoiceServices.Where(p => p.InvID == i.InvoiceHeader.InvID).Select(o => o.Service.Name)),
                    Notes = i.Notes,
                    Paid = i.Amount.ToString("0.00"),
                    Date = date.ToString("dd/MM/yyyy"),

                }).ToList();
                int index = 1;
                var cresult = (from o in club.CashMovs
                               where o.Date == date
                               select o).FirstOrDefault();
               
                foreach (var row in result)
                {
                     if (cresult != null)
                        {
                            //row.Date = date.ToString("yyyy/MM/dd");
                            row.CBalance = cresult.Balance.ToString("0.00");
                            row.CBank = cresult.Bank.ToString("0.00");
                            row.CExpenses = cresult.Expenses.ToString("0.00");
                            row.CInvIncome = cresult.InvIncome.ToString("0.00");
                            row.CMigBalance = cresult.MigBalance.ToString("0.00");
                            row.CPreBalance = cresult.PreBalance.ToString("0.00");
                        }
                    row.Ser = index.ToString();
                    index++;
                    int invNum = Convert.ToInt32(row.InvNum);
                    var r = (from o in club.Deposits
                             where o.Date != date && o.InvID == invNum
                             select o.Amount);
                    if (r.Count() <= 0)
                    {
                        row.PrePaid = "0";
                    }
                    else
                    {
                        row.PrePaid = r.Sum().ToString();
                    }
                    row.Remain = (Convert.ToDecimal(row.Amount) - Convert.ToDecimal(row.PrePaid) - Convert.ToDecimal(row.Paid)).ToString();
                }
                

                return result;
            }
        }
        //private void test(int dep, DateTime date)
        //{
        //    using (ClubDBEntities club = new ClubDBEntities())
        //    {
        //        var invoice = club.Deposits.Where(a => a.Date == date).Where(i => i.InvoiceHeader.InvoiceServices.Any(p=>p.Service.DepID == dep)).ToList().Select(a=> new { 
        //        invoiceDiscount = a.InvoiceHeader.Discount,
        //        invoiceAmount = a.InvoiceHeader.FinalAmount,
        //        depositAmount = a.Amount,
        //        services = a.InvoiceHeader.InvoiceServices,
        //        });
        //        foreach(var row in invoice)
        //        {

        //        }

                
        //       // var service = invoice.services.Services.where(a=> a.DepID == dep).ToList().Select(a=> new {
        //        //serviceAmount = a.percentage * depositamount
                  
        //       // });
                 
        //        // Do calculations
                
                
        //    }
        //}
        public IEnumerable<MovReport> getMovReport(DateTime date, int dep)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Deposits.Where(i => i.Date == date).Where(i => i.InvoiceHeader.InvoiceServices.Any(p=>p.Service.DepID == dep)).ToList().Select(i => new MovReport()
                {
                    ClientName = i.InvoiceHeader.Client.FullName(),
                    Phone = i.InvoiceHeader.Client.Phone.ToString(),
                    InvNum = i.InvID.ToString(),
                    VoucherNum = i.ID.ToString(),
                    Amount = i.InvoiceHeader.InvoiceServices.Where(p=>p.Service.DepID == dep).Sum(p=> p.AskedAmount).ToString("0.00"), //i.InvoiceHeader.FinalAmount.ToString("0.00"),
                    Services = arrayToString(i.InvoiceHeader.InvoiceServices.Where(p=>p.Service.DepID == dep).Select(o => o.Service.Name)),
                    Notes = i.Notes,
                    Paid = (club.Deposits.Where(a => a.InvID == i.InvID && a.Date == date).Sum(a => (decimal?)a.Amount) * (i.InvoiceHeader.InvoiceServices.Where(p => p.Service.DepID == dep).Where(p=> p.InvID == i.InvID).Sum(a=>(decimal?)a.Percentage))).ToString(),
                    PrePaid = (club.Deposits.Where(a => a.InvID == i.InvID && a.Date != date).Sum(a => (decimal?)a.Amount) * i.InvoiceHeader.InvoiceServices.Where(p => p.Service.DepID == dep).Where(p => p.InvID == i.InvID).Sum(a => (decimal?)a.Percentage)).ToString(),
                    Remain = (i.InvoiceHeader.InvoiceServices.Where(p => p.Service.DepID == dep).Sum(p => (decimal?)p.AskedAmount) - i.InvoiceHeader.InvoiceServices.Where(p => p.Service.DepID == dep).Sum(p => (decimal?)p.PaidAmount)).ToString(),
                    Date = date.ToString("dd/MM/yyyy"),
                }).ToList();
                int index = 1;
                foreach (var row in result)
                {
                    row.Ser = index.ToString();
                    index++;
                    if (string.IsNullOrEmpty(row.Paid))
                    {
                        row.Paid = "0";
                    }
                    else
                    {
                        decimal h = Convert.ToDecimal(row.Paid);
                        h = Math.Round(h);
                        row.Paid = h.ToString("0.00");
                    }
                    if (string.IsNullOrEmpty(row.PrePaid))
                    {
                        row.PrePaid = "0";
                    }
                    else
                    {
                        decimal h = Convert.ToDecimal(row.PrePaid);
                        h = Math.Round(h);
                        row.PrePaid = h.ToString("0.00");
                    }
                    if (string.IsNullOrEmpty(row.Remain))
                    {
                        row.Remain = "0";
                    }
                    else
                    {
                        decimal h = Convert.ToDecimal(row.Remain);
                        h = Math.Round(h);
                        row.Remain = h.ToString("0.00");
                    }
                    //int invNum = Convert.ToInt32(row.InvNum);
                    //var r = (from o in club.Deposits
                    //         where o.Date != date && o.InvID == invNum && o.InvoiceHeader.Dep == dep
                    //         select o.Amount);
                    //if (r.Count() <= 0)
                    //{
                    //    row.PrePaid = "0";
                    //}
                    //else
                    //{
                    //    row.PrePaid = r.Sum().ToString();
                    //}
                    //row.Remain = (Convert.ToDecimal(row.Amount) - Convert.ToDecimal(row.PrePaid) - Convert.ToDecimal(row.Paid)).ToString();
                }
                return result;
            }
        }

        private string arrayToString(IEnumerable<string> myString)
        {
            string result = "";
            foreach (string i in myString)
            {
                result += i + " . ";
            }
            return result;
        }

        public IEnumerable<BuffetReport> getBuffetExpenseReport(DateTime date)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var bresult = (from o in club.BuffetMovs
                               where o.Date == date
                               select o).FirstOrDefault();
                var cresult = (from o in club.CashMovs
                               where o.Date == date
                               select o).FirstOrDefault();
                var eresult = (from o in club.ExpensesMovs
                               where o.Date == date
                               select o).FirstOrDefault();
                BuffetReport buffet = new BuffetReport();
                if (eresult != null)
                {
                    buffet.Date = date.ToString("yyyy/MM/dd");
                    buffet.EBalance = eresult.Balance.ToString("0.00");
                    buffet.EExpenses = eresult.Expenses.ToString("0.00");
                    buffet.EMigBalance = eresult.MigBalance.ToString("0.00");
                    buffet.EPlusBalance = eresult.PlusBalance.ToString("0.00");
                    buffet.EPreBalance = eresult.PreBalance.ToString("0.00");

                }
                if (cresult != null)
                {
                    buffet.Date = date.ToString("yyyy/MM/dd");
                    buffet.CBalance = cresult.Balance.ToString("0.00");
                    buffet.CBank = cresult.Bank.ToString("0.00");
                    buffet.CBuffetIncome = cresult.BuffetIncome.ToString("0.00");
                    buffet.CExpenses = cresult.Expenses.ToString("0.00");
                    buffet.CInvIncome = cresult.InvIncome.ToString("0.00");
                    buffet.CMigBalance = cresult.MigBalance.ToString("0.00");
                    buffet.CPreBalance = cresult.PreBalance.ToString("0.00");
                }
                if (bresult != null)
                {
                    buffet.Date = date.ToString("yyyy/MM/dd");
                    buffet.BBalance = bresult.Balance.ToString("0.00");
                    buffet.BMigBalance = bresult.MigBalance.ToString("0.00");
                    buffet.BPreBalance = bresult.PreBalance.ToString("0.00");
                    buffet.BPurchase = bresult.Purchase.ToString("0.00");
                    buffet.BSales = bresult.Sales.ToString("0.00");
                }
                List<BuffetReport> ii = new List<BuffetReport>();
                ii.Add(buffet);
                return ii.AsEnumerable();
            }
        }

        public IEnumerable<EvaluationReport> getEvaluationreport(int EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var re = (from o in club.Evaluations
                          where o.ID == EID
                          select o).First();
                EvaluationReport report = new EvaluationReport();
                report.Assessment = re.Assessment;
                report.Diagnosis = re.Diagnosis;
                report.DOB = re.Client.DOB.ToString();
                report.EmpName = re.Employee.Name;
                report.FileID = re.ClientID.ToString();
                report.Goals = re.Goals;
                report.History = re.History;
                report.Nation = re.Client.Nationality;
                report.Objective = re.Objective;
                report.PatientName = re.Client.FullName();
                report.Phone = re.Client.Phone.ToString();
                report.Date = re.Date.ToString("dd/MM/yyyy");
                report.Treatment = re.Treatment;
                List<EvaluationReport> ll = new List<EvaluationReport>();
                ll.Add(report);
                return ll.AsEnumerable();
            }
        }

        public IEnumerable<EvaluationReport> getEvaluationreport(DateTime EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Evaluations.Where(a => a.Date == EID).ToList().Select(re => new EvaluationReport() { 
                        Assessment = re.Assessment,
                        Diagnosis = re.Diagnosis,
                        DOB = re.Client.DOB.ToString(),
                        EmpName = re.Employee.Name,
                        FileID = re.ClientID.ToString(),
                        Goals = re.Goals,
                        History = re.History,
                        Nation = re.Client.Nationality,
                        Objective = re.Objective,
                        PatientName = re.Client.FullName(),
                        Phone = re.Client.Phone.ToString(),
                        Date = re.Date.ToString("dd/MM/yyyy"),
                        ID = re.ID.ToString(),
                        Treatment = re.Treatment,
                        }).ToList();
                return result;
            }
        }

        public IEnumerable<EvaluationReport> getEvaluationreport(string EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int id = Convert.ToInt32(EID);
                var result = club.Evaluations.Where(a => a.ClientID == id).ToList().Select(re => new EvaluationReport()
                {
                    Assessment = re.Assessment,
                    Diagnosis = re.Diagnosis,
                    DOB = re.Client.DOB.ToString(),
                    EmpName = re.Employee.Name,
                    FileID = re.ClientID.ToString(),
                    Goals = re.Goals,
                    History = re.History,
                    Nation = re.Client.Nationality,
                    Objective = re.Objective,
                    PatientName = re.Client.FullName(),
                    Phone = re.Client.Phone.ToString(),
                    Date = re.Date.ToString("dd/MM/yyyy"),
                    ID = re.ID.ToString(),
                    Treatment = re.Treatment,
                }).ToList();
                return result;
            }
        }
        public IEnumerable<TRequestReport> getTRequestReport(int EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var re = (from o in club.TReaquests
                          where o.ID == EID
                          select o).First();
                TRequestReport report = new TRequestReport();
                report.Diagnosis = re.Diagnosis;
                report.DOB = re.Client.DOB.ToString();
                report.EmpName = re.Employee.Name;
                report.FileID = re.ClientID.ToString();
                report.Goals = re.Goals;
                report.Precaution = re.Precautions;
                report.Nation = re.Client.Nationality;
                report.PatientName = re.Client.FullName();
                report.Phone = re.Client.Phone.ToString();
                report.Date = re.Date.ToString("dd/MM/yyyy");
                List<TRequestReport> ll = new List<TRequestReport>();
                ll.Add(report);
                return ll.AsEnumerable();
            }
        }



        public IEnumerable<DischargeReport> getDischargeReport(int EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var re = (from o in club.Discharges
                          where o.ID == EID
                          select o).First();
                DischargeReport report = new DischargeReport();
                report.Diagnosis = re.Diagnosis;
                report.DOB = re.Client.DOB.ToString();
                report.EmpName = re.Employee.Name;
                report.FileID = re.ClientID.ToString();
                report.Goals = re.Goals;
                report.Nation = re.Client.Nationality;
                report.PatientName = re.Client.FullName();
                report.Phone = re.Client.Phone.ToString();
                report.Date = re.Date.ToString("dd/MM/yyyy");
                report.Comments = re.Comments;
                report.Discharge = re.Discharge1;
                report.FinalSession = re.FinalSession;
                report.GoalsBool = re.GoalsBool;
                report.InitialSession = re.InitialSession;
                report.PreReferral = re.PreReferral;
                report.TotalSessions = re.TotalNSession;
                report.Treatment = re.Treatment;

                List<DischargeReport> ll = new List<DischargeReport>();
                ll.Add(report);
                return ll.AsEnumerable();
            }
        }

        public IEnumerable<DischargeReport> getDischargeReport(DateTime EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var re = club.Discharges.Where(a => a.Date == EID).ToList().Select(a => new DischargeReport() { 
                        Diagnosis = a.Diagnosis,
                        DOB = a.Client.DOB.ToString(),
                        EmpName = a.Employee.Name,
                        FileID = a.ClientID.ToString(),
                        Goals = a.Goals,
                        Nation = a.Client.Nationality,
                        PatientName = a.Client.FullName(),
                        Phone = a.Client.Phone.ToString(),
                        Date = a.Date.ToString("dd/MM/yyyy"),
                        Comments = a.Comments,
                        Discharge = a.Discharge1,
                        FinalSession = a.FinalSession,
                        GoalsBool = a.GoalsBool,
                        InitialSession = a.InitialSession,
                        PreReferral = a.PreReferral,
                        TotalSessions = a.TotalNSession,
                        Treatment = a.Treatment,
                        ID = a.ID.ToString(),
                        }).ToList();
                
                return re;
            }
        }

        public IEnumerable<DischargeReport> getDischargeReport(string EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int id = Convert.ToInt32(EID);
                var re = club.Discharges.Where(a => a.ClientID == id).ToList().Select(a => new DischargeReport()
                {
                    Diagnosis = a.Diagnosis,
                    DOB = a.Client.DOB.ToString(),
                    EmpName = a.Employee.Name,
                    FileID = a.ClientID.ToString(),
                    Goals = a.Goals,
                    Nation = a.Client.Nationality,
                    PatientName = a.Client.FullName(),
                    Phone = a.Client.Phone.ToString(),
                    Date = a.Date.ToString("dd/MM/yyyy"),
                    Comments = a.Comments,
                    Discharge = a.Discharge1,
                    FinalSession = a.FinalSession,
                    GoalsBool = a.GoalsBool,
                    InitialSession = a.InitialSession,
                    PreReferral = a.PreReferral,
                    TotalSessions = a.TotalNSession,
                    Treatment = a.Treatment,
                    ID = a.ID.ToString(),
                }).ToList();

                return re;
            }
        }


        public IEnumerable<TRequestReport> getTRequestReport(DateTime EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var o = club.TReaquests.Where(a => a.Date == EID).ToList().Select(re => new TRequestReport()
                {
                            Diagnosis = re.Diagnosis,
                            EmpName = re.Employee.Name,
                            FileID = re.ClientID.ToString(),
                            PatientName = re.Client.FullName(),
                            Phone = re.Client.Phone.ToString(),
                            Date = re.Date.ToString("dd/MM/yyyy"),
                            ID = re.ID.ToString(),
                }).ToList();

                return o;
            }
        }
        public IEnumerable<TRequestReport> getTRequestReport(string EID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                int id = Convert.ToInt32(EID);
                var o = club.TReaquests.Where(a => a.ClientID == id).ToList().Select(re => new TRequestReport()
                {
                    Diagnosis = re.Diagnosis,
                    EmpName = re.Employee.Name,
                    FileID = re.ClientID.ToString(),
                    PatientName = re.Client.FullName(),
                    Phone = re.Client.Phone.ToString(),
                    Date = re.Date.ToString("dd/MM/yyyy"),
                    ID = re.ID.ToString(),
                }).ToList();

                return o;
            }
        }

        public IEnumerable<EmpReport> getEmployees()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Employees.ToList().Select(a => new EmpReport()
                {
                    Name = a.Name,
                    ID = a.EmpID.ToString(),
                    Phone = a.PhoneNum.ToString(),
                    Dep = a.Type == "Manager"? "إدارة":"عيادات",
                }).ToList();
                return result.AsEnumerable() ;
            }
        }

        public IEnumerable<ServiceReport> getServices()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Services.Where(a=>a.Deleted == false).OrderBy(a => new { a.DepID, a.Name}).ToList().Select(a => new ServiceReport()
                {
                    ID = a.ServiceID.ToString(),
                    Name = a.Name,
                    Price = a.Price.ToString(),
                    Dep = a.Department.Name,
                    SubDays = a.TotalDays.ToString(),
                    SubType = a.Sub ? "اشتراك شهري" : "جلسة واحدة",
                }).ToList();
                return result.AsEnumerable();
            }
        }


        public IEnumerable<EandIReport> getEandIReport(int month, int year, int dep)
        {
            using(ClubDBEntities club = new ClubDBEntities())
            {
                // get the expenses from withdrawal
                var withResult = club.Withdraws.Where(a => a.Date.Month == month && a.Date.Year == year && a.BankID == null).Where(a => a.WithType1.Department == dep).GroupBy(a => a.WithType).ToList().Select(a => new EandIReport()
                {
                    Expenses = club.WithTypes.Where(o => o.ID == a.Key).Select(o => o.Name).First(),
                    ExpenseAmount = a.Sum(o => o.Amount).ToString("0.00"),
                    Month = month.ToString(),
                    Year = year.ToString(),
                }).ToList();
                if (withResult.Count == 0)
                {
                    withResult = new List<EandIReport>();
                    EandIReport re = new EandIReport();
                    re.Month = month.ToString();
                    re.Year = year.ToString();
                    re.ExpenseAmount = "لايوجد مصاريف";
                    withResult.Add(re);
                }
                // TODO:
                // get the paid amount of each service in the Invoice Services Table
                var income = club.Deposits.Where(a => a.Date.Month == month).Where(a => a.Date.Year == year)
                        .Where(a => a.InvoiceHeader.InvoiceServices.Any(p => p.Service.DepID == dep))
                        .Sum(a => (decimal?)a.Amount * (a.InvoiceHeader.InvoiceServices.Where(p => p.InvID == a.InvID).Where(p => p.Service.DepID == dep).Sum(p => (decimal?)p.Percentage)));
                decimal incomeResult = 0;
                if (income != null)
                {
                    incomeResult = Math.Round(Convert.ToDecimal(income));
                }
                //var incomeResult = club.Deposits.Where(a => a.Date.Year == year && a.Date.Month == month)
                //    .Where(a => a.InvoiceHeader.Dep == dep).Count() == 0 ? 0 : club.Deposits.Where(a => a.Date.Year == year && a.Date.Month == month)
                //    .Where(a => a.InvoiceHeader.Dep == dep).Sum(a => a.Amount);
                string depname = club.Departments.Where(a => a.DepID == dep).Select(a => a.Name).First();
                foreach (var i in withResult)
                {
                    i.Income = incomeResult.ToString();
                    i.Dep = depname;
                }
                return withResult;
               
            }
        }


        public IEnumerable<WithTypeReport> getWithTypes()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.WithTypes.OrderBy(a=>a.Department).ToList().Select(a => new WithTypeReport()
                {
                    ID = a.ID.ToString(),
                    Name = a.Name,
                    Department = a.Department1.Name,
                }).ToList();
                return result;
            }
        }

        public IEnumerable<SubsOfTheDay> getSubsOfTheDay()
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                DateTime date = DateTime.Now.Date;
                var result = club.Subscribtions.Where(a => a.Date == date).ToList().GroupBy(k=> k.ClientID).Select(a => new SubsOfTheDay() { 
                            ClientName = club.Clients.Where(p=>p.ClientID == a.Key).First().FullName(),
                            FileID = a.Key.ToString(),
                            Services = arrayToString(a.Select(p=>p.Service.Name)),
                            }).ToList();
                return result;
            }
        }

        public IEnumerable<TransReport> getTransReport(int month, int year)
        {
            CultureInfo cul = new CultureInfo("ar-SA");
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Withdraws.Where(a => a.Date.Month == month && a.Date.Year == year && a.BankID == null).OrderBy(a => a.Date).GroupBy(a => new { a.Date, a.WithType1 }).ToList().Select(a => new TransReport()
                {
                    Date = a.Key.Date,
                    Day = a.Key.Date.ToString("yyyy/MM/dd"),//cul.DateTimeFormat.DayNames[(int)a.Key.Date.DayOfWeek] + " - " + a.Key.Date.ToString("yyyy/MM/dd"),
                    Type = a.Key.WithType1.Name,//club.WithTypes.Where(o=>o.ID == a.Key.WithType1).Select(o=>o.Name).FirstOrDefault(),
                    Expense = club.Withdraws.Where(i => i.Date == a.Key.Date && i.BankID == null).Sum(i => i.Amount).ToString("0.00"),
                    Income = club.Deposits.Where(i => i.Date == a.Key.Date).Count() == 0 ? "0" : club.Deposits.Where(i => i.Date == a.Key.Date).Sum(i => i.Amount).ToString(),
                    Value = club.Withdraws.Where(i => i.Date == a.Key.Date && i.BankID == null && i.WithType == a.Key.WithType1.ID).Select(i => i.Amount).Sum(),
                }).ToList();
                    return result;

            }
        }





        public IEnumerable<BankStatement> getBankStatemnet(DateTime from, DateTime to)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var sum = club.BankTrans.Where(a=>a.Date < from).Sum(a=>(decimal?)a.Amount);
                if (sum == null)
                    sum = 0;
                var result = club.BankTrans.Where(a => a.Date >= from && a.Date <= to).ToList().Select(a => new BankStatement() { 
                                                Date = a.Date.ToString("yyyy/MM/dd"),
                                                Debit = a.Amount<0?a.Amount.ToString("0.00"):"0",
                                                Credit = a.Amount>=0?a.Amount.ToString("0.00"):"0",
                                                Note = a.Note,
                                                Balance = (sum = sum+a.Amount).ToString(),
                                                }).ToList();
                
                return result;
            }
        }


    }
    }

