using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCrud.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {

    }

    public class UserMetadata
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [DisplayName("Fecha de Creacion")]
        public System.DateTime CreatationDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [DisplayName("Fecha de Ultima Modificacion")]
        public System.DateTime ModificationDate { get; set; }
        [DisplayName("Tipo de Usuario")]
        public short IdUserType { get; set; }
    }
}