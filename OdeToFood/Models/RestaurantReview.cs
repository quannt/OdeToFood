using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview : IValidatableObject
    {
        public virtual int Id { get; set; }


        [Range(1, 10)]
        [Required]
        public virtual int Rating { get; set; }

        [Required]
        public virtual string Body { get; set; }

        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        public virtual string ReviewerName { get; set; }
        public virtual int RestaurantId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("quan"))
            {
                yield return new ValidationResult("Sorry, you can't do this.");
            }
        }
    }
}