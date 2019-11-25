using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required (ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60,ErrorMessage ="Nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Email é obrigatório")]
        [EmailAddress(ErrorMessage ="Email em formato inválido")]
        public string Email { get; set; }
    }
}
