using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Register
    {
        [Required]
        [Display(Name ="Kullanıcı Adınız")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage ="Email adresinizi düzgün giriniz.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreniz uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}