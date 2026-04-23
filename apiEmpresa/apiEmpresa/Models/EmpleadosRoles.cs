namespace apiEmpresa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmpleadosRoles
    {
        [Key]
        public int IDEmpleadoRol { get; set; }

        public int IDRol { get; set; }

        public int IDEmpleado { get; set; }

        public virtual Empleados Empleados { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
