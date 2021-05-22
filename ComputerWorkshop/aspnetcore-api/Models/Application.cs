using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore_api.Models
{
    public class Application
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string PersonalData { get; set; }

        [Required]
        public string Problem { get; set; }

        [Required]
        public string DescriptionOfProblem { get; set; }

        public string Secret { get; set; }
    }
}
