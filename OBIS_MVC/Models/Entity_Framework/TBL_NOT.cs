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
    
    public partial class TBL_NOT
    {
        public int NOTID { get; set; }
        public Nullable<byte> DERSID { get; set; }
        public Nullable<int> OGRID { get; set; }
        public Nullable<byte> SINAV1 { get; set; }
        public Nullable<byte> SINAV2 { get; set; }
        public Nullable<byte> SINAV3 { get; set; }
        public Nullable<byte> PROJE { get; set; }
        public Nullable<decimal> ORTALAMA { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBL_DERS TBL_DERS { get; set; }
        public virtual TBL_OGRENCI TBL_OGRENCI { get; set; }
    }
}
