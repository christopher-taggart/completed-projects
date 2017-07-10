namespace DvdLibraryMilestone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RatingId = c.String(maxLength: 128),
                        Director = c.String(),
                        ReleaseYear = c.String(maxLength: 4),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
        }
    }
}
