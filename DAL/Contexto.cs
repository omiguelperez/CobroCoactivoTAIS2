﻿//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL
//{
//    public class Contexto : DbContext
//    {
//        public Contexto()
//        {
//            // Database.SetInitializer<Contexto>(new DropCreateDatabaseAlways<Contexto>());
//        }

//        public DbSet<Cliente> Clientes { get; set; }
//        public DbSet<Proyecto> Proyectos { get; set; }
//        public DbSet<Facturas> Facturas { get; set; }
//        public DbSet<ItemFactura> ItemFacturas { get; set; }
//        public DbSet<ProgramacionPago> ProgramacionPagos { get; set; }
//        public DbSet<Persona> Personas { get; set; }
//        public DbSet<Obligacion> Obligaciones { get; set; }
//        public DbSet<Cobro> Cobros { get; set; }
//        public DbSet<TipoCobro> TiposCobros { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

//            // modelBuilder.Entity<Cliente>()
//            // .HasRequired(d => d.Cliente)
//            // .WithMany(w => w.Actividades)
//            // .HasForeignKey(d => d.TipoDocumentoId)
//            // .WillCascadeOnDelete(false);

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}