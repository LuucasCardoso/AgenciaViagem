using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email inválido!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(4, 12, ErrorMessage = "O usuário deve conter entre 4 e 12 caracteres!")]
        public string User { get; set; }
        public bool Administrador { get; set; }
        public bool Ativo { get; set; }
    }
}
