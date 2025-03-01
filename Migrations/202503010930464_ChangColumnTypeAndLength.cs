namespace ProjektProgramia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangColumnTypeAndLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "PostalCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Addresses", "Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String());
        }
    }
}
