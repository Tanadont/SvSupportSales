using System.ComponentModel.DataAnnotations;

namespace SvSupportSales.Models
{
    public class User 
    {
        public int? UserId { get; set; }
        [Required(ErrorMessage = "{0} field is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long maximum {1}.", MinimumLength = 1)]
        [Display(Name = "Position")]
        public string? Position { get; set; }
        public string? Prefix { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Name { get; set; }

        public string? NickName { get; set; }

        public string? Telephone { get; set; }

        public string? CitizenId { get; set; }

        public string? BranchName { get; set; }

        public string? RegionName { get; set; }

        public string? SubBranch { get; set; }

        public string? NameVerified { get; set; }


    }
}
