namespace DvdLibraryMilestone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropPrimaryKey("dbo.Ratings");
            AlterColumn("dbo.Dvds", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Dvds", "RatingId", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Dvds", "Director", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ratings", "RatingId", c => c.String(nullable: false, maxLength: 5));
            AddPrimaryKey("dbo.Ratings", "RatingId");
            CreateIndex("dbo.Dvds", "RatingId");
            AddForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings", "RatingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropPrimaryKey("dbo.Ratings");
            AlterColumn("dbo.Ratings", "RatingId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Dvds", "Director", c => c.String());
            AlterColumn("dbo.Dvds", "RatingId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Dvds", "Title", c => c.String());
            AddPrimaryKey("dbo.Ratings", "RatingId");
            CreateIndex("dbo.Dvds", "RatingId");
            AddForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings", "RatingId");
        }
    }
}
