using CinemaGames.Entities;
using CinemaGames.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaGames.Web.Models
{
    public class MatchViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int GenreId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string FullName { get; set; }

        public string Genre { get; set; }
        public string Season { get; set; }
        public string Status { get; set; }

        //public virtual Genre Genre { get; set; }
        //public virtual Season Season { get; set; }
        //public virtual Status Status { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<MovieSubmission> MovieSubmissions { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MatchModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}