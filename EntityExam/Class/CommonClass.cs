using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityExam.Entityframework;

namespace EntityExam.Class
{
    public class CommonClass
    {
    }
    public class CastList
    {
        public int CastId { get; set; }
        public string CastName { get; set; }
    }

    public class CheckCastList
    {
        public List<CastList> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }


    public class ContactList
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }

    public class CheckContactList
    {
        public List<ContactList> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class CheckEmployeeList
    {
        public int EmployeeId { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}