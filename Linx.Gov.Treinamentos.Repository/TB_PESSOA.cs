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
    
    public partial class TB_PESSOA
    {
        public int ID_PESSOA { get; set; }
        public string NM_PESSOA { get; set; }
        public string EN_PESSOA { get; set; }
        public string EM_PESSOA { get; set; }
        public System.DateTime DTNASC_PESSOA { get; set; }
        public int ID_GENERO { get; set; }
    
        public virtual TB_GENERO TB_GENERO { get; set; }
    }
}
