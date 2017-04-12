//namespace AspNetIdentity.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;

//    public partial class RelacionUsuariosPersonas : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Personas",
//                c => new
//                {
//                    PersonaId = c.Int(nullable: false, identity: true),
//                    Identificacion = c.Long(nullable: false),
//                    Nombres = c.String(nullable: false, maxLength: 35),
//                    Apellidos = c.String(),
//                    Sexo = c.String(),
//                    Telefono = c.Int(nullable: false),
//                    Direccion = c.String(),
//                })
//                .PrimaryKey(t => t.PersonaId);

//            CreateTable(
//                "dbo.Obligacions",
//                c => new
//                {
//                    ObligacionId = c.Int(nullable: false, identity: true),
//                    UpdateAt = c.DateTime(nullable: false),
//                    CreatedAt = c.DateTime(nullable: false),
//                    Persona_PersonaId = c.Int(),
//                })
//                .PrimaryKey(t => t.ObligacionId)
//                .ForeignKey("dbo.Personas", t => t.Persona_PersonaId)
//                .Index(t => t.Persona_PersonaId);

//            CreateTable(
//                "dbo.Cobroes",
//                c => new
//                {
//                    CobroId = c.Int(nullable: false, identity: true),
//                    Nombre = c.String(),
//                    UpdateAt = c.DateTime(nullable: false),
//                    CreatedAt = c.DateTime(nullable: false),
//                    TipoCobro_TipoCobroId = c.Int(),
//                    Usuario_Id = c.String(maxLength: 128),
//                    Obligacion_ObligacionId = c.Int(),
//                })
//                .PrimaryKey(t => t.CobroId)
//                .ForeignKey("dbo.TipoCobroes", t => t.TipoCobro_TipoCobroId)
//                .ForeignKey("dbo.CreateUserBindingModels", t => t.Usuario_Id)
//                .ForeignKey("dbo.Obligacions", t => t.Obligacion_ObligacionId)
//                .Index(t => t.TipoCobro_TipoCobroId)
//                .Index(t => t.Usuario_Id)
//                .Index(t => t.Obligacion_ObligacionId);

//            CreateTable(
//                "dbo.TipoCobroes",
//                c => new
//                {
//                    TipoCobroId = c.Int(nullable: false, identity: true),
//                    Nombre = c.String(),
//                    UpdateAt = c.DateTime(nullable: false),
//                    CreatedAt = c.DateTime(nullable: false),
//                })
//                .PrimaryKey(t => t.TipoCobroId);

//            CreateTable(
//                "dbo.CreateUserBindingModels",
//                c => new
//                {
//                    Id = c.String(nullable: false, maxLength: 128),
//                    Email = c.String(nullable: false),
//                    Username = c.String(nullable: false),
//                    FirstName = c.String(nullable: false),
//                    LastName = c.String(nullable: false),
//                    RoleName = c.String(),
//                    Password = c.String(nullable: false, maxLength: 100),
//                    ConfirmPassword = c.String(nullable: false),
//                })
//                .PrimaryKey(t => t.Id);

//            AddColumn("dbo.AspNetUsers", "Persona_PersonaId", c => c.Int());
//            CreateIndex("dbo.AspNetUsers", "Persona_PersonaId");
//            AddForeignKey("dbo.AspNetUsers", "Persona_PersonaId", "dbo.Personas", "PersonaId");
//        }

//        public override void Down()
//        {
//            DropForeignKey("dbo.AspNetUsers", "Persona_PersonaId", "dbo.Personas");
//            DropForeignKey("dbo.Obligacions", "Persona_PersonaId", "dbo.Personas");
//            DropForeignKey("dbo.Cobroes", "Obligacion_ObligacionId", "dbo.Obligacions");
//            DropForeignKey("dbo.Cobroes", "Usuario_Id", "dbo.CreateUserBindingModels");
//            DropForeignKey("dbo.Cobroes", "TipoCobro_TipoCobroId", "dbo.TipoCobroes");
//            DropIndex("dbo.Cobroes", new[] { "Obligacion_ObligacionId" });
//            DropIndex("dbo.Cobroes", new[] { "Usuario_Id" });
//            DropIndex("dbo.Cobroes", new[] { "TipoCobro_TipoCobroId" });
//            DropIndex("dbo.Obligacions", new[] { "Persona_PersonaId" });
//            DropIndex("dbo.AspNetUsers", new[] { "Persona_PersonaId" });
//            DropColumn("dbo.AspNetUsers", "Persona_PersonaId");
//            DropTable("dbo.CreateUserBindingModels");
//            DropTable("dbo.TipoCobroes");
//            DropTable("dbo.Cobroes");
//            DropTable("dbo.Obligacions");
//            DropTable("dbo.Personas");
//        }
//    }
//}
