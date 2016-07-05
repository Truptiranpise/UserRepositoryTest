using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRepositories.Models
{
    public class User
    {
        [Display(Name="User Name")]
        [Required]
        public string Name { get; set; }

        public string Repos_Url { get; set; }
               
        [Display(Name = "Avatar URL")]
        public string Avatar_Url { get; set; }

        public string Location { get; set; }
        
        public List<Repository> Repositories { get; set; }
    }
}