namespace WatchAuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMovie : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Movies", name: "IX_User_Id", newName: "IX_UserId");
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            RenameIndex(table: "dbo.Movies", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Movies", name: "UserId", newName: "User_Id");
        }
    }
}
