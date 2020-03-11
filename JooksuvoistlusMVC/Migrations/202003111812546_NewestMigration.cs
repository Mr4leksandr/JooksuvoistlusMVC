namespace JooksuvoistlusMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewestMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RunnersDatas", "FirstBreak", c => c.DateTime());
            AddColumn("dbo.RunnersDatas", "SecondBreak", c => c.DateTime());
            DropColumn("dbo.RunnersDatas", "Break");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RunnersDatas", "Break", c => c.Boolean(nullable: false));
            DropColumn("dbo.RunnersDatas", "SecondBreak");
            DropColumn("dbo.RunnersDatas", "FirstBreak");
        }
    }
}
