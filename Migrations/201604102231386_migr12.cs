namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Description", c => c.String());
            AlterColumn("dbo.Artists", "Profile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "Profile", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Albums", "Description", c => c.String(maxLength: 1000));
        }
    }
}
