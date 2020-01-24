namespace JooksuvoistlusMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RunnersDatas", "Break", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RunnersDatas", "Break");
        }
    }
}
