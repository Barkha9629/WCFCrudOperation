//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityExam.Entityframework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactDetail
    {
        public int ContactId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string ResidentalAddress { get; set; }
        public string Pincode { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }
        public string EmailId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
