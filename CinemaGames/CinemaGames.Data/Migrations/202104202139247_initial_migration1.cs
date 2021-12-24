namespace CinemaGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieSubmissions", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MovieRatings", "MovieSubmissionId", "dbo.MovieSubmissions");
            DropForeignKey("dbo.MovieSubmissions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MovieRatings", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Matches", new[] { "SeasonId" });
            AlterColumn("dbo.Matches", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "SeasonId");
            AddForeignKey("dbo.Matches", "GenreId", "dbo.Genres", "Id");
            AddForeignKey("dbo.MovieSubmissions", "MatchId", "dbo.Matches", "Id");
            AddForeignKey("dbo.Matches", "StatusId", "dbo.Status", "Id");
            AddForeignKey("dbo.MovieRatings", "MovieSubmissionId", "dbo.MovieSubmissions", "Id");
            AddForeignKey("dbo.MovieSubmissions", "PlayerId", "dbo.Players", "Id");
            AddForeignKey("dbo.MovieRatings", "PlayerId", "dbo.Players", "Id");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.MovieRatings", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MovieSubmissions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MovieRatings", "MovieSubmissionId", "dbo.MovieSubmissions");
            DropForeignKey("dbo.Matches", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MovieSubmissions", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "GenreId", "dbo.Genres");
            DropIndex("dbo.Matches", new[] { "SeasonId" });
            AlterColumn("dbo.Matches", "SeasonId", c => c.Int());
            CreateIndex("dbo.Matches", "SeasonId");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieRatings", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieSubmissions", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieRatings", "MovieSubmissionId", "dbo.MovieSubmissions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieSubmissions", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
