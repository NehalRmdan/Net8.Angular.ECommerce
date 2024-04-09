using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class LogInDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [RegularExpression("^(?=[^\\d_].*?\\d)\\w(\\w|[!@#$%]){7,20}")]
        public string Password { get; set; }

    }
}