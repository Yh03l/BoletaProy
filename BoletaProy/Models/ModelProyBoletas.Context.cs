﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbProyBoletaEntities : DbContext
    {
        public dbProyBoletaEntities()
            : base("name=dbProyBoletaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<area> area { get; set; }
        public virtual DbSet<boleta> boleta { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<servicio> servicio { get; set; }
        public virtual DbSet<solucion> solucion { get; set; }
        public virtual DbSet<tipo_persona> tipo_persona { get; set; }
        public virtual DbSet<tipo_servicio> tipo_servicio { get; set; }
        public virtual DbSet<tipo_usuario> tipo_usuario { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
