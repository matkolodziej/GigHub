namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Atendee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Atendee_Id" });
            DropColumn("dbo.Attendances", "AttendeeId");
            RenameColumn(table: "dbo.Attendances", name: "Atendee_Id", newName: "AttendeeId");
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "GigId", "AttendeeId" });
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "GigId", "AttendeeId" });
            RenameColumn(table: "dbo.Attendances", name: "AttendeeId", newName: "Atendee_Id");
            AddColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Attendances", "Atendee_Id");
            AddForeignKey("dbo.Attendances", "Atendee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
