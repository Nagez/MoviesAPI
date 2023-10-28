using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities
{
    public class Genre //: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The field with name: {0} is required")]
        [StringLength(10)]
        [FirstLetterUppercase] // custom validation
        public string Name { get; set; }

        /*
        //model valudation, occurs after the attribute validation checks
        //It can has multiple validations but its not reusible for other classes
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
        }
        */
    }
}
