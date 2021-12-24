namespace CinemaGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeasonId = c.Int(),
                        GenreId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsCurrent = c.Boolean(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.SeasonId)
                .Index(t => t.GenreId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.MovieSubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Trailer = c.String(nullable: false, maxLength: 500),
                        SubmissionDate = c.DateTime(nullable: false),
                        ReasonToChoose = c.String(nullable: false, maxLength: 2000),
                        Synopsis = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.MovieRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        MovieSubmissionId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        RatingDate = c.DateTime(nullable: false),
                        ReasonForVote = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieSubmissions", t => t.MovieSubmissionId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId)
                .Index(t => t.MovieSubmissionId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                        ProfilePicture = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsCurrent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Matches", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Matches", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.MovieSubmissions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MovieRatings", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MovieRatings", "MovieSubmissionId", "dbo.MovieSubmissions");
            DropForeignKey("dbo.MovieSubmissions", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "GenreId", "dbo.Genres");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.MovieRatings", new[] { "MovieSubmissionId" });
            DropIndex("dbo.MovieRatings", new[] { "PlayerId" });
            DropIndex("dbo.MovieSubmissions", new[] { "MatchId" });
            DropIndex("dbo.MovieSubmissions", new[] { "PlayerId" });
            DropIndex("dbo.Matches", new[] { "StatusId" });
            DropIndex("dbo.Matches", new[] { "GenreId" });
            DropIndex("dbo.Matches", new[] { "SeasonId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Status");
            DropTable("dbo.Seasons");
            DropTable("dbo.Players");
            DropTable("dbo.MovieRatings");
            DropTable("dbo.MovieSubmissions");
            DropTable("dbo.Matches");
            DropTable("dbo.Genres");
            DropTable("dbo.Errors");
        }
    }
}
