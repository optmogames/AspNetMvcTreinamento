//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Linx.Gov.Treinamentos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_GENERO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_GENERO()
        {
            this.TB_PESSOA = new HashSet<TB_PESSOA>();
        }
    
        public int ID_GENERO { get; set; }
        public string DS_GENERO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PESSOA> TB_PESSOA { get; set; }
    }
}
