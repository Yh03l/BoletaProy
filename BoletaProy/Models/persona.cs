//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoletaProy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            this.boleta = new HashSet<boleta>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidop { get; set; }
        public string apellidom { get; set; }
        public string ci { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public int tipo_per { get; set; }
        public int id_area { get; set; }
        public string sexo { get; set; }
        public string estado { get; set; }
    
        public virtual area area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boleta> boleta { get; set; }
        public virtual tipo_persona tipo_persona { get; set; }
        public virtual usuario usuario { get; set; }
    }
}