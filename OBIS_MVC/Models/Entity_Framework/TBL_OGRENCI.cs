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
    
    public partial class TBL_OGRENCI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_OGRENCI()
        {
            this.TBL_NOT = new HashSet<TBL_NOT>();
        }
    
        public int OGRENCIID { get; set; }
        public string OGRAD { get; set; }
        public string OGRSOYAD { get; set; }
        public string OGRFOTOGRAF { get; set; }
        public string OGRCINSIYET { get; set; }
        public Nullable<byte> OGRKULUP { get; set; }
    
        public virtual TBL_KULUP TBL_KULUP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_NOT> TBL_NOT { get; set; }
    }
}