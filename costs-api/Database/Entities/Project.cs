using System.ComponentModel.DataAnnotations;

namespace costs_api.Database.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Budget { get; set; }

        [Required]
	    public string Category { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
