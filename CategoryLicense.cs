//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTP_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryLicense
    {
        public int CategoryLicenseID { get; set; }
        public int CategoryID { get; set; }
        public int DrivingLicenseID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual DrivingLicense DrivingLicense { get; set; }
    }
}
