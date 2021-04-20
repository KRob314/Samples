namespace CinemaGames.Data.Migrations
{
    using CinemaGames.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaGames.Data.CinemaGamesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaGames.Data.CinemaGamesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Genre.AddOrUpdate(g => g.Name, GenerateGenres());
            context.Role.AddOrUpdate(r => r.Name, GenerateRoles(context));
            GenerateUsers(context);
            context.Season.AddOrUpdate(s => s.Name, GenerateSeasons(context));
        }

        private void GenerateUsers(CinemaGamesContext context)
        {
            for(int i = 0; i < 8; i++)
            {
                context.User.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email= $"citizen{i}@thecinemagames.com",
                    Username="citizen" + i,
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });
            }

            // // create user-admin for chsakell
            context.UserRole.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // chsakell
                }
            });
        }

        private Role[] GenerateRoles(CinemaGamesContext context)
        {
            Role[] _roles = new Role[]{
                new Role(){Name="Admin"},
                new Role(){Name = "Warden" },
                new Role(){Name = "Citizen" }
            };

            return _roles;
        }


        private Genre[] GenerateGenres()
        {
            Genre[] genres = new Genre[] {
                new Genre() { Name = "Comedy" },
                new Genre() { Name = "Sci-fi" },
                new Genre() { Name = "Action" },
                new Genre() { Name = "Horror" },
                new Genre() { Name = "Romance" },
                new Genre() { Name = "Comedy" },
                new Genre() { Name = "Crime" },
            };

            return genres;
        }

        public Season[] GenerateSeasons(CinemaGamesContext context)
        {
            Season[] seasons = new Season[5];

            for(int i = 0; i < 5; i++)
            {
                seasons[i] = new Season()
                {
                    Name = $"Season {i + 1}",
                    StartDate = DateTime.Now.AddDays(30 + i),
                    EndDate = DateTime.Now.AddDays(30 + i + i + i + i + i + i),
                    IsCurrent = false
                };
            }

            return seasons;
        }

        //private void CreateUserAndRoles()
        //{

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //    //var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        //    var store = new UserStore<ApplicationUser>(db);
        //    var manager = new UserManager<ApplicationUser, string>(store);


        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        //string password = "K.Rob34!";

        //        //var user = new ApplicationUser();
        //        //user.UserName = "Admin";
        //        //user.Email = "admin@admin.com";
        //        //user.EmailConfirmed = true;
        //        //user.PasswordHash = password;

        //        //RegisterViewModel registerViewModel = new RegisterViewModel()
        //        //{
        //        //    Email = "admin@admin.com",
        //        //    Password = "K.Rob34!",
        //        //    ConfirmPassword = "K.Rob34!"
        //        //};



        //        //var chkUser = UserManager.Create(user, userPWD);

        //        ////Add default User to Role Admin    
        //        //if (chkUser.Succeeded)
        //        //{
        //        //    var result1 = UserManager.AddToRole(user.Id, "Admin");
        //        //}

        //        //var result = await UserManager.CreateAsync(user, user.PasswordHash);

        //    }

        //    if (!roleManager.RoleExists("Citizen"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Citizen";
        //        roleManager.Create(role);

        //        ////var users = new List<ApplicationUser>()
        //        ////{
        //        ////    new ApplicationUser()
        //        ////    {
        //        ////        UserName = "citizen1",
        //        ////        Email = "citizen1@citizen1.com",
        //        ////        EmailConfirmed = true
        //        ////    },
        //        ////     new ApplicationUser()
        //        ////    {
        //        ////        UserName = "citizen2",
        //        ////        Email = "citizen2@citizen1.com",
        //        ////        EmailConfirmed = true
        //        ////    },
        //        ////     new ApplicationUser()
        //        ////    {
        //        ////        UserName = "citizen3",
        //        ////        Email = "citizen3@citizen1.com",
        //        ////        EmailConfirmed = true
        //        ////    },
        //        ////     new ApplicationUser()
        //        ////    {
        //        ////        UserName = "citizen4",
        //        ////        Email = "citizen4@citizen1.com",
        //        ////        EmailConfirmed = true
        //        ////    },
        //        ////     new ApplicationUser()
        //        ////    {
        //        ////        UserName = "citizen5",
        //        ////        Email = "citizen5@citizen1.com",
        //        ////        EmailConfirmed = true
        //        ////    }
        //        ////};

        //        ////string userPWD = _passwordHasher.HashPassword("K.Rob34!");

        //        ////foreach (var u in users)
        //        ////{
        //        ////    var userResult = UserManager.Create(u, userPWD);

        //        ////    //Add default User to Role Admin    
        //        ////    if (userResult.Succeeded)
        //        ////    {
        //        ////        var roleResult = UserManager.AddToRole(u.Id, "Citizen");

        //        ////    }
        //        ////}


        //    }

        //    if (!roleManager.RoleExists("Warden"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Warden";
        //        roleManager.Create(role);

        //        ////Here we create a Admin super user who will maintain the website                   
        //        //var user = new ApplicationUser();
        //        //user.UserName = "Warden";
        //        //user.Email = "warden@warden.com";


        //        //string userPWD = _passwordHasher.HashPassword("K.Rob34!");

        //        //var chkUser = UserManager.Create(user, "K.Rob34!");

        //        ////Add default User to Role Admin    
        //        //if (chkUser.Succeeded)
        //        //{
        //        //    var result1 = UserManager.AddToRole(user.Id, "Warden");
        //        //}
        //    }

        //}

        //private void SeedData()
        //{
        //    if (!repo.Seasons.Any())
        //    {
        //        List<Season> seasons = new List<Season>()
        //        {
        //            new Season()
        //            {
        //                StartDate = DateTime.Parse("11/1/2020"),
        //                EndDate = DateTime.Parse("11/30/2020"),
        //                IsCurrent = true,
        //                Name = "Season 1"
        //            },
        //            new Season()
        //            {
        //                StartDate = DateTime.Parse("12/1/2020"),
        //                EndDate = DateTime.Parse("12/31/2020"),
        //                IsCurrent = false,
        //                Name = "Season 2"
        //            },
        //            new Season()
        //            {
        //                StartDate = DateTime.Parse("1/1/2021"),
        //                EndDate = DateTime.Parse("1/31/2021"),
        //                IsCurrent = false,
        //                Name = "Season 3"
        //            },
        //            new Season()
        //            {
        //                StartDate = DateTime.Parse("2/1/2021"),
        //                EndDate = DateTime.Parse("2/28/2021"),
        //                IsCurrent = false,
        //                Name = "Season 4"
        //            }
        //        };

        //        foreach (var s in seasons)
        //        {
        //            repo.Seasons.Add(s);
        //        }

        //        repo.SaveChanges();
        //    }

        //    if (!repo.Genres.Any())
        //    {

        //    }

        //    if (!repo.Statuses.Any())
        //    {

        //    }

        //    if (!repo.Matches.Any())
        //    {
        //        DateTime tempDate = DateTime.Parse("11/1/2020");
        //        var genres = repo.Genres.Select(g => g.Id).ToList();
        //        var seasons = repo.Seasons.OrderByDescending(s => s.StartDate).Select(s => s.Id).ToList();
        //        var statuses = repo.Statuses.Select(s => s.Id).ToList();

        //        List<Match> matches = new List<Match>()
        //        {
        //            new Match()
        //            {
        //                StartDate = tempDate,
        //                EndDate = tempDate.AddDays(7),
        //                GenreId = genres[1],
        //                SeasonId = seasons[0],
        //                IsCurrent = true,
        //                Name = "Match 1",
        //                StatusId = statuses[3]
        //            },
        //           new Match()
        //            {
        //                StartDate = tempDate.AddDays(7),
        //                EndDate = tempDate.AddDays(14),
        //                GenreId = genres[1],
        //                SeasonId = seasons[0],
        //                IsCurrent = false,
        //                Name = "Match 2",
        //                StatusId = statuses[0]
        //            },
        //            new Match()
        //            {
        //                StartDate = tempDate.AddDays(14),
        //                EndDate = tempDate.AddDays(21),
        //                GenreId = genres[1],
        //                SeasonId = seasons[0],
        //                IsCurrent = false,
        //                Name = "Match 3",
        //                StatusId = statuses[2]
        //            }
        //        };

        //        foreach (var match in matches)
        //        {
        //            repo.Matches.Add(match);
        //        }

        //        repo.SaveChanges();
        //    }

        //    if (!repo.MovieSubmissions.Any())
        //    {
        //        var matches = repo.Matches.OrderByDescending(m => m.StartDate).ToList();
        //        var players = repo.Players.ToList();

        //        List<MovieSubmission> movieSubmissions = new List<MovieSubmission>()
        //        {
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[0].Id,
        //                PlayerId = players[0].Id,
        //                Title = "Pan's Labyrinth",
        //                SubmissionDate = DateTime.Parse("11/1/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=AcHasH-nLhU",
        //                ReasonToChoose = "The crown jewel of director Guillermo del Toro's career. An R rated fantasy in the style of old fables and fairy tales which features fantastic creatures, mystery, and drama. If you haven't seen it, this is an incredibly unique movie and an absolute must watch.",
        //                Synopsis = "It's 1944 and the Allies have invaded Nazi-held Europe. In Spain, a troop of soldiers are sent to a remote forest to flush out the rebels. They are led by Capitan Vidal, a murdering sadist, and with him are his new wife Carmen and her daughter from a previous marriage, 11-year-old Ofelia. Ofelia witnesses her stepfather's sadistic brutality and is drawn into Pan's Labyrinth, a magical world of mythical beings."
        //            },
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[0].Id,
        //                PlayerId = players[1].Id,
        //                Title = "Miss Peregrine's Home for Peculiar Children",
        //                SubmissionDate = DateTime.Parse("11/1/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=3jbUE0fKRuA&ab_channel=YouTubeMovies",
        //                ReasonToChoose = @"The crown jewel of director Guillermo del Toro's career. An R rated fantasy in the style of old fables and fairy tales which features fantastic creatures, mystery, and drama. 
        //                    If you haven't seen it, this is an incredibly unique movie and an absolute must watch.",
        //                Synopsis = @"It's 1944 and the Allies have invaded Nazi-held Europe. In Spain, a troop of soldiers are sent to a remote forest to flush out the rebels. They are led by Capitan Vidal, 
        //                    a murdering sadist, and with him are his new wife Carmen and her daughter from a previous marriage, 11-year-old Ofelia. Ofelia witnesses her stepfather's sadistic brutality and is 
        //                    drawn into Pan's Labyrinth, a magical world of mythical beings."
        //            },
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[0].Id,
        //                PlayerId = players[2].Id,
        //                Title = "Underworld (2003)",
        //                SubmissionDate = DateTime.Parse("11/1/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=MqT-e44kIM8&ab_channel=YouTubeMovies",
        //                ReasonToChoose = @"The original Vampire/Werewolf action adventure is the best. Kate Beckinsdale’s kickass Vampire acting spawned an entire series.",
        //                Synopsis = @""
        //            },
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[0].Id,
        //                PlayerId = players[3].Id,
        //                Title = "Stardust",
        //                SubmissionDate = DateTime.Parse("11/1/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=VfYBKDyF-Dk&ab_channel=YouTubeMovies",
        //                ReasonToChoose = @"Looks like a classic adventure movie in a fun fantastical setting. Surprisingly fun and endearing.",
        //                Synopsis = @""
        //            },
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[1].Id,
        //                PlayerId = players[0].Id,
        //                Title = "The Prestige",
        //                SubmissionDate = DateTime.Parse("11/8/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=ijXruSzfGEc",
        //                ReasonToChoose = @"A fantastic movie about two magicians competing to be the best. Drama and mystery galore.",
        //                Synopsis = @""
        //            },
        //           new MovieSubmission()
        //            {
        //                MatchId = matches[1].Id,
        //                PlayerId = players[1].Id,
        //                Title = "Rush",
        //                SubmissionDate = DateTime.Parse("11/8/2020"),
        //                Trailer = "https://youtu.be/4XA73ni9eVs",
        //                ReasonToChoose = @"This powerful drama is not about racing, it is about the true real life competitive relationship of the 2 greatest F1 drivers to ever set foot in a car, how racing shaped their lives and their connection with them and their world. This could very well be Ron Howard's best film to date, with a Hans Zimmer score you will enjoy every second of this film and think about it even after the checkered flags have come down. Chris Hemsworth and Daniel Bruhl deliver an oscar worthy performance that captivates you mind, body, and soul xD",
        //                Synopsis = @""
        //            },
        //            new MovieSubmission()
        //            {
        //                MatchId = matches[1].Id,
        //                PlayerId = players[2].Id,
        //                Title = "Blood Diamond",
        //                SubmissionDate = DateTime.Parse("11/8/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=yknIZsvQjG4&ab_channel=Movieclips",
        //                ReasonToChoose = @"One of the greatest dramas of our time. Leonardo DiCaprio fuses action, romance, and global social issues into an internationally acclaimed drama. Civil war, diamonds, and two men willing to do whatever it takes to get what they want. This movie was rated 10/10 by people who actually lived through the Sierra Leone civil war.",
        //                Synopsis = @""
        //            },
        //           new MovieSubmission()
        //            {
        //                MatchId = matches[1].Id,
        //                PlayerId = players[3].Id,
        //                Title = "LIttle Women (2019)",
        //                SubmissionDate = DateTime.Parse("11/8/2020"),
        //                Trailer = "https://www.youtube.com/watch?v=AST2-4db4ic&ab_channel=SonyPicturesEntertainment",
        //                ReasonToChoose = @"Little Women is a classic story and this movie had solid reviews so I've been meaning to see it, plus Emma Watson.",
        //                Synopsis = @""
        //            }
        //        };

        //        foreach (var movieSubmission in movieSubmissions)
        //        {
        //            repo.MovieSubmissions.Add(movieSubmission);
        //        }

        //        repo.SaveChanges();
        //    }

        //    if (!repo.MovieRatings.Any())
        //    {
        //        var movieSubmissions = repo.MovieSubmissions.OrderByDescending(m => m.Match.StartDate).Select(m => m.Id).ToList();
        //        var matches = repo.Matches.OrderByDescending(m => m.StartDate).Select(m => m.Id).ToList();
        //        var players = repo.Players.Select(p => p.Id).ToList();

        //        List<MovieRating> movieRatings = new List<MovieRating>()
        //        {
        //            new MovieRating()
        //            {
        //                //MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[0],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[0],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[0],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[0],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[1],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[1],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[1],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[1],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[2],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[2],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[2],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[2],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[3],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[3],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[3],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[0],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[3],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[0],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[0],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[0],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[0],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[1],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[1],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[1],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[1],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[2],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[2],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[2],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[2],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[0],
        //                PlayerId = players[3],
        //                Rating = 1,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[1],
        //                PlayerId = players[3],
        //                Rating = 3,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[2],
        //                PlayerId = players[3],
        //                Rating = 4,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            },
        //            new MovieRating()
        //            {
        //               // MatchId = matches[1],
        //                MovieSubmissionId = movieSubmissions[3],
        //                PlayerId = players[3],
        //                Rating = 2,
        //                RatingDate = DateTime.Parse("11/6/2020"),
        //                ReasonForVote = ""
        //            }
        //        };

        //        foreach (var rating in movieRatings)
        //        {
        //            repo.MovieRatings.Add(rating);
        //        }

        //        repo.SaveChanges();
        //    }
        //}
    }
}
