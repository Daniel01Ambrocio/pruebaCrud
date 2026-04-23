namespace apiEmpresa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Roles()
        {
            EmpleadosRoles = new HashSet<EmpleadosRoles>();
        }

        [Key]
        public int IDRol { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreRol { get; set; }

        public int PermisoGet { get; set; }

        public int PermisoPOST { get; set; }

        public int PermisoPUT { get; set; }

        public int PermisoDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadosRoles> EmpleadosRoles { get; set; }
    }
}
