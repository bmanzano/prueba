using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Models
{
    public class IndividualViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        public string Name { get; set; }

        [DisplayName("Correo electrónico")]
        [Required]
        [MaxLength(300)]
        [EmailAddress(ErrorMessage ="La entrada no tiene formato de correo electrónico")]
        //[Remote("CheckEmail", "Individual", HttpMethod = "GET", ErrorMessage = "El Email esta ocupado")]
        public string Email { get; set; }

        public string EmailAnterior { get; set; }
    }
}