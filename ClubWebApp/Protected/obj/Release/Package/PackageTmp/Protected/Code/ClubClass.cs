using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWebApp
{
    public enum Status
    {
        Active,
        Inactive,
        Suspended
    }
    public enum EType
    {
        Trainer,
        Receptionist,
        Manager
    }
    public enum InvoiceStatus
    {
        Complete,
        Incomplete
    }
    public enum ERoles
    {
        Receptionist,
        Manager,
        PhysicalS,
        Nutritionist,
        InternalS
    }
    public enum InvoiceType
    {
        Credit,
        Check,
        Cash
    }
    //public enum 
    public static class ClubClass
    {

        public static string toString(this Status st)
        {
            switch (st)
            {
                case Status.Active:
                    return "مفعل";
                case Status.Inactive:
                    return "غير مفعل";
                case Status.Suspended:
                    return "متوقف";
                default:
                    return "متوقف";
            }
        }
    }
}