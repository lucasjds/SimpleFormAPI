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
        [Column(  "cpf")]
        public string Cpf { get; set; }
        [Column( "fullname")]
        public string Fullname { get; set; }
        [Column( "emailaddress")]
        public string Emailaddress { get; set; }
        [Column( "datanascimento")]
        public string Datanascimento { get; set; }
        [Column("password")]
        public string password { get; set; }
    }
}