namespace apiEmpresa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logs
    {
        [Key]
        public int IDLog { get; set; }

        [Required]
        [StringLength(200)]
        public string DescripcionLog { get; set; }

        public int IDEmpleadoSolicitante { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaSolicitud { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}
