using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCrud.Models
{
    public class LoginCredentials
    {
        [Required]
        [Key]
        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}