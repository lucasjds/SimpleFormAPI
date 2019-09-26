using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleAPI.Models
{
    public class Usuario
    {
        [Key, Required, Display(Name = "id")]
        public int Id { get; set; }
        [Display(Name = "cpf")]
        public string Cpf { get; set; }
        [Display(Name = "fullname")]
        public string Fullname { get; set; }
        [Display(Name = "emailaddress")]
        public string Emailaddress { get; set; }
        [Display(Name = "datanascimento")]
        public string Datanascimento { get; set; }
    }
}