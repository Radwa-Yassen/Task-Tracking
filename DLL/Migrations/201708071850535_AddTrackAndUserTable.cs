namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackAndUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 199),
                        Details = c.String(maxLength: 499),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 199),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropIndex("dbo.Task", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Task");
        }
    }
}
