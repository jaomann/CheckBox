using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckBox.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [MaxLength(15)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }

        [DisplayName("Sobrenome")]
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Surname { get; set; }

        [DisplayName("Email")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Password { get; set; }

    }
}
