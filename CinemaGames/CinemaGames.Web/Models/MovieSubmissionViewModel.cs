using CinemaGames.Web.Infrastructure.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaGames.Web.Models
{
    public class MovieSubmissionViewModel: IValidatableObject
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public string Match { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public System.DateTime SubmissionDate { get; set; }
        public string ReasonToChoose { get; set; }
        public string Synopsis { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MovieSubmissionModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,new[] { item.PropertyName }));
        }
    }
}