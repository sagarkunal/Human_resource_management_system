namespace User_Registration_Form.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblcities", "stateid", c => c.Int(nullable: false));
            DropColumn("dbo.tblcities", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblcities", "sid", c => c.Int(nullable: false));
            DropColumn("dbo.tblcities", "stateid");
        }
    }
}
