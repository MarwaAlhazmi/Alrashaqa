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
                var result = club.InvoiceHeaders.Where(a => a.FinalAmount > club.Deposits.Where(o => o.InvID == a.InvID).Sum(l => l.Amount)).ToList().Select(i => new IncompleteInv()
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
                    Date = o.Date.ToShortDateString(),
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
                    Date = o.Date.ToShortDateString(),
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
        public IEnumerable<InvoiceReport> getInvoiceHeader(int invID)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                //var result = club.InvoiceHeaders.Where(a => a.InvID == invID);
                // get the services
                var result = club.InvoiceHeaders.Where(a => a.InvID == invID).First().Services.ToList().Select(
                                                                                        a => new InvoiceReport
                                                                                        {
                                                                                            ServiceName = a.Name,
                                                                                            ServicePrice = a.Price.ToString("0.00")
                                                                                        }).ToList(); ;

                var invoice = club.InvoiceHeaders.Where(a => a.InvID == invID).First();
                var paid = club.Deposits.Where(a => a.InvID == invID).Count() == 0 ? 0 : club.Deposits.Where(a => a.InvID == invID).Sum(a => a.Amount);
                var remain = invoice.FinalAmount - paid;
                foreach (var row in result)
                {
                    row.ClientName = invoice.Client.FullName();
                    row.Date = invoice.Date.ToShortDateString();
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
                                                    Diagnosis = item.Diagnosis
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
                    Bank = o.Bank,
                    CheckNum = o.CheckNum.ToString(),
                    Date = o.Date.ToShortDateString(),
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
                CheckNum = o.CheckNum.ToString(),
                Date = o.Date.ToShortDateString(),
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
                CultureInfo cul = new CultureInfo("ar-SA");
                var result = club.Deposits.Where(a => a.Date.Month == month && a.Date.Year == year).GroupBy(a => a.Date).ToList().Select(i => new IncomeReport()
                {
                    Date = i.Key.ToString("yyyy/MM/dd"),
                    Income = i.Sum(a => a.Amount).ToString(),// it was paid amount
                    Day = cul.DateTimeFormat.DayNames[(int)i.Key.DayOfWeek]
                }).ToList();
                int index = 1;
                foreach (var row in result)
                {
                    //tempdate = new DateTime(Convert.ToInt32(row.Date),Convert.ToInt32(),1);
                    //row.Day = cul.DateTimeFormat.DayNames[(int)Convert.ToDateTime(row.Date).DayOfWeek];
                    row.Ser = index.ToString();
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
                var result = club.Withdraws.Where(a => a.Date.Month == month && a.Date.Year == year).ToList().Select(i => new ExpenseReport()
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
                    Services = arrayToString(i.InvoiceHeader.Services.Select(o => o.Name)),
                    Notes = i.Notes,
                    Paid = i.Amount.ToString("0.00"),
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


        public IEnumerable<MovReport> getMovReport(DateTime date, int dep)
        {
            using (ClubDBEntities club = new ClubDBEntities())
            {
                var result = club.Deposits.Where(i => i.Date == date).Where(i => i.InvoiceHeader.Dep == dep).ToList().Select(i => new MovReport()
                {
                    ClientName = i.InvoiceHeader.Client.FullName(),
                    Phone = i.InvoiceHeader.Client.Phone.ToString(),
                    InvNum = i.InvID.ToString(),
                    VoucherNum = i.ID.ToString(),
                    Amount = i.InvoiceHeader.FinalAmount.ToString("0.00"),
                    Services = arrayToString(i.InvoiceHeader.Services.Select(o => o.Name)),
                    Notes = i.Notes,
                    Paid = i.Amount.ToString("0.00"),
                }).ToList();
                int index = 1;
                foreach (var row in result)
                {
                    row.Ser = index.ToString();
                    index++;
                    int invNum = Convert.ToInt32(row.InvNum);
                    var r = (from o in club.Deposits
                             where o.Date != date && o.InvID == invNum && o.InvoiceHeader.Dep == dep
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
                List<EvaluationReport> ll = new List<EvaluationReport>();
                ll.Add(report);
                return ll.AsEnumerable();
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
                            Date = re.ID.ToString(),
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
                var result = club.Services.ToList().Select(a => new ServiceReport() { 
                ID = a.ServiceID.ToString(),
                Name = a.Name,
                Price = a.Price.ToString(),
                Dep = a.Department.Name,
                SubDays = a.TotalDays.ToString(),
                SubType = a.Sub? "اشتراك شهري":"جلسة واحدة",
                }).ToList();
                return result.AsEnumerable();
            }
        }


    }
    }

