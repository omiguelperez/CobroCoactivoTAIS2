namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CobroUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 35),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturasId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        NumeroFactura = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacturasId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.ItemFacturas",
                c => new
                    {
                        ItemFacturaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FacturaId = c.Int(nullable: false),
                        Factura_FacturasId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemFacturaId)
                .ForeignKey("dbo.Facturas", t => t.Factura_FacturasId)
                .Index(t => t.Factura_FacturasId);
            
            CreateTable(
                "dbo.Proyectoes",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaInicio = c.DateTime(nullable: false),
                        Plazo = c.Int(nullable: false),
                        Estado = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.ProgramacionPagoes",
                c => new
                    {
                        ProgramacionPagoId = c.Int(nullable: false, identity: true),
                        FechaPago = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                        ProyectoId = c.Int(nullable: false),
                        FacturaId = c.Int(nullable: false),
                        Factura_FacturasId = c.Int(),
                    })
                .PrimaryKey(t => t.ProgramacionPagoId)
                .ForeignKey("dbo.Facturas", t => t.Factura_FacturasId)
                .ForeignKey("dbo.Proyectoes", t => t.ProyectoId, cascadeDelete: true)
                .Index(t => t.ProyectoId)
                .Index(t => t.Factura_FacturasId);
            
            CreateTable(
                "dbo.Cobroes",
                c => new
                    {
                        CobroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),//toco modificarlo porque ni de vaina lo agarraba
                        TipoCobro_TipoCobroId = c.Int(),
                        Obligacion_ObligacionId = c.Int(),
                    })
                .PrimaryKey(t => t.CobroId)
                .ForeignKey("dbo.TipoCobroes", t => t.TipoCobro_TipoCobroId)
                .ForeignKey("dbo.Obligacions", t => t.Obligacion_ObligacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)//toco modificarlo porque ni de vaina lo agarraba
                .Index(t => t.UserId)
                .Index(t => t.TipoCobro_TipoCobroId)
                .Index(t => t.Obligacion_ObligacionId);
            
            CreateTable(
                "dbo.TipoCobroes",
                c => new
                    {
                        TipoCobroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoCobroId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Persona_PersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_PersonaId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Persona_PersonaId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Identificacion = c.Long(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 35),
                        Apellidos = c.String(),
                        Sexo = c.String(),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Obligacions",
                c => new
                    {
                        ObligacionId = c.Int(nullable: false, identity: true),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Persona_PersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.ObligacionId)
                .ForeignKey("dbo.Personas", t => t.Persona_PersonaId)
                .Index(t => t.Persona_PersonaId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cobroes", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Persona_PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Obligacions", "Persona_PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Cobroes", "Obligacion_ObligacionId", "dbo.Obligacions");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cobroes", "TipoCobro_TipoCobroId", "dbo.TipoCobroes");
            DropForeignKey("dbo.ProgramacionPagoes", "ProyectoId", "dbo.Proyectoes");
            DropForeignKey("dbo.ProgramacionPagoes", "Factura_FacturasId", "dbo.Facturas");
            DropForeignKey("dbo.Proyectoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemFacturas", "Factura_FacturasId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Obligacions", new[] { "Persona_PersonaId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Persona_PersonaId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cobroes", new[] { "Obligacion_ObligacionId" });
            DropIndex("dbo.Cobroes", new[] { "TipoCobro_TipoCobroId" });
            DropIndex("dbo.Cobroes", new[] { "UsuarioId" });
            DropIndex("dbo.ProgramacionPagoes", new[] { "Factura_FacturasId" });
            DropIndex("dbo.ProgramacionPagoes", new[] { "ProyectoId" });
            DropIndex("dbo.Proyectoes", new[] { "ClienteId" });
            DropIndex("dbo.ItemFacturas", new[] { "Factura_FacturasId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Obligacions");
            DropTable("dbo.Personas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipoCobroes");
            DropTable("dbo.Cobroes");
            DropTable("dbo.ProgramacionPagoes");
            DropTable("dbo.Proyectoes");
            DropTable("dbo.ItemFacturas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}
