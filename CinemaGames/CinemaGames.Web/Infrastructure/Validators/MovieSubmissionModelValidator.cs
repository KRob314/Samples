using CinemaGames.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaGames.Web.Infrastructure.Validators
{
    public class MovieSubmissionModelValidator: AbstractValidator<MovieSubmissionViewModel>
    {
        public MovieSubmissionModelValidator()
        {
            RuleFor(movie => movie.MatchId).GreaterThan(0)
                .WithMessage("Select a Match");

            RuleFor(movie => movie.Title).NotEmpty().Length(1, 100)
                .WithMessage("Enter a Title");

            RuleFor(movie => movie.Trailer).NotEmpty().Length(1, 500)
                .WithMessage("Enter the Trailer");

            RuleFor(movie => movie.ReasonToChoose).NotEmpty().Length(1, 2000)
                .WithMessage("Enter the reason to choose");

            RuleFor(movie => movie.Trailer).NotEmpty().Must(ValidTrailerURI)
                .WithMessage("Only Youtube Trailers are supported");
        }

        private bool ValidTrailerURI(string trailerURI)
        {
            return (!string.IsNullOrEmpty(trailerURI) && trailerURI.ToLower().StartsWith("https://www.youtube.com/watch?"));
        }
    }
}