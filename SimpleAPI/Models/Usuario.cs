using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleAPI.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key, Required, Column( "id")]
        public int Id { get; set; }
        [Required, Column(  "cpf")]
        public string Cpf { get; set; }
        [Required, Column( "fullname")]
        public string Fullname { get; set; }
        [Required, Column( "emailaddress")]
        public string Emailaddress { get; set; }
        [Required, Column( "datanascimento")]
        public string Datanascimento { get; set; }
        [Required, Column("password")]
        public string password { get; set; }
    }
}