//namespace DAL.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class SecretariaRadicacionExpediente : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Cobroes",
//                c => new
//                    {
//                        CobroId = c.Int(nullable: false, identity: true),
//                        Nombre = c.String(),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                        TipoCobroId = c.Int(nullable: false),
//                        UsuarioId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => t.CobroId)
//                .ForeignKey("dbo.TipoCobroes", t => t.TipoCobroId, cascadeDelete: true)
//                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId, cascadeDelete: true)
//                .Index(t => t.TipoCobroId)
//                .Index(t => t.UsuarioId);
            
//            CreateTable(
//                "dbo.Obligacions",
//                c => new
//                    {
//                        ObligacionId = c.Int(nullable: false, identity: true),
//                        Cuantia = c.Single(nullable: false),
//                        Dueda = c.Single(nullable: false),
//                        FechaPreinscripcion = c.DateTime(nullable: false),
//                        Estado = c.String(),
//                        ExpedienteId = c.Int(nullable: false),
//                        PersonaId = c.Int(nullable: false),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.ObligacionId)
//                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
//                .Index(t => t.PersonaId);
            
//            CreateTable(
//                "dbo.Expedientes",
//                c => new
//                    {
//                        ExpedienteId = c.Int(nullable: false),
//                        EntidadEncargada = c.String(),
//                        Nombre = c.String(),
//                        Identificacion = c.String(),
//                        DireccionEjecutado = c.String(),
//                        Cuantia = c.Single(nullable: false),
//                        NaturalezaObligacion = c.String(),
//                        DireccionTituloEjecutivo = c.String(),
//                        Descripcion = c.String(),
//                        UbicacionExpediente = c.String(),
//                        FechaRadicacion = c.DateTime(nullable: false),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                        ObligacionId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.ExpedienteId)
//                .ForeignKey("dbo.Obligacions", t => t.ExpedienteId)
//                .Index(t => t.ExpedienteId);
            
//            CreateTable(
//                "dbo.Documentoes",
//                c => new
//                    {
//                        DocumentoId = c.Int(nullable: false, identity: true),
//                        FechaRecepcion = c.DateTime(nullable: false),
//                        FechaDocumento = c.DateTime(nullable: false),
//                        OficinaOrigen = c.String(),
//                        Remitente = c.String(),
//                        FuncionarioEntrega = c.String(),
//                        FechaEntrega = c.DateTime(nullable: false),
//                        FuncionarioRecibe = c.String(),
//                        FechaRadicacion = c.DateTime(nullable: false),
//                        RutaDocumento = c.String(),
//                        TipoArchivo = c.String(),
//                        TipoDocumentoId = c.Int(nullable: false),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                        ExpedienteId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.DocumentoId)
//                .ForeignKey("dbo.Expedientes", t => t.ExpedienteId, cascadeDelete: true)
//                .ForeignKey("dbo.TipoDocumentoes", t => t.TipoDocumentoId, cascadeDelete: true)
//                .Index(t => t.TipoDocumentoId)
//                .Index(t => t.ExpedienteId);
            
//            CreateTable(
//                "dbo.TipoDocumentoes",
//                c => new
//                    {
//                        TipoDocumentoId = c.Int(nullable: false, identity: true),
//                        Nombre = c.String(),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.TipoDocumentoId);
            
//            CreateTable(
//                "dbo.Personas",
//                c => new
//                    {
//                        PersonaId = c.Int(nullable: false, identity: true),
//                        Identificacion = c.String(nullable: false, maxLength: 15),
//                        Nombres = c.String(nullable: false, maxLength: 35),
//                        Apellidos = c.String(nullable: false, maxLength: 35),
//                        Sexo = c.String(nullable: false),
//                        Telefono = c.Int(nullable: false),
//                        Direccion = c.String(nullable: false),
//                    })
//                .PrimaryKey(t => t.PersonaId)
//                .Index(t => t.Identificacion, unique: true);
            
//            CreateTable(
//                "dbo.TipoCobroes",
//                c => new
//                    {
//                        TipoCobroId = c.Int(nullable: false, identity: true),
//                        Nombre = c.String(),
//                        UpdateAt = c.DateTime(nullable: false),
//                        CreatedAt = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.TipoCobroId);
            
