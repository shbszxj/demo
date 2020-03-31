namespace EF6.Integration.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class StudentAgeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Age", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Students", "Age");
        }
    }
}
