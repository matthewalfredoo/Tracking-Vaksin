//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tracking_Vaksin_Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class RumahSakit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RumahSakit()
        {
            this.DataPasien = new HashSet<DataPasien>();
            this.DataVaksin = new HashSet<DataVaksin>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataPasien> DataPasien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataVaksin> DataVaksin { get; set; }
    }
}