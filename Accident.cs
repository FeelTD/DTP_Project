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
    
    public partial class Accident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accident()
        {
            this.AccidentVictim = new HashSet<AccidentVictim>();
        }
    
        public int AccidentID { get; set; }
        public string Address { get; set; }
        public System.DateTime DateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccidentVictim> AccidentVictim { get; set; }
    }
}
