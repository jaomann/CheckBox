using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckBox.Web.Models
{
    public class NoteViewModel
    {
        [DisplayName("Nome")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }
        [DisplayName("Conteudo da Note")]
        [MaxLength(400)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Content { get; set; }
        [DisplayName("Data de criação")]
        [DisplayFormat(DataFormatString="{0:D}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Born { get; set; }

        
    }
}
