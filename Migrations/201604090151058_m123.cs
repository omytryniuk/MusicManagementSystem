namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Description", c => c.String(maxLength: 1000));
            AddColumn("dbo.Artists", "Profile", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Profile");
            DropColumn("dbo.Albums", "Description");
        }
    }
}
