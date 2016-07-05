using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserRepositories.Models
{
    public class Repository
    {
        public string Name { get; set; }

        [Display(Name = "Stargazers Count")]
        public int Stargazers_count { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }

    }
}