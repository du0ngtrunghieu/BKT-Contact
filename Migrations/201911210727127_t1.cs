namespace Contacts_KT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        IdContact = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdContact);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactModels");
        }
    }
}
