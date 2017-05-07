namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersPersonaIDSprint3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cobroes",
                c => new
                    {
                        CobroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        TipoCobroId = c.Int(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CobroId)
                .ForeignKey("dbo.TipoCobroes", t => t.TipoCobroId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.TipoCobroId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Obligacions",
                c => new
                    {
                        ObligacionId = c.Int(nullable: false, identity: true),
                        Cuantia = c.Single(nullable: false),
                        Dueda = c.Single(nullable: false),
                        FechaPreinscripcion = c.DateTime(nullable: false),
                        Estado = c.String(),
                        ExpedienteId = c.Int(nullable: false),
                        TipoObligacionId = c.Int(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObligacionId)
                .ForeignKey("dbo.Expedientes", t => t.ExpedienteId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoObligacions", t => t.TipoObligacionId, cascadeDelete: true)
                .Index(t => t.ExpedienteId)
                .Index(t => t.TipoObligacionId)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.Expedientes",
                c => new
                    {
                        ExpedienteId = c.Int(nullable: false, identity: true),
                        EntidadEncargada = c.String(),
                        Nombre = c.String(),
                        Identificacion = c.String(),
                        DireccionEjecutado = c.String(),
                        Cuantia = c.Single(nullable: false),
                        NaturalezaObligacion = c.String(),
                        DireccionTituloEjecutivo = c.String(),
                        Descripcion = c.String(),
                        UbicacionExpediente = c.String(),
                        FechaRadicacion = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExpedienteId);
            
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        DocumentoId = c.Int(nullable: false, identity: true),
                        FechaRecepcion = c.DateTime(nullable: false),
                        FechaDocumento = c.DateTime(nullable: false),
                        OficinaOrigen = c.String(),
                        Remitente = c.String(),
                        FuncionarioEntrega = c.String(),
                        FechaEntrega = c.DateTime(nullable: false),
                        FuncionarioRecibe = c.String(),
                        FechaRadicacion = c.DateTime(nullable: false),
                        RutaDocumento = c.String(),
                        TipoArchivo = c.String(),
                        Estado = c.String(),
                        TipoDocumentoId = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpedienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.Expedientes", t => t.ExpedienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoDocumentoes", t => t.TipoDocumentoId, cascadeDelete: true)
                .Index(t => t.TipoDocumentoId)
                .Index(t => t.ExpedienteId);
            
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        TipoDocumentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(nullable: false, maxLength: 15),
                        Nombres = c.String(nullable: false, maxLength: 35),
                        Apellidos = c.String(nullable: false, maxLength: 35),
                        Sexo = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                        TipoPersonaId = c.Int(nullable: false),
                        Nacionalidad = c.String(),
                        PaisNacimiento = c.String(),
                        PaisCorrespondencia = c.String(),
                        Departamento = c.String(),
                        Municipio = c.String(),
                        Email = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.TipoPersonas", t => t.TipoPersonaId, cascadeDelete: true)
                .Index(t => t.Identificacion, unique: true)
                .Index(t => t.TipoPersonaId);
            
            CreateTable(
                "dbo.TipoPersonas",
                c => new
                    {
                        TipoPersonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPersonaId);
            
            CreateTable(
                "dbo.TipoObligacions",
                c => new
                    {
                        TipoObligacionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoObligacionId);
            
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
                        PersonaId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
            CreateTable(
                "dbo.ObligacionesCobros",
                c => new
                    {
                        ObligacionId = c.Int(nullable: false),
                        CobroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ObligacionId, t.CobroId })
                .ForeignKey("dbo.Obligacions", t => t.ObligacionId)
                .ForeignKey("dbo.Cobroes", t => t.CobroId)
                .Index(t => t.ObligacionId)
                .Index(t => t.CobroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cobroes", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cobroes", "TipoCobroId", "dbo.TipoCobroes");
            DropForeignKey("dbo.Obligacions", "TipoObligacionId", "dbo.TipoObligacions");
            DropForeignKey("dbo.Personas", "TipoPersonaId", "dbo.TipoPersonas");
            DropForeignKey("dbo.Obligacions", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Obligacions", "ExpedienteId", "dbo.Expedientes");
            DropForeignKey("dbo.Documentoes", "TipoDocumentoId", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.Documentoes", "ExpedienteId", "dbo.Expedientes");
            DropForeignKey("dbo.ObligacionesCobros", "CobroId", "dbo.Cobroes");
            DropForeignKey("dbo.ObligacionesCobros", "ObligacionId", "dbo.Obligacions");
            DropIndex("dbo.ObligacionesCobros", new[] { "CobroId" });
            DropIndex("dbo.ObligacionesCobros", new[] { "ObligacionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "PersonaId" });
            DropIndex("dbo.Personas", new[] { "TipoPersonaId" });
            DropIndex("dbo.Personas", new[] { "Identificacion" });
            DropIndex("dbo.Documentoes", new[] { "ExpedienteId" });
            DropIndex("dbo.Documentoes", new[] { "TipoDocumentoId" });
            DropIndex("dbo.Obligacions", new[] { "PersonaId" });
            DropIndex("dbo.Obligacions", new[] { "TipoObligacionId" });
            DropIndex("dbo.Obligacions", new[] { "ExpedienteId" });
            DropIndex("dbo.Cobroes", new[] { "UsuarioId" });
            DropIndex("dbo.Cobroes", new[] { "TipoCobroId" });
            DropTable("dbo.ObligacionesCobros");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipoCobroes");
            DropTable("dbo.TipoObligacions");
            DropTable("dbo.TipoPersonas");
            DropTable("dbo.Personas");
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.Documentoes");
            DropTable("dbo.Expedientes");
            DropTable("dbo.Obligacions");
            DropTable("dbo.Cobroes");
        }
    }
}
