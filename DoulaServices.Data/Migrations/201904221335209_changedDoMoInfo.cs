namespace DoulaServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDoMoInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DoMo", "DoulaId", "dbo.Doula");
            DropForeignKey("dbo.DoMo", "MotherId", "dbo.Mother");
            DropIndex("dbo.DoMo", new[] { "DoulaId" });
            DropIndex("dbo.DoMo", new[] { "MotherId" });
            RenameColumn(table: "dbo.DoMo", name: "DoulaId", newName: "Doula_DoulaId");
            RenameColumn(table: "dbo.DoMo", name: "MotherId", newName: "Mother_MotherId");
            AddColumn("dbo.DoMo", "DoulaName", c => c.String());
            AddColumn("dbo.DoMo", "FirstName", c => c.String());
            AlterColumn("dbo.DoMo", "Doula_DoulaId", c => c.Int());
            AlterColumn("dbo.DoMo", "Mother_MotherId", c => c.Int());
            CreateIndex("dbo.DoMo", "Doula_DoulaId");
            CreateIndex("dbo.DoMo", "Mother_MotherId");
            AddForeignKey("dbo.DoMo", "Doula_DoulaId", "dbo.Doula", "DoulaId");
            AddForeignKey("dbo.DoMo", "Mother_MotherId", "dbo.Mother", "MotherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoMo", "Mother_MotherId", "dbo.Mother");
            DropForeignKey("dbo.DoMo", "Doula_DoulaId", "dbo.Doula");
            DropIndex("dbo.DoMo", new[] { "Mother_MotherId" });
            DropIndex("dbo.DoMo", new[] { "Doula_DoulaId" });
            AlterColumn("dbo.DoMo", "Mother_MotherId", c => c.Int(nullable: false));
            AlterColumn("dbo.DoMo", "Doula_DoulaId", c => c.Int(nullable: false));
            DropColumn("dbo.DoMo", "FirstName");
            DropColumn("dbo.DoMo", "DoulaName");
            RenameColumn(table: "dbo.DoMo", name: "Mother_MotherId", newName: "MotherId");
            RenameColumn(table: "dbo.DoMo", name: "Doula_DoulaId", newName: "DoulaId");
            CreateIndex("dbo.DoMo", "MotherId");
            CreateIndex("dbo.DoMo", "DoulaId");
            AddForeignKey("dbo.DoMo", "MotherId", "dbo.Mother", "MotherId", cascadeDelete: true);
            AddForeignKey("dbo.DoMo", "DoulaId", "dbo.Doula", "DoulaId", cascadeDelete: true);
        }
    }
}