//            CreateTable(
//                "dbo.AspNetUsers",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        FirstName = c.String(nullable: false, maxLength: 100),
//                        LastName = c.String(nullable: false, maxLength: 100),
//                        Level = c.Byte(nullable: false),
//                        JoinDate = c.DateTime(nullable: false),
//                        Email = c.String(maxLength: 256),
//                        EmailConfirmed = c.Boolean(nullable: false),
//                        PasswordHash = c.String(),
//                        SecurityStamp = c.String(),
//                        PhoneNumber = c.String(),
//                        PhoneNumberConfirmed = c.Boolean(nullable: false),
//                        TwoFactorEnabled = c.Boolean(nullable: false),
//                        LockoutEndDateUtc = c.DateTime(),
//                        LockoutEnabled = c.Boolean(nullable: false),
//                        AccessFailedCount = c.Int(nullable: false),
//                        UserName = c.String(nullable: false, maxLength: 256),
//                        Persona_PersonaId = c.Int(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Personas", t => t.Persona_PersonaId)
//                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
//                .Index(t => t.Persona_PersonaId);
            
//            CreateTable(
//                "dbo.AspNetUserClaims",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        ClaimType = c.String(),
//                        ClaimValue = c.String(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.AspNetUserLogins",
//                c => new
//                    {
//                        LoginProvider = c.String(nullable: false, maxLength: 128),
//                        ProviderKey = c.String(nullable: false, maxLength: 128),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.AspNetUserRoles",
//                c => new
//                    {
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        RoleId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.UserId, t.RoleId })
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
//                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
//                .Index(t => t.UserId)
//                .Index(t => t.RoleId);
            
//            CreateTable(
//                "dbo.AspNetRoles",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        Name = c.String(nullable: false, maxLength: 256),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
//            CreateTable(
//                "dbo.ObligacionCobroes",
//                c => new
//                    {
//                        Obligacion_ObligacionId = c.Int(nullable: false),
//                        Cobro_CobroId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => new { t.Obligacion_ObligacionId, t.Cobro_CobroId })
//                .ForeignKey("dbo.Obligacions", t => t.Obligacion_ObligacionId, cascadeDelete: true)
//                .ForeignKey("dbo.Cobroes", t => t.Cobro_CobroId, cascadeDelete: true)
//                .Index(t => t.Obligacion_ObligacionId)
//                .Index(t => t.Cobro_CobroId);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
//            DropForeignKey("dbo.Cobroes", "UsuarioId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUsers", "Persona_PersonaId", "dbo.Personas");
//            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.Cobroes", "TipoCobroId", "dbo.TipoCobroes");
//            DropForeignKey("dbo.Obligacions", "PersonaId", "dbo.Personas");
//            DropForeignKey("dbo.Expedientes", "ExpedienteId", "dbo.Obligacions");
//            DropForeignKey("dbo.Documentoes", "TipoDocumentoId", "dbo.TipoDocumentoes");
//            DropForeignKey("dbo.Documentoes", "ExpedienteId", "dbo.Expedientes");
//            DropForeignKey("dbo.ObligacionCobroes", "Cobro_CobroId", "dbo.Cobroes");
//            DropForeignKey("dbo.ObligacionCobroes", "Obligacion_ObligacionId", "dbo.Obligacions");
//            DropIndex("dbo.ObligacionCobroes", new[] { "Cobro_CobroId" });
//            DropIndex("dbo.ObligacionCobroes", new[] { "Obligacion_ObligacionId" });
//            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
//            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
//            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
//            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
//            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
//            DropIndex("dbo.AspNetUsers", new[] { "Persona_PersonaId" });
//            DropIndex("dbo.AspNetUsers", "UserNameIndex");
//            DropIndex("dbo.Personas", new[] { "Identificacion" });
//            DropIndex("dbo.Documentoes", new[] { "ExpedienteId" });
//            DropIndex("dbo.Documentoes", new[] { "TipoDocumentoId" });
//            DropIndex("dbo.Expedientes", new[] { "ExpedienteId" });
//            DropIndex("dbo.Obligacions", new[] { "PersonaId" });
//            DropIndex("dbo.Cobroes", new[] { "UsuarioId" });
//            DropIndex("dbo.Cobroes", new[] { "TipoCobroId" });
//            DropTable("dbo.ObligacionCobroes");
//            DropTable("dbo.AspNetRoles");
//            DropTable("dbo.AspNetUserRoles");
//            DropTable("dbo.AspNetUserLogins");
//            DropTable("dbo.AspNetUserClaims");
//            DropTable("dbo.AspNetUsers");
//            DropTable("dbo.TipoCobroes");
//            DropTable("dbo.Personas");
//            DropTable("dbo.TipoDocumentoes");
//            DropTable("dbo.Documentoes");
//            DropTable("dbo.Expedientes");
//            DropTable("dbo.Obligacions");
//            DropTable("dbo.Cobroes");
//        }
//    }
//}
