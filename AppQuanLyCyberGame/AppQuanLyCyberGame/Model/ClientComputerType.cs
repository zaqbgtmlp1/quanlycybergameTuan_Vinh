//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppQuanLyCyberGame.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientComputerType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientComputerType()
        {
            this.ClientComputers = new HashSet<ClientComputer>();
        }
    
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public Nullable<double> Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComputer> ClientComputers { get; set; }
    }
}