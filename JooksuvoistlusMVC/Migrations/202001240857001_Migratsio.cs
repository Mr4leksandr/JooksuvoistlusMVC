namespace JooksuvoistlusMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratsio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RunnersDatas", "StartingTime", c => c.String());
            AlterColumn("dbo.RunnersDatas", "FinishTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RunnersDatas", "FinishTime", c => c.Int(nullable: false));
            AlterColumn("dbo.RunnersDatas", "StartingTime", c => c.Int(nullable: false));
        }
    }
}
