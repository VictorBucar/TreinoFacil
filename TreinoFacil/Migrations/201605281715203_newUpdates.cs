namespace TreinoFacil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "nome");
        }
    }
}
