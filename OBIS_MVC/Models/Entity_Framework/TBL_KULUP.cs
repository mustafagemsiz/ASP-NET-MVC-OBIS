//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBIS_MVC.Models.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_KULUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_KULUP()
        {
            this.TBL_OGRENCI = new HashSet<TBL_OGRENCI>();
        }
    
        public byte KULUPID { get; set; }
        public string KLPAD { get; set; }
        public Nullable<short> KLPKONTENJAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_OGRENCI> TBL_OGRENCI { get; set; }
    }
}