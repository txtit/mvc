//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LuyenDe08.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanLoaiPhu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanLoaiPhu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public string MaPhanLoaiPhu { get; set; }
        public string TenPhanLoaiPhu { get; set; }
        public string MaPhanLoai { get; set; }
    
        public virtual PhanLoai PhanLoai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
