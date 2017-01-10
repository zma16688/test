namespace pt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryToAddNewColumnToExistingDBWithoutLossingData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Crew", "numOfCrew", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Crew", "numOfCrew");
        }
    }
}
