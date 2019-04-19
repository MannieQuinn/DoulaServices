namespace DoulaServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDoulas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doula",
                c => new
                    {
                        DoulaId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DoulaName = c.String(),
                        DoulaLocation = c.String(),
                        VbacExp = c.Boolean(nullable: false),
                        AvailJan = c.Boolean(nullable: false),
                        AvailFeb = c.Boolean(nullable: false),
                        AvailMar = c.Boolean(nullable: false),
                        AvailApr = c.Boolean(nullable: false),
                        AvailMay = c.Boolean(nullable: false),
                        AvailJun = c.Boolean(nullable: false),
                        AvailJul = c.Boolean(nullable: false),
                        AvailAug = c.Boolean(nullable: false),
                        AvailSep = c.Boolean(nullable: false),
                        AvailOct = c.Boolean(nullable: false),
                        AvailNov = c.Boolean(nullable: false),
                        AvailDec = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DoulaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doula");
        }
    }
}
