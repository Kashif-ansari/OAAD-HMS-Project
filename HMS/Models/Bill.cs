//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.Accounts = new HashSet<Account>();
        }
    
        public int B_ID { get; set; }
        public Nullable<int> P_ID { get; set; }
        public Nullable<int> checkup { get; set; }
        public Nullable<System.DateTime> date_Join { get; set; }
        public Nullable<System.DateTime> date_left { get; set; }
        public Nullable<int> total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual Patient Patient { get; set; }
    }
}