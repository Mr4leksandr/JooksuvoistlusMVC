namespace JooksuvoistlusMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RunnersDatas", "StartingTime", c => c.Int());
            AlterColumn("dbo.RunnersDatas", "FinishTime", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RunnersDatas", "FinishTime", c => c.Double());
            AlterColumn("dbo.RunnersDatas", "StartingTime", c => c.Double());
        }
    }
}
