namespace Contacts_KT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            AddColumn("dbo.ContactModels", "IdUser", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactModels", "IdUser");
            AddForeignKey("dbo.ContactModels", "IdUser", "dbo.UserModels", "IdUser", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactModels", "IdUser", "dbo.UserModels");
            DropIndex("dbo.ContactModels", new[] { "IdUser" });
            DropColumn("dbo.ContactModels", "IdUser");
            DropTable("dbo.UserModels");
        }
    }
}
