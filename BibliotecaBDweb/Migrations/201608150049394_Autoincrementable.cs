namespace BibliotecaBDweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Autoincrementable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Horas", newName: "Hora");
            RenameTable(name: "dbo.UsuarioAsignaturas", newName: "UsuarioAsignatura");
            RenameTable(name: "dbo.UsuarioCarreras", newName: "UsuarioCarrera");
            DropForeignKey("dbo.Horarios", "CodHora", "dbo.Horas");
            DropForeignKey("dbo.Horarios", "CodSala", "dbo.Salas");
            DropForeignKey("dbo.Salas", "Edificios_CodEdificios", "dbo.Edificios");
            DropPrimaryKey("dbo.Hora");
            DropPrimaryKey("dbo.Salas");
            DropPrimaryKey("dbo.Edificios");
            DropPrimaryKey("dbo.Noticias");
            AlterColumn("dbo.Hora", "CodHora", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Salas", "CodSala", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Edificios", "CodEdificios", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Noticias", "IdNoticias", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Hora", "CodHora");
            AddPrimaryKey("dbo.Salas", "CodSala");
            AddPrimaryKey("dbo.Edificios", "CodEdificios");
            AddPrimaryKey("dbo.Noticias", "IdNoticias");
            AddForeignKey("dbo.Horarios", "CodHora", "dbo.Hora", "CodHora");
            AddForeignKey("dbo.Horarios", "CodSala", "dbo.Salas", "CodSala");
            AddForeignKey("dbo.Salas", "Edificios_CodEdificios", "dbo.Edificios", "CodEdificios");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salas", "Edificios_CodEdificios", "dbo.Edificios");
            DropForeignKey("dbo.Horarios", "CodSala", "dbo.Salas");
            DropForeignKey("dbo.Horarios", "CodHora", "dbo.Hora");
            DropPrimaryKey("dbo.Noticias");
            DropPrimaryKey("dbo.Edificios");
            DropPrimaryKey("dbo.Salas");
            DropPrimaryKey("dbo.Hora");
            AlterColumn("dbo.Noticias", "IdNoticias", c => c.Byte(nullable: false));
            AlterColumn("dbo.Edificios", "CodEdificios", c => c.Byte(nullable: false));
            AlterColumn("dbo.Salas", "CodSala", c => c.Byte(nullable: false));
            AlterColumn("dbo.Hora", "CodHora", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Noticias", "IdNoticias");
            AddPrimaryKey("dbo.Edificios", "CodEdificios");
            AddPrimaryKey("dbo.Salas", "CodSala");
            AddPrimaryKey("dbo.Hora", "CodHora");
            AddForeignKey("dbo.Salas", "Edificios_CodEdificios", "dbo.Edificios", "CodEdificios");
            AddForeignKey("dbo.Horarios", "CodSala", "dbo.Salas", "CodSala");
            AddForeignKey("dbo.Horarios", "CodHora", "dbo.Horas", "CodHora");
            RenameTable(name: "dbo.UsuarioCarrera", newName: "UsuarioCarreras");
            RenameTable(name: "dbo.UsuarioAsignatura", newName: "UsuarioAsignaturas");
            RenameTable(name: "dbo.Hora", newName: "Horas");
        }
    }
}
