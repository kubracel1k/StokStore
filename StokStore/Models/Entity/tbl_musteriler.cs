//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokStore.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_musteriler()
        {
            this.tbl_satıs = new HashSet<tbl_satıs>();
        }
    
        public int MUSTERIID { get; set; }
        [Required(ErrorMessage ="Bu alanı boş bırakamazsınız..!")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter")]
        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satıs> tbl_satıs { get; set; }
    }
}
