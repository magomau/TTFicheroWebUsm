namespace BibliotecaBDweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        CodAsig = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CodAsig);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        CodAsignatura = c.Byte(nullable: false),
                        Modificado = c.Byte(nullable: false),
                        CodHora = c.Byte(),
                        Dia = c.Byte(),
                        CodSala = c.Byte(),
                        RutProfesor = c.Int(),
                        FechaModi = c.DateTime(),
                        Paralelo = c.String(),
                        Asignaturas_CodAsig = c.Byte(),
                        Usuarios_Rut = c.Int(),
                    })
                .PrimaryKey(t => new { t.CodAsignatura, t.Modificado })
                .ForeignKey("dbo.Asignaturas", t => t.Asignaturas_CodAsig)
                .ForeignKey("dbo.Horas", t => t.CodHora)
                .ForeignKey("dbo.Salas", t => t.CodSala)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Rut)
                .Index(t => t.CodHora)
                .Index(t => t.CodSala)
                .Index(t => t.Asignaturas_CodAsig)
                .Index(t => t.Usuarios_Rut);
            
            CreateTable(
                "dbo.Horas",
                c => new
                    {
                        CodHora = c.Byte(nullable: false),
                        HoraInicio = c.Int(),
                        HoraTermino = c.Int(),
                    })
                .PrimaryKey(t => t.CodHora);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        CodSala = c.Byte(nullable: false),
                        CodEdificio = c.Byte(),
                        MaxAlumnos = c.Int(),
                        Edificios_CodEdificios = c.Byte(),
                    })
                .PrimaryKey(t => t.CodSala)
                .ForeignKey("dbo.Edificios", t => t.Edificios_CodEdificios)
                .Index(t => t.Edificios_CodEdificios);
            
            CreateTable(
                "dbo.Edificios",
                c => new
                    {
                        CodEdificios = c.Byte(nullable: false),
                        CantidadSalas = c.Int(),
                        NumerosBaños = c.Int(),
                        Oficinas = c.Int(),
                    })
                .PrimaryKey(t => t.CodEdificios);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Rut = c.Int(nullable: false, identity: true),
                        Dv = c.String(),
                        TipoUser = c.Byte(),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Fono = c.String(),
                        Contraseña = c.String(),
                        IdCarrera = c.Byte(),
                        IdNoticias = c.Byte(),
                    })
                .PrimaryKey(t => t.Rut);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        IdNoticias = c.Byte(nullable: false),
                        ContenidoNoticia = c.String(),
                        CodAsignatura = c.Byte(),
                        IdCarrera = c.Byte(),
                        RutAutor = c.Int(),
                        Usuarios_Rut = c.Int(),
                    })
                .PrimaryKey(t => t.IdNoticias)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Rut)
                .Index(t => t.Usuarios_Rut);
            
            CreateTable(
                "dbo.UsuarioAsignaturas",
                c => new
                    {
                        RutUsuario = c.Int(nullable: false),
                        CodAsignatura = c.Byte(nullable: false),
                        Año = c.Int(),
                        Semestre = c.Byte(),
                        Estado = c.String(),
                        Nota1 = c.Int(),
                        Nota2 = c.Int(),
                        Nota3 = c.Int(),
                        Nota4 = c.Int(),
                        Nota5 = c.Int(),
                        Paralelo = c.String(),
                        Asignaturas_CodAsig = c.Byte(),
                        Usuarios_Rut = c.Int(),
                    })
                .PrimaryKey(t => new { t.RutUsuario, t.CodAsignatura })
                .ForeignKey("dbo.Asignaturas", t => t.Asignaturas_CodAsig)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Rut)
                .Index(t => t.Asignaturas_CodAsig)
                .Index(t => t.Usuarios_Rut);
            
            CreateTable(
                "dbo.UsuarioCarreras",
                c => new
                    {
                        Rut = c.Int(nullable: false),
                        IdCarrera = c.Byte(nullable: false),
                        TipoProfesor = c.Byte(),
                    })
                .PrimaryKey(t => new { t.Rut, t.IdCarrera })
                .ForeignKey("dbo.Carreras", t => t.IdCarrera, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Rut, cascadeDelete: true)
                .Index(t => t.Rut)
                .Index(t => t.IdCarrera);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        IdCarrera = c.Byte(nullable: false),
                        RutJefeCarrera = c.String(),
                        NombreCarrera = c.String(),
                        IdDepartamento = c.Byte(),
                    })
                .PrimaryKey(t => t.IdCarrera)
                .ForeignKey("dbo.Departamentos", t => t.IdDepartamento)
                .Index(t => t.IdDepartamento);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        IdDepartamento = c.Byte(nullable: false),
                        RutJefeDepto = c.String(),
                        NombreDepartamento = c.String(),
                    })
                .PrimaryKey(t => t.IdDepartamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioCarreras", "Rut", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioCarreras", "IdCarrera", "dbo.Carreras");
            DropForeignKey("dbo.Carreras", "IdDepartamento", "dbo.Departamentos");
            DropForeignKey("dbo.UsuarioAsignaturas", "Usuarios_Rut", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioAsignaturas", "Asignaturas_CodAsig", "dbo.Asignaturas");
            DropForeignKey("dbo.Noticias", "Usuarios_Rut", "dbo.Usuarios");
            DropForeignKey("dbo.Horarios", "Usuarios_Rut", "dbo.Usuarios");
            DropForeignKey("dbo.Horarios", "CodSala", "dbo.Salas");
            DropForeignKey("dbo.Salas", "Edificios_CodEdificios", "dbo.Edificios");
            DropForeignKey("dbo.Horarios", "CodHora", "dbo.Horas");
            DropForeignKey("dbo.Horarios", "Asignaturas_CodAsig", "dbo.Asignaturas");
            DropIndex("dbo.Carreras", new[] { "IdDepartamento" });
            DropIndex("dbo.UsuarioCarreras", new[] { "IdCarrera" });
            DropIndex("dbo.UsuarioCarreras", new[] { "Rut" });
            DropIndex("dbo.UsuarioAsignaturas", new[] { "Usuarios_Rut" });
            DropIndex("dbo.UsuarioAsignaturas", new[] { "Asignaturas_CodAsig" });
            DropIndex("dbo.Noticias", new[] { "Usuarios_Rut" });
            DropIndex("dbo.Salas", new[] { "Edificios_CodEdificios" });
            DropIndex("dbo.Horarios", new[] { "Usuarios_Rut" });
            DropIndex("dbo.Horarios", new[] { "Asignaturas_CodAsig" });
            DropIndex("dbo.Horarios", new[] { "CodSala" });
            DropIndex("dbo.Horarios", new[] { "CodHora" });
            DropTable("dbo.Departamentos");
            DropTable("dbo.Carreras");
            DropTable("dbo.UsuarioCarreras");
            DropTable("dbo.UsuarioAsignaturas");
            DropTable("dbo.Noticias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Edificios");
            DropTable("dbo.Salas");
            DropTable("dbo.Horas");
            DropTable("dbo.Horarios");
            DropTable("dbo.Asignaturas");
        }
    }
}
